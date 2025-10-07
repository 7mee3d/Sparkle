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
            this.ButtonLoginTheSparkle = new Guna.UI2.WinForms.Guna2Button();
            this.GTextBoxPasswordLogin = new Guna.UI2.WinForms.Guna2TextBox();
            this.GTextBoxUsernameLogin = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelLoginWord = new System.Windows.Forms.Label();
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
            this.MainPanelShadowLogin.Controls.Add(this.ButtonLoginTheSparkle);
            this.MainPanelShadowLogin.Controls.Add(this.GTextBoxPasswordLogin);
            this.MainPanelShadowLogin.Controls.Add(this.GTextBoxUsernameLogin);
            this.MainPanelShadowLogin.Controls.Add(this.labelLoginWord);
            this.MainPanelShadowLogin.FillColor = System.Drawing.Color.WhiteSmoke;
            this.MainPanelShadowLogin.Location = new System.Drawing.Point(691, 58);
            this.MainPanelShadowLogin.Name = "MainPanelShadowLogin";
            this.MainPanelShadowLogin.Radius = 20;
            this.MainPanelShadowLogin.ShadowColor = System.Drawing.Color.Black;
            this.MainPanelShadowLogin.ShadowDepth = 50;
            this.MainPanelShadowLogin.Size = new System.Drawing.Size(534, 688);
            this.MainPanelShadowLogin.TabIndex = 0;
            // 
            // ButtonLoginTheSparkle
            // 
            this.ButtonLoginTheSparkle.Animated = true;
            this.ButtonLoginTheSparkle.AnimatedGIF = true;
            this.ButtonLoginTheSparkle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.ButtonLoginTheSparkle.BorderRadius = 14;
            this.ButtonLoginTheSparkle.BorderThickness = 2;
            this.ButtonLoginTheSparkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLoginTheSparkle.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.ButtonLoginTheSparkle.CustomBorderThickness = new System.Windows.Forms.Padding(2);
            this.ButtonLoginTheSparkle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonLoginTheSparkle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonLoginTheSparkle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonLoginTheSparkle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonLoginTheSparkle.FillColor = System.Drawing.Color.Transparent;
            this.ButtonLoginTheSparkle.Font = new System.Drawing.Font("Goudy Old Style", 9.75F, System.Drawing.FontStyle.Bold);
            this.ButtonLoginTheSparkle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.ButtonLoginTheSparkle.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.ButtonLoginTheSparkle.HoverState.ForeColor = System.Drawing.Color.White;
            this.ButtonLoginTheSparkle.Image = global::Sparkle.Properties.Resources.enter;
            this.ButtonLoginTheSparkle.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ButtonLoginTheSparkle.ImageOffset = new System.Drawing.Point(25, 0);
            this.ButtonLoginTheSparkle.Location = new System.Drawing.Point(107, 460);
            this.ButtonLoginTheSparkle.Name = "ButtonLoginTheSparkle";
            this.ButtonLoginTheSparkle.Size = new System.Drawing.Size(161, 51);
            this.ButtonLoginTheSparkle.TabIndex = 2;
            this.ButtonLoginTheSparkle.Text = "Log in";
            this.ButtonLoginTheSparkle.Click += new System.EventHandler(this.ButtonLoginTheSparkle_Click);
            // 
            // GTextBoxPasswordLogin
            // 
            this.GTextBoxPasswordLogin.Animated = true;
            this.GTextBoxPasswordLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.GTextBoxPasswordLogin.BorderRadius = 20;
            this.GTextBoxPasswordLogin.BorderThickness = 2;
            this.GTextBoxPasswordLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GTextBoxPasswordLogin.DefaultText = "";
            this.GTextBoxPasswordLogin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GTextBoxPasswordLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GTextBoxPasswordLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxPasswordLogin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GTextBoxPasswordLogin.FillColor = System.Drawing.Color.WhiteSmoke;
            this.GTextBoxPasswordLogin.FocusedState.BorderColor = System.Drawing.Color.MediumSpringGreen;
            this.GTextBoxPasswordLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GTextBoxPasswordLogin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(74)))), ((int)(((byte)(75)))));
            this.GTextBoxPasswordLogin.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.GTextBoxPasswordLogin.IconLeft = global::Sparkle.Properties.Resources._lock;
            this.GTextBoxPasswordLogin.IconLeftOffset = new System.Drawing.Point(11, 0);
            this.GTextBoxPasswordLogin.IconLeftSize = new System.Drawing.Size(25, 25);
            this.GTextBoxPasswordLogin.Location = new System.Drawing.Point(107, 369);
            this.GTextBoxPasswordLogin.Name = "GTextBoxPasswordLogin";
            this.GTextBoxPasswordLogin.PlaceholderText = "Password";
            this.GTextBoxPasswordLogin.SelectedText = "";
            this.GTextBoxPasswordLogin.Size = new System.Drawing.Size(322, 45);
            this.GTextBoxPasswordLogin.TabIndex = 1;
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
            this.GTextBoxUsernameLogin.FocusedState.BorderColor = System.Drawing.Color.MediumSpringGreen;
            this.GTextBoxUsernameLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GTextBoxUsernameLogin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(74)))), ((int)(((byte)(75)))));
            this.GTextBoxUsernameLogin.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.GTextBoxUsernameLogin.IconLeft = global::Sparkle.Properties.Resources.user__1_;
            this.GTextBoxUsernameLogin.IconLeftOffset = new System.Drawing.Point(11, 0);
            this.GTextBoxUsernameLogin.IconLeftSize = new System.Drawing.Size(25, 25);
            this.GTextBoxUsernameLogin.Location = new System.Drawing.Point(107, 304);
            this.GTextBoxUsernameLogin.Name = "GTextBoxUsernameLogin";
            this.GTextBoxUsernameLogin.PlaceholderText = "Username\r\n";
            this.GTextBoxUsernameLogin.SelectedText = "";
            this.GTextBoxUsernameLogin.Size = new System.Drawing.Size(322, 45);
            this.GTextBoxUsernameLogin.TabIndex = 0;
            // 
            // labelLoginWord
            // 
            this.labelLoginWord.AutoSize = true;
            this.labelLoginWord.Font = new System.Drawing.Font("Garamond", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.labelLoginWord.Location = new System.Drawing.Point(92, 143);
            this.labelLoginWord.Name = "labelLoginWord";
            this.labelLoginWord.Size = new System.Drawing.Size(240, 90);
            this.labelLoginWord.TabIndex = 0;
            this.labelLoginWord.Text = "Log in";
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
            this.MainPanelShadowLogin.ResumeLayout(false);
            this.MainPanelShadowLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm GBorderLessFormRaduis;
        private Guna.UI2.WinForms.Guna2ShadowPanel MainPanelShadowLogin;
        private System.Windows.Forms.Label labelLoginWord;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxUsernameLogin;
        private Guna.UI2.WinForms.Guna2TextBox GTextBoxPasswordLogin;
        private Guna.UI2.WinForms.Guna2Button ButtonLoginTheSparkle;
    }
}

