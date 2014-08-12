using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfEmail;

namespace ServerRunner
{
    [ServiceContract]
    public interface IService1
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
    }
}
