using Guna.UI2.WinForms;
using Sparkle.Properties;
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
        enum enPermission
        {
            ekNEW_ORDER = 1 ,
            ekSHOW_ALL_ORDERS = 2 ,
            ekCLIENTS = 4 ,
            ekCLIENTS_LIST = 8 ,
            ekREMOVE_UPDATE_CLIENTS = 16 ,
            ekUSERS = 32 ,
            ekUSERS_LIST = 64 ,
            ekREMOVE_UPDATE_USERS = 128 
            
        };

        private stInformationUser informationUserAfterLoginSparkle;

        public FormMainScreenSparkleProgram(stInformationUser informationuser)
        {
            InitializeComponent();
            informationUserAfterLoginSparkle = informationuser;
        }
      
        private void ShowMessageAccessDenied()
        {
            MessageBox.Show("Access Denied! Contact your\nAdmin To allow you to accessthis section.", "Warning Permission ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      
        private void timerSparkleSystemLogin_Tick(object sender, EventArgs e)
        {
            LabelDateNow.Text = DateTime.Now.ToString("dd/M/yyyy hh:mm:ss tt");
        }
      
        private bool isPassPermission(short numberPermission , enPermission permission )
        {
            return ((numberPermission & (ushort)permission) == (ushort)permission);
        }

        private void addUserControlInThePaenl (UserControl ControlUser )
        {
            ControlUser.Dock = DockStyle.Fill;
            PanelMainWelcomeSparkle.Controls.Clear();
            PanelMainWelcomeSparkle.Controls.Add(ControlUser);

            ControlUser.BringToFront();


        }

        private void ChangeBackgroundUserControlAccessDenied ()
        {
            PanelMainWelcomeSparkle.Controls.Clear();
            PanelMainWelcomeSparkle.BackgroundImage = Resources.Access_Denied__Sparkle;
            PanelMainWelcomeSparkle.BackgroundImageLayout = ImageLayout.Zoom;
            ShowMessageAccessDenied();

        }
    
        private void ButtonClients_Click(object sender, EventArgs e)
        {

            UserControlClients UCC = new UserControlClients();

            if (isPassPermission(informationUserAfterLoginSparkle.permission, enPermission.ekCLIENTS))
                addUserControlInThePaenl(UCC);

            else ChangeBackgroundUserControlAccessDenied();
        }

        private void GButtonUsers_Click(object sender, EventArgs e)
        {
            UserControlUsers UCU = new UserControlUsers();

            if (isPassPermission(informationUserAfterLoginSparkle.permission, enPermission.ekUSERS))
                addUserControlInThePaenl(UCU);

            else ChangeBackgroundUserControlAccessDenied();
        }

        private void GButtonClientListSection_Click(object sender, EventArgs e)
        {
            UserControlClientsList UCCL = new UserControlClientsList();

            if (isPassPermission(informationUserAfterLoginSparkle.permission, enPermission.ekCLIENTS_LIST))
                 addUserControlInThePaenl(UCCL);

            else ChangeBackgroundUserControlAccessDenied();

        }

        private void GButtonUsersList_Click(object sender, EventArgs e)
        {
            UserControUsersList UCUL = new UserControUsersList();
          
            if (isPassPermission(informationUserAfterLoginSparkle.permission, enPermission.ekUSERS_LIST))
                addUserControlInThePaenl(UCUL);
          
            else ChangeBackgroundUserControlAccessDenied();
        }

        private void GButtonRemoveOrUpdateClientSection_Click(object sender, EventArgs e)
        {
            UserControlRemoveOrUpdateClients UCROUC = new UserControlRemoveOrUpdateClients();

            if (isPassPermission(informationUserAfterLoginSparkle.permission, enPermission.ekREMOVE_UPDATE_CLIENTS))
                addUserControlInThePaenl(UCROUC);
          
            else ChangeBackgroundUserControlAccessDenied();

        }
      
        private void GButtonRemoveOrUpdateUsers_Click(object sender, EventArgs e)
        {
            UserControlRemoveOrUpdateUsers UCROUU = new UserControlRemoveOrUpdateUsers();

            if (isPassPermission(informationUserAfterLoginSparkle.permission, enPermission.ekREMOVE_UPDATE_USERS))
            addUserControlInThePaenl(UCROUU);
          
            else ChangeBackgroundUserControlAccessDenied(); 

        }

        private void GButtonNewOrder_Click(object sender, EventArgs e)
        {
            UserControlNewOrderSparkle UCNOS = new UserControlNewOrderSparkle();

            if (isPassPermission(informationUserAfterLoginSparkle.permission, enPermission.ekNEW_ORDER))
                addUserControlInThePaenl(UCNOS);
          
            else ChangeBackgroundUserControlAccessDenied();

        }

        private void GButtonShowAllOrderCarAndCarpet_Click(object sender, EventArgs e)
        {
            UserControlShowAllOrdersCarAndCarpet UCSAOCAC = new UserControlShowAllOrdersCarAndCarpet();

            if (isPassPermission(informationUserAfterLoginSparkle.permission, enPermission.ekSHOW_ALL_ORDERS)) 
            addUserControlInThePaenl(UCSAOCAC);
           
            else
                ChangeBackgroundUserControlAccessDenied();

        }

        private void FormMainScreenSparkleProgram_Load(object sender, EventArgs e)
        {
            //Test The Information Passing form Main Screen from Login 
            // MessageBox.Show($"Welcome [{informationUserAfterLoginSparkle.stUsername}]");
            LbaelUsernameAfterLogin.Text = informationUserAfterLoginSparkle.stUsername; 
        }
     
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

       
    }
}
