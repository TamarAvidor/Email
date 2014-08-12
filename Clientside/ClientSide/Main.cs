using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using Common;

namespace ClientSide
{
    public partial class Main : Form
    {
        private Timer _timer;
        private string _mainEmailsPath;
        
        public Main()
        {
            InitializeComponent();

            _mainEmailsPath = ConfigurationSettings.AppSettings["EmailClient"];

            if (!Directory.Exists(_mainEmailsPath))
            {
                Directory.CreateDirectory(_mainEmailsPath);
            }

            try
            {
                ConnectionManager.Instance.WCFConnect();
                EstablishConnectionToServer();
                ShowControls();
            }
            catch 
            {
                HideControls();
                _timer = new Timer();
                _timer.Interval = 1000;
                _timer.Tick += _timer_Tick;
                _timer.Start();
            }
        }

        private void ShowControls()
        {
            btnGetMessages.Visible = true;
            buttonSendNewMsg.Visible = true;
            buttonManageExistingMessages.Visible = true;
            lblConnecting.Visible = false;
        }

        private void HideControls()
        {
            btnGetMessages.Visible = false;
            buttonSendNewMsg.Visible = false;
            buttonManageExistingMessages.Visible = false;

            lblConnecting.Visible = true;
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            TryConnecting();
        }

        private void TryConnecting()
        {
            try
            {
                ConnectionManager.Instance.WCFConnect();
                EstablishConnectionToServer();
                ShowControls();
            }
            catch 
            {
                _timer.Start();
            }
        }

        private void EstablishConnectionToServer()
        {
            ConnectionManager.Instance.DisconnectEvent += OnDisconnected;
            ConnectionManager.Instance.AcknowledgeEvent += OnAcknowledge;

            string username;
            string userPassword;
            string mailServerName;

            if (IsFileMailServerExists() == false)
            {
                Login login = new Login();
                Hide();
                login.ShowDialog();
                Show();

             
            }
            else
            {
                string combinedPath = Path.Combine(_mainEmailsPath, "mailServer.dat");
                using (FileStream fileStream = new FileStream(combinedPath, FileMode.Open))
                {
                    //StringFormatter
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    string userDetails = binaryFormatter.Deserialize(fileStream).ToString(); //handling an empty file text 
                    List<string> userDetailsList = userDetails.Split(';').ToList<string>();
                    
                    username = userDetailsList[0].Substring(2, userDetailsList[0].Length - 4);
                    userPassword = userDetailsList[1];
                    mailServerName= userDetailsList[2];

                    //check isUserValid and remove "connect" and then
                    ConnectionManager.Instance.Init(mailServerName, username, userPassword);
                }
            }
        }

        private void OnAcknowledge()
        {

        }

        private void OnDisconnected()
        {
            MessageBox.Show("Username or password are incorrect, please try logging in again.");

            Login login = new Login();
            login.Show();
            login.Focus();
        }

        private bool IsFileMailServerExists()
        {

            string combinedPath = Path.Combine(_mainEmailsPath, "mailServer.dat");
            return File.Exists(combinedPath);
        }

         private void buttonSendNewMsg_Click(object sender, EventArgs e)
         {
             NewMessageForm newMessageFrom = new NewMessageForm();
             newMessageFrom.Show();
         }

         private void btnGetMessages_Click(object sender, EventArgs e)
         {
             ConnectionManager.Instance.Send("mailRequest");

             List<MailMessage> mail = ConnectionManager.BinaryDeserialize<List<MailMessage>>();
             int numberOfNewMsgs = mail.Count;
             MessageBox.Show("Number of new messages is:" + numberOfNewMsgs.ToString(), "Number of new messages",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
             WriteMails(mail);

             ConnectionManager.Instance.Close();
         }

        private void WriteMails(List<MailMessage> mail)
        {
            var currentMail = new List<MailMessage>();
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            string combinedPath = Path.Combine(_mainEmailsPath, "mails.dat");
            if (File.Exists(combinedPath))
            {
                using (FileStream fileStream = new FileStream(combinedPath, FileMode.Open))
                {
                    currentMail = (List<MailMessage>)binaryFormatter.Deserialize(fileStream);
                }
            }

            using (FileStream fileStream = new FileStream(combinedPath, FileMode.Create))
            {
                currentMail.AddRange(mail);
                binaryFormatter.Serialize(fileStream, currentMail);
            }
        }

        private void buttonManageExistingMessages_Click(object sender, EventArgs e)
        {
            ManageExistingMessagesForm manageExistingMessagesForm = new ManageExistingMessagesForm();
            manageExistingMessagesForm.Show();
        }

    } 
}


