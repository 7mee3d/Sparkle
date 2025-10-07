using Sparkle.User_Controls_Sparkle;
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
    public partial class FormMainScreenSparkleProgram : Form
    {
        public FormMainScreenSparkleProgram()
        {
            InitializeComponent();
        }

        private void addUserControlInThePaenl (UserControl ControlUser )
        {
            ControlUser.Dock = DockStyle.Fill;
            PanelMainWelcomeSparkle.Controls.Clear();
            PanelMainWelcomeSparkle.Controls.Add(ControlUser);

            ControlUser.BringToFront(); 



        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonClients_Click(object sender, EventArgs e)
        {
            UserControlClients UCC = new UserControlClients();
            addUserControlInThePaenl(UCC);
        }
    }
}
