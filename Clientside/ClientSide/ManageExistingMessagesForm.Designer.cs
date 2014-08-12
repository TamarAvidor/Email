namespace ClientSide
{
    partial class ManageExistingMessagesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonShowExistingMessages = new System.Windows.Forms.Button();
            this.buttonDeleteAllMessage = new System.Windows.Forms.Button();
            this.buttonBackScreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonShowExistingMessages
            // 
            this.buttonShowExistingMessages.Location = new System.Drawing.Point(46, 37);
            this.buttonShowExistingMessages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonShowExistingMessages.Name = "buttonShowExistingMessages";
            this.buttonShowExistingMessages.Size = new System.Drawing.Size(220, 28);
            this.buttonShowExistingMessages.TabIndex = 0;
            this.buttonShowExistingMessages.Text = "Show Existing Messages";
            this.buttonShowExistingMessages.UseVisualStyleBackColor = true;
            this.buttonShowExistingMessages.Click += new System.EventHandler(this.buttonShowExistingMessages_Click);
            // 
            // buttonDeleteAllMessage
            // 
            this.buttonDeleteAllMessage.Location = new System.Drawing.Point(46, 73);
            this.buttonDeleteAllMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDeleteAllMessage.Name = "buttonDeleteAllMessage";
            this.buttonDeleteAllMessage.Size = new System.Drawing.Size(220, 28);
            this.buttonDeleteAllMessage.TabIndex = 2;
            this.buttonDeleteAllMessage.Text = "Delete All Messages";
            this.buttonDeleteAllMessage.UseVisualStyleBackColor = true;
            this.buttonDeleteAllMessage.Click += new System.EventHandler(this.buttonDeleteAllMessage_Click);
            // 
            // buttonBackScreen
            // 
            this.buttonBackScreen.Location = new System.Drawing.Point(46, 109);
            this.buttonBackScreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBackScreen.Name = "buttonBackScreen";
            this.buttonBackScreen.Size = new System.Drawing.Size(220, 28);
            this.buttonBackScreen.TabIndex = 3;
            this.buttonBackScreen.Text = "Back Screen";
            this.buttonBackScreen.UseVisualStyleBackColor = true;
            this.buttonBackScreen.Click += new System.EventHandler(this.buttonBackScreen_Click);
            // 
            // ManageExistingMessagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 167);
            this.Controls.Add(this.buttonBackScreen);
            this.Controls.Add(this.buttonDeleteAllMessage);
            this.Controls.Add(this.buttonShowExistingMessages);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ManageExistingMessagesForm";
            this.Text = "ManageExistingMessagesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonShowExistingMessages;
        private System.Windows.Forms.Button buttonDeleteAllMessage;
        private System.Windows.Forms.Button buttonBackScreen;
    }
}