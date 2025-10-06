namespace Sparkle
{
    partial class FormLoginScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoginScreen));
            this.GBorderLessFormRaduis = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.MainPanelShadowLogin = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.GTextBoxUsernameLogin = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelLoginWord = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.MainPanelShadowLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBorderLessFormRaduis
            // 
            this.GBorderLessFormRaduis.BorderRadius = 25;
            this.GBorderLessFormRaduis.ContainerControl = this;
            this.GBorderLessFormRaduis.DockIndicatorTransparencyValue = 0.6D;
            this.GBorderLessFormRaduis.TransparentWhileDrag = true;
            // 
            // MainPanelShadowLogin
            // 
            this.MainPanelShadowLogin.BackColor = System.Drawing.Color.Transparent;
            this.MainPanelShadowLogin.Controls.Add(this.guna2Button1);
            this.MainPanelShadowLogin.Controls.Add(this.guna2TextBox2);
            this.MainPanelShadowLogin.Controls.Add(this.GTextBoxUsernameLogin);
            this.MainPanelShadowLogin.Controls.Add(this.labelLoginWord);
            this.MainPanelShadowLogin.FillColor = System.Drawing.Color.WhiteSmoke;
            this.MainPanelShadowLogin.Location = new System.Drawing.Point(691, 58);
            this.MainPanelShadowLogin.Name = "MainPanelShadowLogin";
            this.MainPanelShadowLogin.Radius = 15;
            this.MainPanelShadowLogin.ShadowColor = System.Drawing.Color.Black;
            this.MainPanelShadowLogin.ShadowDepth = 50;
            this.MainPanelShadowLogin.Size = new System.Drawing.Size(534, 688);
            this.MainPanelShadowLogin.TabIndex = 0;
            this.MainPanelShadowLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanelShadowLogin_Paint);
            // 
            // guna2TextBox2
            // 
            this.guna2TextBox2.Animated = true;
            this.guna2TextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.guna2TextBox2.BorderRadius = 20;
            this.guna2TextBox2.BorderThickness = 2;
            this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox2.DefaultText = "";
            this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.SeaGreen;
            this.guna2TextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(74)))), ((int)(((byte)(75)))));
            this.guna2TextBox2.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.guna2TextBox2.IconLeft = global::Sparkle.Properties.Resources._lock;
            this.guna2TextBox2.IconLeftOffset = new System.Drawing.Point(11, 0);
            this.guna2TextBox2.IconLeftSize = new System.Drawing.Size(25, 25);
            this.guna2TextBox2.Location = new System.Drawing.Point(98, 401);
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PlaceholderText = "Password";
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.Size = new System.Drawing.Size(338, 45);
            this.guna2TextBox2.TabIndex = 1;
            this.guna2TextBox2.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // GTextBoxUsernameLogin
            // 
            this.GTextBoxUsernameLogin.Animated = true;
            this.GTextBoxUsernameLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.GTextBoxUsernameLogin.BorderRadius = 20;
            this.GTextBoxUsernameLogin.BorderThickness = 2;
            this.GTextBoxUsernameLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxUsernameLogin.DefaultText = "";
            this.GTextBoxUsernameLogin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxUsernameLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxUsernameLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxUsernameLogin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxUsernameLogin.FillColor = System.Drawing.Color.WhiteSmoke;
            this.GTextBoxUsernameLogin.FocusedState.BorderColor = System.Drawing.Color.SeaGreen;
            this.GTextBoxUsernameLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GTextBoxUsernameLogin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(74)))), ((int)(((byte)(75)))));
            this.GTextBoxUsernameLogin.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.GTextBoxUsernameLogin.IconLeft = global::Sparkle.Properties.Resources.user__1_;
            this.GTextBoxUsernameLogin.IconLeftOffset = new System.Drawing.Point(11, 0);
            this.GTextBoxUsernameLogin.IconLeftSize = new System.Drawing.Size(25, 25);
            this.GTextBoxUsernameLogin.Location = new System.Drawing.Point(98, 293);
            this.GTextBoxUsernameLogin.Name = "GTextBoxUsernameLogin";
            this.GTextBoxUsernameLogin.PlaceholderText = "Username\r\n";
            this.GTextBoxUsernameLogin.SelectedText = "";
            this.GTextBoxUsernameLogin.Size = new System.Drawing.Size(338, 45);
            this.GTextBoxUsernameLogin.TabIndex = 1;
            this.GTextBoxUsernameLogin.TextChanged += new System.EventHandler(this.GTextBoxUsernameLogin_TextChanged);
            // 
            // labelLoginWord
            // 
            this.labelLoginWord.AutoSize = true;
            this.labelLoginWord.Font = new System.Drawing.Font("Goudy Old Style", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.labelLoginWord.Location = new System.Drawing.Point(98, 126);
            this.labelLoginWord.Name = "labelLoginWord";
            this.labelLoginWord.Size = new System.Drawing.Size(242, 91);
            this.labelLoginWord.TabIndex = 0;
            this.labelLoginWord.Text = "Log in";
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.guna2Button1.BorderRadius = 9;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.guna2Button1.CustomBorderThickness = new System.Windows.Forms.Padding(2);
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Goudy Old Style", 9.75F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = global::Sparkle.Properties.Resources.enter;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageOffset = new System.Drawing.Point(25, 0);
            this.guna2Button1.Location = new System.Drawing.Point(98, 509);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(161, 51);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "Login";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // FormLoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sparkle.Properties.Resources.Main_Screen_Sparkle_Login2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1279, 800);
            this.Controls.Add(this.MainPanelShadowLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormLoginScreen_Load);
            this.MainPanelShadowLogin.ResumeLayout(false);
            this.MainPanelShadowLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm GBorderLessFormRaduis;
        private Guna.UI2.WinForms.Guna2ShadowPanel MainPanelShadowLogin;
        private System.Windows.Forms.Label labelLoginWord;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxUsernameLogin;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}

