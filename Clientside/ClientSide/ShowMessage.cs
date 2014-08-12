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
    public partial class ShowMessage : Form
    {
        public ShowMessage()
        {
            InitializeComponent();
        }

        public ShowMessage(string from, string subject, string body, string dateTime)
        {
            InitializeComponent();
            textBoxFrom.Text = from;
            textBoxSubject.Text = subject;
            textBoxBody.Text = body;
            textBoxSentTime.Text = dateTime;
        }
    }
}
