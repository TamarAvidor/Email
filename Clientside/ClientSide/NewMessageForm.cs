using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Configuration;
using Common;

namespace ClientSide
{
    public partial class NewMessageForm : Form
    {
        string mainEmailsPath = ConfigurationSettings.AppSettings["EmailClient"];

        public NewMessageForm()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string receiversToCheck = textBoxTo.Text;
            string subjectToCheck = textBoxSubject.Text;
            string bodyToCheck = textBoxBody.Text;

            bool isReceiversToCheckLegit = IsReceiversToCheckLegit(receiversToCheck);
            bool isSubjectToCheckLegit = IsSubjectToCheckLegit(subjectToCheck);
            bool isBodyToCheckLegit = IsBodyToCheckLegit(bodyToCheck);

            if ((isReceiversToCheckLegit && isSubjectToCheckLegit && isBodyToCheckLegit) == true)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                /*List<string> newMessageDetails = new List<string>();
                newMessageDetails[0] = receiversToCheck;
                newMessageDetails[1] = subjectToCheck;
                newMessageDetails[2] = bodyToCheck;*/
                string combinedPath = Path.Combine(mainEmailsPath, "mailServer.dat");
                string senderName;
                using (FileStream fileStream = new FileStream(combinedPath, FileMode.Open))
                {
                    string userDetails = binaryFormatter.Deserialize(fileStream).ToString(); //handling an empty file text 
                    List<string> userDetailsList = userDetails.Split(';').ToList<string>();
                    senderName = userDetailsList[0];
                }

                SendMail(senderName, receiversToCheck,subjectToCheck, bodyToCheck);
            }

            MessageBox.Show("Message was sent successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private bool IsBodyToCheckLegit(string bodyToCheck)
        {
            return true;
        }

        private bool IsSubjectToCheckLegit(string subjectToCheck)
        {
            return true;
        }

        private bool IsReceiversToCheckLegit(string receiversToCheck)
        {

            bool isReceiversListLegit = true;
            ////List<User> legitUsers = new List<User>();
            //List<string> receiversList = receiversToCheck.Split(';').ToList<string>();

            //foreach (string usernameString in receiversList)
            //{

            //}

            return isReceiversListLegit;

        }

        public void SendMail(string senderName, string receivers, string subject, string body)
        {
            var message = new NewMailMessage();
            message.SenderName = senderName;
            message.Time = DateTime.Now;
            message.DestinationList = receivers;
            message.Subject = subject;
            message.Body = body;

            message.Normalize();

            ConnectionManager.Instance.Send("newMail");
            ConnectionManager.Instance.Send(message.Serialize());

            ConnectionManager.Instance.Close();
        }

    }
}
