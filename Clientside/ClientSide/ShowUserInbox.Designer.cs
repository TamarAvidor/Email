namespace ClientSide
{
    partial class ShowUserInbox
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
            this.listViewInbox = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.showByNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewInbox
            // 
            this.listViewInbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewInbox.Location = new System.Drawing.Point(0, 24);
            this.listViewInbox.Name = "listViewInbox";
            this.listViewInbox.Size = new System.Drawing.Size(460, 300);
            this.listViewInbox.TabIndex = 2;
            this.listViewInbox.TileSize = new System.Drawing.Size(50, 50);
            this.listViewInbox.UseCompatibleStateImageBehavior = false;
            this.listViewInbox.View = System.Windows.Forms.View.List;
            this.listViewInbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewInbox_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showByNumberToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(460, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // showByNumberToolStripMenuItem
            // 
            this.showByNumberToolStripMenuItem.Name = "showByNumberToolStripMenuItem";
            this.showByNumberToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.showByNumberToolStripMenuItem.Text = "Show By Number";
            this.showByNumberToolStripMenuItem.Click += new System.EventHandler(this.showByNumberToolStripMenuItem_Click);
            // 
            // ShowUserInbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 324);
            this.Controls.Add(this.listViewInbox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ShowUserInbox";
            this.Text = "ShowUserInbox";
            this.Load += new System.EventHandler(this.ShowUserInbox_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewInbox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showByNumberToolStripMenuItem;

    }
}