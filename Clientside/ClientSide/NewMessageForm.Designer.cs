namespace ClientSide
{
    partial class NewMessageForm
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
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(74, 48);
            this.textBoxSubject.Multiline = true;
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(170, 52);
            this.textBoxSubject.TabIndex = 1;
            // 
            // textBoxBody
            // 
            this.textBoxBody.Location = new System.Drawing.Point(74, 119);
            this.textBoxBody.Multiline = true;
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(170, 153);
            this.textBoxBody.TabIndex = 2;
            // 
            // textBoxTo
            // 
            this.textBoxTo.Location = new System.Drawing.Point(74, 22);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(170, 20);
            this.textBoxTo.TabIndex = 0;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(12, 24);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(23, 13);
            this.labelTo.TabIndex = 3;
            this.labelTo.Text = "To:";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(12, 51);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(46, 13);
            this.labelSubject.TabIndex = 4;
            this.labelSubject.Text = "Subject:";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(12, 136);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(34, 13);
            this.labelBody.TabIndex = 5;
            this.labelBody.Text = "Body:";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(238, 301);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // NewMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 344);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.textBoxBody);
            this.Controls.Add(this.textBoxSubject);
            this.Name = "NewMessageForm";
            this.Text = "NewMessageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.Button buttonSend;
    }
}