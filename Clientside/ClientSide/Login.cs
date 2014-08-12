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
using System.Configuration;
using System.Net.Sockets;
using ClientSide.ServerServices;

namespace ClientSide
{
    public partial class Login : Form
    {

        string mainEmailsPath = ConfigurationSettings.AppSettings["EmailClient"];
        //reference to server
        private EmailServiceClient _server;

        public Login()
        {
            InitializeComponent();
            _server = ConnectionManager.Instance.Server;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string ipAddressFromUser = textBoxIP.Text;

            if (_server.IsUserVaild(textBoxUserName.Text, textBoxPassword.Text))
            {
                if (ipAddressFromUser != string.Empty)
                {
                    ConnectionManager.Instance.Close();
                    ConnectionManager.Instance.Init(ipAddressFromUser, textBoxUserName.Text, textBoxPassword.Text);

                    //if (ConnectionManager.Instance.Connect())
                    {
                        WriteDetailsToMailServerFile(textBoxUserName.Text, textBoxPassword.Text, textBoxIP.Text);
                        MessageBox.Show("Login succeeded.", "Login",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    //else
                    //{
                    //    MessageBox.Show("Something wrong please try again.", "Login",
                    //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    this.Close();
                    //}
                }
                else
                {
                    MessageBox.Show("You must write IP address", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             }
        }
           

        private void WriteDetailsToMailServerFile(string username,string password,string IP)
        {
            string combinedPath = Path.Combine(mainEmailsPath, "mailServer.dat");
            using (FileStream fileStream = new FileStream(combinedPath, FileMode.Create))
            {
                //StringFormatter
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, "<<"+ username +">>"+ ";" + password + ";" + IP  );
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.NewUserAddedEvent += signUp_NewUserAddedEvent;
            signUp.Show();
        }

        void signUp_NewUserAddedEvent(string username, string password)
        {
            textBoxUserName.Text = username;
            textBoxPassword.Text = password;

            textBoxIP.Focus();
        }
    }
}
