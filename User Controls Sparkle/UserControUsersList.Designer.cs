namespace Sparkle.User_Controls_Sparkle
{
    partial class UserControUsersList
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.GButtonSearchByUsername = new Guna.UI2.WinForms.Guna2Button();
            this.GTextBoxSearchUsersList = new Guna.UI2.WinForms.Guna2TextBox();
            this.PanelMainListViewClientsList = new Guna.UI2.WinForms.Guna2Panel();
            this.ListViewUsersLists = new System.Windows.Forms.ListView();
            this.ColumnUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnPassword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.PanelMainListViewClientsList.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.GButtonSearchByUsername);
            this.guna2Panel1.Controls.Add(this.GTextBoxSearchUsersList);
            this.guna2Panel1.Location = new System.Drawing.Point(738, 244);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(454, 94);
            this.guna2Panel1.TabIndex = 6;
            // 
            // GButtonSearchByUsername
            // 
            this.GButtonSearchByUsername.Animated = true;
            this.GButtonSearchByUsername.AnimatedGIF = true;
            this.GButtonSearchByUsername.BorderRadius = 10;
            this.GButtonSearchByUsername.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GButtonSearchByUsername.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GButtonSearchByUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GButtonSearchByUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GButtonSearchByUsername.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(187)))), ((int)(((byte)(156)))));
            this.GButtonSearchByUsername.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(112)))), ((int)(((byte)(94)))));
            this.GButtonSearchByUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.GButtonSearchByUsername.ForeColor = System.Drawing.Color.White;
            this.GButtonSearchByUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(187)))), ((int)(((byte)(156)))));
            this.GButtonSearchByUsername.Location = new System.Drawing.Point(349, 46);
            this.GButtonSearchByUsername.Name = "GButtonSearchByUsername";
            this.GButtonSearchByUsername.Size = new System.Drawing.Size(88, 42);
            this.GButtonSearchByUsername.TabIndex = 1;
            this.GButtonSearchByUsername.Text = "Search";
            this.GButtonSearchByUsername.Click += new System.EventHandler(this.GButtonSearchByUsername_Click);
            // 
            // GTextBoxSearchUsersList
            // 
            this.GTextBoxSearchUsersList.Animated = true;
            this.GTextBoxSearchUsersList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(187)))), ((int)(((byte)(156)))));
            this.GTextBoxSearchUsersList.BorderRadius = 20;
            this.GTextBoxSearchUsersList.BorderThickness = 2;
            this.GTextBoxSearchUsersList.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxSearchUsersList.DefaultText = "";
            this.GTextBoxSearchUsersList.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxSearchUsersList.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxSearchUsersList.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxSearchUsersList.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxSearchUsersList.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(187)))), ((int)(((byte)(156)))));
            this.GTextBoxSearchUsersList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GTextBoxSearchUsersList.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(112)))), ((int)(((byte)(94)))));
            this.GTextBoxSearchUsersList.IconLeft = global::Sparkle.Properties.Resources.Search;
            this.GTextBoxSearchUsersList.IconLeftOffset = new System.Drawing.Point(15, 0);
            this.GTextBoxSearchUsersList.Location = new System.Drawing.Point(3, 42);
            this.GTextBoxSearchUsersList.Name = "GTextBoxSearchUsersList";
            this.GTextBoxSearchUsersList.PlaceholderText = "Search By Username";
            this.GTextBoxSearchUsersList.SelectedText = "";
            this.GTextBoxSearchUsersList.Size = new System.Drawing.Size(340, 46);
            this.GTextBoxSearchUsersList.TabIndex = 0;
            // 
            // PanelMainListViewClientsList
            // 
            this.PanelMainListViewClientsList.Controls.Add(this.ListViewUsersLists);
            this.PanelMainListViewClientsList.Location = new System.Drawing.Point(0, 365);
            this.PanelMainListViewClientsList.Name = "PanelMainListViewClientsList";
            this.PanelMainListViewClientsList.Size = new System.Drawing.Size(1195, 444);
            this.PanelMainListViewClientsList.TabIndex = 5;
            // 
            // ListViewUsersLists
            // 
            this.ListViewUsersLists.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewUsersLists.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnUsername,
            this.ColumnPassword});
            this.ListViewUsersLists.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListViewUsersLists.FullRowSelect = true;
            this.ListViewUsersLists.GridLines = true;
            this.ListViewUsersLists.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewUsersLists.HideSelection = false;
            this.ListViewUsersLists.Location = new System.Drawing.Point(0, 3);
            this.ListViewUsersLists.MultiSelect = false;
            this.ListViewUsersLists.Name = "ListViewUsersLists";
            this.ListViewUsersLists.Size = new System.Drawing.Size(1195, 441);
            this.ListViewUsersLists.TabIndex = 0;
            this.ListViewUsersLists.UseCompatibleStateImageBehavior = false;
            this.ListViewUsersLists.View = System.Windows.Forms.View.Details;
            this.ListViewUsersLists.SelectedIndexChanged += new System.EventHandler(this.ListViewUsersLists_SelectedIndexChanged);
            // 
            // ColumnUsername
            // 
            this.ColumnUsername.Text = "Username";
            this.ColumnUsername.Width = 600;
            // 
            // ColumnPassword
            // 
            this.ColumnPassword.Text = "Password";
            this.ColumnPassword.Width = 590;
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
            this.guna2GradientPanel1.TabIndex = 4;
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
            this.label1.Size = new System.Drawing.Size(169, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Users List";
            // 
            // UserControUsersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.PanelMainListViewClientsList);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "UserControUsersList";
            this.Size = new System.Drawing.Size(1195, 809);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControUsersList_Paint);
            this.guna2Panel1.ResumeLayout(false);
            this.PanelMainListViewClientsList.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button GButtonSearchByUsername;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxSearchUsersList;
        private Guna.UI2.WinForms.Guna2Panel PanelMainListViewClientsList;
        private System.Windows.Forms.ListView ListViewUsersLists;
        private System.Windows.Forms.ColumnHeader ColumnUsername;
        private System.Windows.Forms.ColumnHeader ColumnPassword;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
