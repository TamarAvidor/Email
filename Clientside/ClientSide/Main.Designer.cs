namespace ClientSide
{
    partial class Main
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
            this.buttonSendNewMsg = new System.Windows.Forms.Button();
            this.btnGetMessages = new System.Windows.Forms.Button();
            this.lblConnecting = new System.Windows.Forms.Label();
            this.buttonManageExistingMessages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSendNewMsg
            // 
            this.buttonSendNewMsg.Location = new System.Drawing.Point(50, 111);
            this.buttonSendNewMsg.Name = "buttonSendNewMsg";
            this.buttonSendNewMsg.Size = new System.Drawing.Size(148, 23);
            this.buttonSendNewMsg.TabIndex = 0;
            this.buttonSendNewMsg.Text = "Send New Message";
            this.buttonSendNewMsg.UseVisualStyleBackColor = true;
            this.buttonSendNewMsg.Click += new System.EventHandler(this.buttonSendNewMsg_Click);
            // 
            // btnGetMessages
            // 
            this.btnGetMessages.Location = new System.Drawing.Point(50, 82);
            this.btnGetMessages.Name = "btnGetMessages";
            this.btnGetMessages.Size = new System.Drawing.Size(148, 23);
            this.btnGetMessages.TabIndex = 1;
            this.btnGetMessages.Text = "Get New Messages";
            this.btnGetMessages.UseVisualStyleBackColor = true;
            this.btnGetMessages.Click += new System.EventHandler(this.btnGetMessages_Click);
            // 
            // lblConnecting
            // 
            this.lblConnecting.AutoSize = true;
            this.lblConnecting.Location = new System.Drawing.Point(75, 25);
            this.lblConnecting.Name = "lblConnecting";
            this.lblConnecting.Size = new System.Drawing.Size(90, 13);
            this.lblConnecting.TabIndex = 2;
            this.lblConnecting.Text = "Trying to connect";
            // 
            // buttonManageExistingMessages
            // 
            this.buttonManageExistingMessages.Location = new System.Drawing.Point(50, 53);
            this.buttonManageExistingMessages.Name = "buttonManageExistingMessages";
            this.buttonManageExistingMessages.Size = new System.Drawing.Size(148, 23);
            this.buttonManageExistingMessages.TabIndex = 3;
            this.buttonManageExistingMessages.Text = "Manage existing messages";
            this.buttonManageExistingMessages.UseVisualStyleBackColor = true;
            this.buttonManageExistingMessages.Click += new System.EventHandler(this.buttonManageExistingMessages_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 179);
            this.Controls.Add(this.buttonManageExistingMessages);
            this.Controls.Add(this.lblConnecting);
            this.Controls.Add(this.btnGetMessages);
            this.Controls.Add(this.buttonSendNewMsg);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSendNewMsg;
        private System.Windows.Forms.Button btnGetMessages;
        private System.Windows.Forms.Label lblConnecting;
        private System.Windows.Forms.Button buttonManageExistingMessages;
    }
}