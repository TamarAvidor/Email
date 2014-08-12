using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfEmail
{
    [Serializable]
    public class MailBox
    {
        public MailBox()
        {
            Mails = new List<Mail>();
            NumberOfPendingMails = 0;
        }


        public long NumberOfPendingMails { get; set; }

        public List<Mail> Mails { get; set; }
    }
}
