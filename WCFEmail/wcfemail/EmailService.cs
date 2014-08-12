using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WcfEmail
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class EmailService : IEmailService
    {
        static EmailService()
        {
            ConnectionManager.Instance.UserRequestEvent += Logic.Instance.UserRequestToServer;
            ConnectionManager.Instance.StartListensing();
        }

        public EmailService()
        {
        }

        public void AddNewUser(string username, string password)
        {
            Logic.Instance.AddNewUser(username, password);
        }

        public bool IsValidPassword(string password)
        {
            return Logic.Instance.IsValidPassword(password);
        }

        public bool IsValidUserName(string username)
        {
            return Logic.Instance.IsValidUserName(username);
        }

        public void DeleteExsitingUser(string username, string password)
        {
            Logic.Instance.DeleteExsitingUser(username, password);
        }

        public void UpdateExistingUserPassword(string username, string currentPassword, string newPassword)
        {
            Logic.Instance.UpdateExistingUserPassword(username, currentPassword, newPassword);
        }

        public List<User> ShowExsitingUsers(string username, string password)
        {
            return Logic.Instance.ShowExsitingUsers(username, password);
        }

        //this method will also be useful to check wether a username is valid or not.
        public bool IsUserVaild(string username, string password)
        {
            return Logic.Instance.IsUserVaild(username, password);
        }      

        public bool IsLegitPassword(string passwordToCheck)
        {
            return Logic.Instance.IsLegitPassword(passwordToCheck);
        }

        public bool IsLegitUsername(string usernameToCheck)
        {
            return Logic.Instance.IsLegitUsername(usernameToCheck);
        }

        public void Connect()
        {

        }
    }
}


