using ClientSide.ServerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientSide
{

    public partial class SignUp : Form
    {
        public event Action<string, string> NewUserAddedEvent;
         
        private EmailServiceClient _server;

        public SignUp()
        {
            InitializeComponent();
            _server = ConnectionManager.Instance.Server;
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {

            bool isLegitUsername = _server.IsLegitUsername(textBoxUserName.Text);

            bool islegitPassword = _server.IsLegitPassword(textBoxPassword.Text);

            if (isLegitUsername == false)
            {
                MessageBox.Show("username is not legit, please insert username without space character", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (islegitPassword == false)
            {
                MessageBox.Show("password is not legit, please insert password without space character", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (isLegitUsername == true && islegitPassword == true)
            {
                _server.AddNewUser(textBoxUserName.Text, textBoxPassword.Text);
                MessageBox.Show("Signing up succeeded, now insert your details in Login window.", "Sign Up",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(NewUserAddedEvent != null)
                {
                    NewUserAddedEvent(textBoxUserName.Text, textBoxPassword.Text);
                }

                this.Close();
            }


        }
    }
}
