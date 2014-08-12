using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    [Serializable]
    public class MailMessage
    {
        public string senderName { set; get; }
        public string dateAndSTimeSending { set; get; }
        public string destinationUsersList { set; get; }
        public string messageSubject { set; get; }
        public string messageBody { set; get; }

        public MailMessage()
        {

        }

        public MailMessage(string senderName, string dateAndSTimeSending, string destinationUsersList, string messageSubject, string messageBody)
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
