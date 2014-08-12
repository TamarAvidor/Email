namespace ClientSide
{
    partial class ShowMessage
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
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.labelTimeSent = new System.Windows.Forms.Label();
            this.textBoxSentTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(68, 22);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(213, 20);
            this.textBoxFrom.TabIndex = 0;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(12, 25);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(33, 13);
            this.labelFrom.TabIndex = 1;
            this.labelFrom.Text = "From:";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(6, 58);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(43, 13);
            this.labelSubject.TabIndex = 2;
            this.labelSubject.Text = "Subject";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(2, 130);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(34, 13);
            this.labelBody.TabIndex = 3;
            this.labelBody.Text = "Body:";
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(68, 58);
            this.textBoxSubject.Multiline = true;
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(213, 48);
            this.textBoxSubject.TabIndex = 4;
            // 
            // textBoxBody
            // 
            this.textBoxBody.Location = new System.Drawing.Point(68, 127);
            this.textBoxBody.Multiline = true;
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(213, 138);
            this.textBoxBody.TabIndex = 5;
            // 
            // labelTimeSent
            // 
            this.labelTimeSent.AutoSize = true;
            this.labelTimeSent.Location = new System.Drawing.Point(6, 286);
            this.labelTimeSent.Name = "labelTimeSent";
            this.labelTimeSent.Size = new System.Drawing.Size(58, 13);
            this.labelTimeSent.TabIndex = 6;
            this.labelTimeSent.Text = "Sent Time:";
            // 
            // textBoxSentTime
            // 
            this.textBoxSentTime.Location = new System.Drawing.Point(70, 286);
            this.textBoxSentTime.Name = "textBoxSentTime";
            this.textBoxSentTime.Size = new System.Drawing.Size(211, 20);
            this.textBoxSentTime.TabIndex = 7;
            // 
            // ShowMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 319);
            this.Controls.Add(this.textBoxSentTime);
            this.Controls.Add(this.labelTimeSent);
            this.Controls.Add(this.textBoxBody);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.textBoxFrom);
            this.Name = "ShowMessage";
            this.Text = "Show Message";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.Label labelTimeSent;
        private System.Windows.Forms.TextBox textBoxSentTime;
    }
}