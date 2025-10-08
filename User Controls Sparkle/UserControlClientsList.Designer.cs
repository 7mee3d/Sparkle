namespace Sparkle.User_Controls_Sparkle
{
    partial class UserControlClientsList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelMainListViewClientsList = new Guna.UI2.WinForms.Guna2Panel();
            this.ListViewClientsLists = new System.Windows.Forms.ListView();
            this.ColumnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelMainListViewClientsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(187)))), ((int)(((byte)(156)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(25, 78);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(409, 74);
            this.guna2GradientPanel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Sparkle.Properties.Resources.client;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::Sparkle.Properties.Resources.List_Clients;
            this.pictureBox1.Location = new System.Drawing.Point(15, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Garamond", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clients List";
            // 
            // PanelMainListViewClientsList
            // 
            this.PanelMainListViewClientsList.Controls.Add(this.ListViewClientsLists);
            this.PanelMainListViewClientsList.Location = new System.Drawing.Point(-11, 264);
            this.PanelMainListViewClientsList.Name = "PanelMainListViewClientsList";
            this.PanelMainListViewClientsList.Size = new System.Drawing.Size(1205, 544);
            this.PanelMainListViewClientsList.TabIndex = 2;
            // 
            // ListViewClientsLists
            // 
            this.ListViewClientsLists.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewClientsLists.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnID,
            this.ColumnName,
            this.ColumnAddress,
            this.ColumnEmail,
            this.ColumnPhone});
            this.ListViewClientsLists.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListViewClientsLists.FullRowSelect = true;
            this.ListViewClientsLists.GridLines = true;
            this.ListViewClientsLists.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewClientsLists.HideSelection = false;
            this.ListViewClientsLists.Location = new System.Drawing.Point(11, 32);
            this.ListViewClientsLists.MultiSelect = false;
            this.ListViewClientsLists.Name = "ListViewClientsLists";
            this.ListViewClientsLists.Size = new System.Drawing.Size(1195, 505);
            this.ListViewClientsLists.TabIndex = 0;
            this.ListViewClientsLists.UseCompatibleStateImageBehavior = false;
            this.ListViewClientsLists.View = System.Windows.Forms.View.Details;
            // 
            // ColumnID
            // 
            this.ColumnID.Text = "ID";
            this.ColumnID.Width = 78;
            // 
            // ColumnName
            // 
            this.ColumnName.Text = "Name Client";
            this.ColumnName.Width = 360;
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.Text = "Address";
            this.ColumnAddress.Width = 261;
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.Text = "Email";
            this.ColumnEmail.Width = 315;
            // 
            // ColumnPhone
            // 
            this.ColumnPhone.Text = "Phone";
            this.ColumnPhone.Width = 177;
            // 
            // UserControlClientsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PanelMainListViewClientsList);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "UserControlClientsList";
            this.Size = new System.Drawing.Size(1195, 809);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelMainListViewClientsList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel PanelMainListViewClientsList;
        private System.Windows.Forms.ListView ListViewClientsLists;
        private System.Windows.Forms.ColumnHeader ColumnID;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader ColumnAddress;
        private System.Windows.Forms.ColumnHeader ColumnEmail;
        private System.Windows.Forms.ColumnHeader ColumnPhone;
    }
}
