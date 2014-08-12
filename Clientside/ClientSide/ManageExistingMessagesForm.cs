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
using Common;

namespace ClientSide
{
    public partial class ManageExistingMessagesForm : Form
    {
        String _mainEmailsPath = ConfigurationSettings.AppSettings["EmailClient"];

        public ManageExistingMessagesForm()
        {
            InitializeComponent();
        }

        private void buttonBackScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDeleteAllMessage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
              "Are you sure you would like to delete all messages?", "Confirm deletion of all messages",
              MessageBoxButtons.OKCancel,
              MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                string combinedPath = Path.Combine(_mainEmailsPath, "mails.dat");

                using (FileStream fileStream = new FileStream(combinedPath, FileMode.Create))
                {

                }
            }
            else
            {
                this.Close();
            }
        }

        private void buttonShowExistingMessages_Click(object sender, EventArgs e)
        {
            ShowUserInbox showUserInbox = new ShowUserInbox();
            showUserInbox.Show();
        }
    }
}
