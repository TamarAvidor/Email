using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WcfEmail
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmailService
    {
        [OperationContract]
        void AddNewUser(string username, string password);
        [OperationContract]
        void DeleteExsitingUser(string username, string password);
        [OperationContract]
        void UpdateExistingUserPassword(string username, string currentPassword, string newPassword);
        [OperationContract]
        List<User> ShowExsitingUsers(string username, string password);
        [OperationContract]
        bool IsUserVaild(string username, string password);
        [OperationContract]
        bool IsValidPassword(string password);
        [OperationContract]
        bool IsValidUserName(string username);
        [OperationContract]
        bool IsLegitPassword(string passwordToCheck);
        [OperationContract]
        bool IsLegitUsername(string usernameToCheck);

        [OperationContract]
        void Connect();
    }
}
