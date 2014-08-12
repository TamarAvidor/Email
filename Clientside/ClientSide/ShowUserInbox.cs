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
using Common;
using System.Configuration;

namespace ClientSide
{
    public partial class ShowUserInbox : Form
    {
        public ShowUserInbox()
        {
            InitializeComponent();
        }

        private void ShowUserInbox_Load(object sender, EventArgs e)
        {
           List<MailMessage> mails;
           string mainEmailsPath = ConfigurationSettings.AppSettings["EmailClient"];
           string mailsPath = Path.Combine(mainEmailsPath,"mails.dat");

           using (var fileStream = new FileStream(mailsPath, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                mails = ((List<MailMessage>)binaryFormatter.Deserialize(fileStream));
            }
           int i = 1;
            foreach (MailMessage currentMail in mails)
            {

                ListViewItem item = new ListViewItem();
                item.Text = string.Format("number:{0}  senderName:{1}  Subject:{2}", i,currentMail.senderName,currentMail.messageSubject);
                i++;
                item.SubItems.Add(currentMail.senderName);
                item.SubItems.Add(currentMail.messageSubject);
                item.SubItems.Add(currentMail.messageBody);
                item.SubItems.Add(currentMail.dateAndSTimeSending);
                listViewInbox.Items.Add(item);

            }
        }

        private void listViewInbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listViewInbox.SelectedItems[0];
            string from = item.SubItems[1].Text;
            string subject = item.SubItems[2].Text;
            string body = item.SubItems[3].Text;
            string date = item.SubItems[4].Text;

            ShowMessage showMessage = new ShowMessage(from, subject, body, date);
            
            showMessage.Show();
        }

        private void showByNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputNumberForm inputNumberForm = new InputNumberForm();
            inputNumberForm.ShowDialog();

            if ((listViewInbox.Items.Count > inputNumberForm.number - 1) && (inputNumberForm.number - 1 >= 0))
            {
                ListViewItem item = listViewInbox.Items[inputNumberForm.number - 1];
                string from = item.SubItems[1].Text;
                string subject = item.SubItems[2].Text;
                string body = item.SubItems[3].Text;
                string date = item.SubItems[4].Text;
                ShowMessage showMessage = new ShowMessage(from, subject, body, date);
                showMessage.Show();
            }
            else
            {
                MessageBox.Show("There is no message number" + inputNumberForm.number, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
    }
}
