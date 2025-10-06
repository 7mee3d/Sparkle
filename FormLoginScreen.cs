using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparkle
{
    public partial class FormLoginScreen : Form
    {
        public FormLoginScreen()
        {
            InitializeComponent();
      
        }

        private void ClearAlTextInTheTextBoxAfterClick(object sender)
        {
            Guna2TextBox GTextBox = (sender as Guna2TextBox  );
            GTextBox.Text = "";

        }
        private void FormLoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void GTextBoxUsernameLogin_TextChanged(object sender, EventArgs e)
        {
           // ClearAlTextInTheTextBoxAfterClick(sender); 
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void MainPanelShadowLogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
