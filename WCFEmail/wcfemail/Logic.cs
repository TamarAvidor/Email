using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace WcfEmail
{
    public class Logic
    {
        private static readonly Logic _instance = new Logic();

        private string _mainEmailsPath;

        private string _user;
        private NetworkStream _stream;
        private StreamReader _reader;
        private StreamWriter _writer;

        private List<User> _usersList = new List<User>();

        private Logic() 
        {
            _mainEmailsPath = ConfigurationSettings.AppSettings["MainEmailsFolder"];

            if (!Directory.Exists(_mainEmailsPath))
            {
                Directory.CreateDirectory(_mainEmailsPath);
            }

            ReadUserList();
        }

        public static Logic Instance
        {
            get 
            {
                return _instance; 
            }
        }

        public void UserRequestToServer(TcpClient client)
        {
            _stream = client.GetStream();
            _reader = new StreamReader(_stream);
            _writer = new StreamWriter(_stream);

            bool shouldWait = true;

            while (shouldWait)
            {
                string userRequest = _reader.ReadLine();
                shouldWait = HandleUserRequest(userRequest, client);
            }
        }

        public bool HandleUserRequest(string userRequest, TcpClient client)
        {
            switch (userRequest)
            {
                case "Connecting": { return HandleConnecting(client); }
                case "newMail": { HandleNewMail(client); return false; }
                case "mailRequest": { HandleMailRequest(client); return false; }
                default: { return true; }
            }
        }

        private bool HandleConnecting(TcpClient client)
        {
            var username = _reader.ReadLine();
            var password = _reader.ReadLine();

            if(!IsUserVaild(username, password))
            {
                Disconnect();
                client.Close();
                return false;
            }

            _user = username;

            Acknowledge();

            return true;
        }

        private void Acknowledge()
        {
            ConnectionManager.Instance.Send(_writer, "Acknowledge");
        }

        private void Disconnect()
        {
            ConnectionManager.Instance.Send(_writer, "Disconnect");
        }

        private void HandleMailRequest(TcpClient client)
        {
            string username = _user;

            MailBox mailBox = readMailBox(username);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            List<MailMessage> mailList = mailBox.Mails.Select(x => new MailMessage(
                    x.senderName, 
                    x.dateAndSTimeSending, 
                    String.Join(";", x.destinationUsersList.Select(u => u.username).ToList()), 
                    x.messageSubject, 
                    x.messageBody
                )).ToList();

            binaryFormatter.Serialize(_stream, mailList);
            mailBox.Mails.Clear();
            writeMailBox(username, mailBox);
            _stream.Close();
        }

        private void HandleNewMail(TcpClient client)
        {
            string username = _user;

            byte[] lengthByte = new byte[4];
            _stream.Read(lengthByte, 0, 4);

            var length = BitConverter.ToInt32(lengthByte, 0);

            byte[] data = new byte[length];
            _stream.Read(data, 0, length);

            var message = new NewMailMessage();
            message.Deserialize(data);

            User requestingUser = _usersList.Find((user) => user.username == username);
            List<User> legitUsers = CheckRecieverUsersExsitanceAndFreeSpace(message.DestinationList, requestingUser);

            Mail newMailForUsers = new Mail(message.SenderName, message.Time.ToString(), legitUsers, message.Subject, message.Body);

            HandleSendingMail(newMailForUsers);
        }

        private void HandleSendingMail(Mail newMailForUsers)
        {
            foreach (User user in newMailForUsers.destinationUsersList)
            {
                ReturnMailFromServerToUser(newMailForUsers, user);
            }
        }

        private List<User> CheckRecieverUsersExsitanceAndFreeSpace(string destinationUsernames, User requestingUser)
        {
            string appendDetailsForNewMail = null;
            List<User> legitUsers = new List<User>();
            List<string> destinationUsernamesList = destinationUsernames.Split(';').ToList<string>();
            bool failedSending = false;

            foreach (string usernameString in destinationUsernamesList)
            {
                User userToSerach = _usersList.Find((user) => user.username == usernameString);
                if (userToSerach != null) //means that user exsit in server
                {
                    MailBox mailBox = readMailBox(userToSerach.username);
                    if (mailBox.Mails.Count == 20) //full inbox
                    {
                        appendDetailsForNewMail += userToSerach.username + " has full inbox; ";
                        failedSending = true;
                    }
                    else //user can recieve the mail
                    {
                        legitUsers.Add(userToSerach);
                    }
                }
                else
                {
                    appendDetailsForNewMail += usernameString + " doen't exsit in server database; ";
                    failedSending = true;
                }

            }

            if (failedSending)
            {
                string dateTimeString = DateTime.Now.ToString();
                Mail mailToReturnByServerAfterFailure = new Mail("Server", dateTimeString, new List<User> { requestingUser }, "Unable to deliever mail", appendDetailsForNewMail);

                ReturnMailFromServerToUser(mailToReturnByServerAfterFailure, requestingUser);
            }

            return legitUsers;
        }

        private void ReturnMailFromServerToUser(Mail mailToReturnByServerAfterFailure, User userToSendMail)
        {
            // BinaryFormatter binaryFormatter = new BinaryFormatter();   //maybe we need to send the mail
            // binaryFormatter.Serialize(stream, mailToReturnByServerAfterFailure);
            MailBox mailBox = readMailBox(userToSendMail.username);
            mailBox.Mails.Add(mailToReturnByServerAfterFailure);
            writeMailBox(userToSendMail.username, mailBox);
        }

        private void writeMailBox(string username, MailBox mailBox)
        {
            string combinedPath = Path.Combine(_mainEmailsPath, "_" + username + "_" + "_mails.dat");
            using (FileStream fileStream = new FileStream(combinedPath, FileMode.Create))
            {
                //StringFormatter
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, mailBox);
            }
        }

        private MailBox readMailBox(string username)
        {
            string combinedPath = Path.Combine(_mainEmailsPath, "_" + username + "_" + "_mails.dat");
            MailBox toRet;
            using (FileStream fileStream = new FileStream(combinedPath, FileMode.Open))
            {
                //StringFormatter
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                try
                {
                    toRet = (MailBox)binaryFormatter.Deserialize(fileStream);
                }
                catch (Exception)
                {

                    toRet = new MailBox();
                }
            }
            return toRet;
        }

        private void CreateMailsFileToNewUser(string username)
        {
            MailBox mailBox = new MailBox();

            writeMailBox(username, mailBox);
        }

        private void ReadUserList()
        {
            string combinedPath = Path.Combine(_mainEmailsPath, "user.dat");

            if (File.Exists(combinedPath))
            {
                using (FileStream fileStream = new FileStream(combinedPath, FileMode.Open))
                {
                    //StringFormatter
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    _usersList = (List<User>)binaryFormatter.Deserialize(fileStream); //handling an empty file text 
                }
            }
        }

        public void AddNewUser(string username, string password)
        {
            if (IsValidUserName(username) && IsValidPassword(password))
            {

                _usersList.Add(new User(username, password));
                WriteUserListToFile();

                CreateMailsFileToNewUser(username);
            }

        }

        public bool IsValidPassword(string password)
        {
            return true;
        }

        public bool IsValidUserName(string username)
        {
            return true;
        }

        private void WriteUserListToFile()
        {
            string combinedPath = Path.Combine(_mainEmailsPath, "user.dat");
            using (FileStream fileStream = new FileStream(combinedPath, FileMode.Create))
            {
                //StringFormatter
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, _usersList);
            }
        }

        public void DeleteExsitingUser(string username, string password)
        {
            if (IsUserVaild(username, password))
            {
                _usersList.Remove(_usersList.Find((user) => user.username == username && user.password == password));
                string combinedPath = Path.Combine(_mainEmailsPath, "_" + username + "_" + "_mails.dat");
                File.Delete(combinedPath);
                WriteUserListToFile();
            }
            else if (IsUsernameExists(username))
            {
                //user password not correct.
                //therefore cannot be deleted

            }
            else
            {
                //MSG: user does not exists
            }
        }

        public void UpdateExistingUserPassword(string username, string currentPassword, string newPassword)
        {
            foreach (User user in _usersList)
            {
                Console.WriteLine(user.ToString());
            }
            if (IsUserVaild(username, currentPassword))
            {
                _usersList.Find((user) => user.username == username).password = newPassword;
                WriteUserListToFile();
            }
            else
            {
                //message to user that current passwod not correct
                //assuming user will not try to set his new password as the old one.
            }
        }

        public List<User> ShowExsitingUsers(string username, string password)
        {
            return _usersList;
        }

        //this method will also be useful to check wether a username is valid or not.
        public bool IsUserVaild(string username, string password)
        {
            bool returnbool = _usersList.Exists((user) => user.username == username && user.password == password);
            Console.WriteLine("IsUserVaild=" + returnbool);
            return returnbool;
        }

        public bool IsUsernameExists(string username)
        {
            return _usersList.Exists((user) => user.username == username);
        }


        public bool IsLegitPassword(string passwordToCheck)
        {
            bool isLegitPassword = true;
            if (String.IsNullOrEmpty(passwordToCheck) || String.IsNullOrWhiteSpace(passwordToCheck) 
                || passwordToCheck.Length > 8)
            {
                //message to user : your username Or PASSWORD cannot contain space charcter
                //please enter a new password and uaername
                isLegitPassword = false;
            }
            return isLegitPassword;
        }


        public bool IsLegitUsername(string usernameToCheck)
        {
            bool usernameLegit = true;
            if (String.IsNullOrEmpty(usernameToCheck) || String.IsNullOrWhiteSpace(usernameToCheck)
                || usernameToCheck.Length > 10)
            {
                usernameLegit = false;
                //message to user : your username Or PASSWORD cannot contain space charcter
                //please enter a new password and uaername
            }
            return usernameLegit;
        }
    }
}
