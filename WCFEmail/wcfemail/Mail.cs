using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfEmail
{
    [Serializable]
    public class Mail
    {
        /*private string senderName;
        private DateTime dateAndSTimeSending;
        private List<string> destinationUsernames;
        private string messageSubject;
        private string messageBody;*/
       

        public string senderName { set; get; }
        public string dateAndSTimeSending { set; get; }
        public List<User> destinationUsersList { set; get; }
        public string messageSubject { set; get; }
        public string messageBody { set; get; }

        public Mail(string senderName, string dateAndSTimeSending, List<User> destinationUsersList, string messageSubject, string messageBody)
        {
            // TODO: Complete member initialization

            this.senderName = senderName;
            this.dateAndSTimeSending = dateAndSTimeSending;
            this.destinationUsersList = destinationUsersList;            
            this.messageSubject = messageSubject;
            this.messageBody = messageBody;
        }
    }
}
