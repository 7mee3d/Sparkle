using Guna.UI2.WinForms;
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

        private void ButtonClients_Click(object sender, EventArgs e)
        {
            UserControlClients UCC = new UserControlClients();
            addUserControlInThePaenl(UCC);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UserControlUsers UCU = new UserControlUsers();
            addUserControlInThePaenl(UCU);
        }

        private void GButtonClientListSection_Click(object sender, EventArgs e)
        {
            UserControlClientsList UCCL = new UserControlClientsList();
            addUserControlInThePaenl(UCCL);
        }

        private void GButtonUsersList_Click(object sender, EventArgs e)
        {
            UserControUsersList UCUL = new UserControUsersList();
            addUserControlInThePaenl(UCUL);
        }

        private void GButtonRemoveOrUpdateClientSection_Click(object sender, EventArgs e)
        {
            UserControlRemoveOrUpdateClients UCROUC = new UserControlRemoveOrUpdateClients();
            addUserControlInThePaenl(UCROUC);

        }

      
        private void GButtonRemoveOrUpdateUsers_Click(object sender, EventArgs e)
        {
            UserControlRemoveOrUpdateUsers UCROUU = new UserControlRemoveOrUpdateUsers();
            addUserControlInThePaenl(UCROUU);
        }

        private void GButtonNewOrder_Click(object sender, EventArgs e)
        {
            UserControlNewOrderSparkle UCNOS = new UserControlNewOrderSparkle();
            addUserControlInThePaenl(UCNOS);


        }

        private void GButtonShowAllOrderCarAndCarpet_Click(object sender, EventArgs e)
        {
            UserControlShowAllOrdersCarAndCarpet UCSAOCAC = new UserControlShowAllOrdersCarAndCarpet();

            addUserControlInThePaenl(UCSAOCAC);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
