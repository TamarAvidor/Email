using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WcfEmail
{
    //[DataContract]
    [Serializable]
    public class User
    {
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        //[DataMember]
        public string username { set; get; }
       // [DataMember]
        public string password { set; get; }
    }
}
