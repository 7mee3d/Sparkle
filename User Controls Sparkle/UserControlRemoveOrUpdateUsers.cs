using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sparkle.User_Controls_Sparkle
{
    public partial class UserControlRemoveOrUpdateUsers : UserControl
    {
        //File Path
        const string _kPATH_FILE_USER = "UsersInformation.txt";
        private const int _KEY_CRYPT = 2;


        //Information One User 
        class stInformationUser
        {
            public string stUsername;
            public string stPassword;
            public int stNumberAttempt;

            //Flags 

            //Flag Remove 
            public bool IsUsernameToBeRemove = false;


        }


        // ------------------------ [ Start Genaric Method ] ----------------------

        private void EnabelAllTextBoxiesInPanel (bool flagEnableAllTextBoxiesOrNot = true)
        {

            foreach (Control outterControl in this.Controls )
            {
                if(outterControl is Guna2Panel GP )
                {
                    foreach (Control innerControl in GP.Controls)
                    {

                        if (innerControl is Guna2TextBox GTB)
                        {
                            if (GTB == GTextBoxUsername)
                            {
                                GTB.Enabled = true;
                            }else if (GTB == GTextBoxNewUsername)
                            {
                                GTB.Enabled = false;

                            }
                        
                        else if (GTB == GTextBoxNewPasswordUsername)
                        {
                            GTB.Enabled = false;

                        }

                        else
                            {
                                GTB.Enabled = flagEnableAllTextBoxiesOrNot;
                            }
                        }
                    }
                }
            }
        }

        private void ClearAllTextBoxiesAndModes()
        {
            GRadioButtonNone.Checked = true;
            GTextBoxNewUsername.Clear();
            GTextBoxNewPasswordUsername.Clear();
            GRadioButtonLockAccount.Checked = false;
            GRadioButtonUnLockAccount.Checked = false;
            GTextBoxUsername.Clear();
            EnabelAllTextBoxiesInPanel(false);
            LabelStatusAccountLockOrUnLock.Text = "";

        }
       
        public UserControlRemoveOrUpdateUsers()
        {
            InitializeComponent();
            EnabelAllTextBoxiesInPanel(false);
            GRadioButtonNone.Checked = true;
        }


        private string EncryptPassword(string password, int keyCrypt)
        {
            string passwordAfterEncrypt = "";

            foreach (char Character in password)
            {
                int ASCIICharacter = Convert.ToInt32(Character);
                int resultAfterEncryptPassword = ASCIICharacter + keyCrypt;
                passwordAfterEncrypt += Convert.ToChar(resultAfterEncryptPassword);
            }

            return passwordAfterEncrypt;
        }


        // ------------------------ [ End Genaric Method ] ----------------------


        // ------------------------ [ Start I/O Method ] ----------------------

        private List<string> LoadAllInformationUsersLinesFromFile() {


            if (!System.IO.File.Exists(_kPATH_FILE_USER))
                System.IO.File.Create(_kPATH_FILE_USER).Close();

            System.IO.StreamReader ReadAllLinesFromFileInfromationUsers = new System.IO.StreamReader(_kPATH_FILE_USER);

            List<string> allInformationUsersLinesAfterReadInfoFromFile = new List<string>(); 

            string lineInformationOneUser = ""; 

            while((lineInformationOneUser = ReadAllLinesFromFileInfromationUsers.ReadLine() )!= null)
            {
                allInformationUsersLinesAfterReadInfoFromFile.Add(lineInformationOneUser); 
            }

            ReadAllLinesFromFileInfromationUsers.Close();

            return allInformationUsersLinesAfterReadInfoFromFile; 

        }

        private stInformationUser ConvertInformationUserLineToData (List<string> informationOneUserString)
        {

            stInformationUser informationUserStructure = new stInformationUser();

            informationUserStructure.stUsername = informationOneUserString[0];
            informationUserStructure.stPassword = informationOneUserString[1];

            informationUserStructure.stNumberAttempt = Convert.ToInt32( informationOneUserString[2]);

            return informationUserStructure;

        }

        private  List<string> SplitLineINfomationUserToListInfo (string lineInformationOneUser ) {

            List<string> informationUserAfterSplitLine = new List<string>(); 

            if (!string.IsNullOrEmpty(lineInformationOneUser))
            {
                informationUserAfterSplitLine.AddRange(
                    lineInformationOneUser.Split(new String[] { "||" }, StringSplitOptions.RemoveEmptyEntries)
                    ) ; 
            }

            return informationUserAfterSplitLine; 

        }

        private List<stInformationUser> LoadAllInformationUsersAfterConvertLinesToDataListStructure()
        {
            List<string> linesInformationUsersList = LoadAllInformationUsersLinesFromFile();
            List<stInformationUser> informationUsersAfterConvertLineToData = new List<stInformationUser>(); 

            foreach (string lineInformationOneUser in linesInformationUsersList)
            {
                informationUsersAfterConvertLineToData.Add(ConvertInformationUserLineToData(SplitLineINfomationUserToListInfo((lineInformationOneUser))));
            }

            return informationUsersAfterConvertLineToData;
        }

        private string ConvertDataToLine (stInformationUser informationOneUser , string Separator = "||")
        {

            string  lineInformationUser = "";

            lineInformationUser += informationOneUser.stUsername + Separator;
            lineInformationUser += informationOneUser.stPassword + Separator;
            lineInformationUser += informationOneUser.stNumberAttempt;

            return lineInformationUser; 

        }

        private void SaveAllInformationUsersStructureToFile(List<stInformationUser> allInfroamtionUserStruct)
        {

            if (!System.IO.File.Exists(_kPATH_FILE_USER))
                System.IO.File.Create(_kPATH_FILE_USER).Close();

            System.IO.StreamWriter WriteAllInformationUserToFile = new System.IO.StreamWriter(_kPATH_FILE_USER);

            foreach (stInformationUser infoOneUser in allInfroamtionUserStruct)
            {
                if(infoOneUser.IsUsernameToBeRemove == false )
                WriteAllInformationUserToFile.WriteLine(ConvertDataToLine(infoOneUser, "||"));
            }

            WriteAllInformationUserToFile.Close(); 

            
        }


        // ------------------------ [ End I/O Method ] ----------------------



        // ------------------------ [ Start [ Remove - Update - Search Method ] ] ----------------------

        stInformationUser informationUser = new stInformationUser();

        private void showAllInformationUserBeforeRemove (stInformationUser informationU)
        {
            GTextBoxUsernameRemoveSectionUser.Text = informationU.stUsername;
            GTextBoxPasswordRemoveSectionUser.Text = informationU.stPassword; 
        }

        private bool chnagePasswordOrNot ()
        {
            if(GRadioButtonChangePassword.Checked )
            {
                GTextBoxNewPasswordUsername.Enabled = true;
                return true; 
            }else
            {
                GTextBoxNewPasswordUsername.Enabled = false;
                return false;

            }
        }
     
        private bool isFoundTheUsernameInSystemSparkle (string username , ref stInformationUser informationUser )
        {
            List<stInformationUser> allInfroamtionUserStruct = LoadAllInformationUsersAfterConvertLinesToDataListStructure();

            foreach (stInformationUser infoUser in allInfroamtionUserStruct)
            {
                if (infoUser.stUsername == username) {
                    informationUser = infoUser;
                    return true; 
                }
            }

            return false; 

        }
      
        private void CheckedChangedRadioButonModesInSystemSparkle(object sender, EventArgs e)
        {
            if (GRadioButtonRemoveMode.Checked)
            {
                GPanelFillInformationUsernameToUpdate.Visible = false;
                GPnaelInformationUserNotEnableReoveSection.Visible = true;

            }

            if (GRadioButtonNone.Checked)
            {
                GPanelFillInformationUsernameToUpdate.Visible = false;
                GPnaelInformationUserNotEnableReoveSection.Visible = false;

            }

            if (GRadioButtonUpdateMode.Checked)
            {
                GPanelFillInformationUsernameToUpdate.Visible = true;
                GPnaelInformationUserNotEnableReoveSection.Visible = false;

            }

        }

        private bool RemoveUsernameInSystemSparkle  (string username )
        {
            List<stInformationUser> allInfroamtionUserStruct = LoadAllInformationUsersAfterConvertLinesToDataListStructure();

            foreach (stInformationUser infoUser in allInfroamtionUserStruct)
            {
                if(username == infoUser.stUsername )
                {
                    infoUser.IsUsernameToBeRemove = true;
                    SaveAllInformationUsersStructureToFile(allInfroamtionUserStruct);
                    return true; 
                }
            }

            return false; 

        }
     
        private bool ModifyInformationUser(string username)
        {
            List<stInformationUser> allInfroamtionUserStruct = LoadAllInformationUsersAfterConvertLinesToDataListStructure();

            string lastPassword = "";
            foreach (stInformationUser infoUser in allInfroamtionUserStruct)
            {
                if (username == infoUser.stUsername)
                {
                    lastPassword = infoUser.stPassword;
                   GTextBoxNewUsername.Text = infoUser.stUsername ;
                    if (chnagePasswordOrNot())
                        infoUser.stPassword = EncryptPassword(GTextBoxNewPasswordUsername.Text, keyCrypt: _KEY_CRYPT);
                    else
                        infoUser.stPassword = lastPassword; 

                    if (GRadioButtonLockAccount.Checked)
                        infoUser.stNumberAttempt = 0;
                    else
                        infoUser.stNumberAttempt = 3; 

                        SaveAllInformationUsersStructureToFile(allInfroamtionUserStruct);
                    return true;
                }
            }

            return false;

        }

        private void RemoveUserByUsernameAfterClickRemove(string username)
        {

            string usernameTemp = username;

            if (GRadioButtonNone.Checked)
            {
                MessageBox.Show
                    ($"Sorry This None Mode not perform any process [Remove or Update] in system Sparkle !"
                    , "Error None Mode"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                ClearAllTextBoxiesAndModes();
                return;
            }
            if (GRadioButtonUpdateMode.Checked)
            {

                MessageBox.Show
                    ($"Sorry This Update Mode not perform This process [Update] in system Sparkle ,Please Switch the Update Mode to Perform Update Information User !"
                    , "Error Update Mode"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                ClearAllTextBoxiesAndModes();
                return;
            }
            if (GRadioButtonRemoveMode.Checked)
            {

                if (GTextBoxUsernameRemoveSectionUser.Text != "")
                {
                    if (GTextBoxUsernameRemoveSectionUser.Text != "Admin")
                    {
                        if ((MessageBox.Show($"Are you sure you want to Remove this User [{username}] Information?", "Confirm Remove User", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK))
                            if (RemoveUsernameInSystemSparkle(username))
                            {

                                MessageBox.Show
                                    ($"Successfully Remove This Username [{usernameTemp}] "
                                    , "Remove Username From System Spakle"
                                    , MessageBoxButtons.OK
                                    , MessageBoxIcon.Information);
                            }
                            else
                            {

                                MessageBox.Show
                                            ($"Sorry This Username [{username}] Not Found in System Sparkle Try Agian Enter Username Valid !"
                                            , "Error Remove User"
                                            , MessageBoxButtons.OK
                                            , MessageBoxIcon.Error);
                            }


                    }
                    else
                    {
                        MessageBox.Show
                                         ($"Sorry This Username [{username}] Not Remove Becouse This username is Admin all System Connot Be Remove in system !"
                                         , "Error Remove User"
                                         , MessageBoxButtons.OK
                                         , MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    MessageBox.Show
                                       ($"Warning!! You Must Search The Username To Be Remove , Go Write Username Then Click Search Then Remove Username.."
                                       , "Error Remove User"
                                       , MessageBoxButtons.OK
                                       , MessageBoxIcon.Warning);
                }
                ClearAllTextBoxiesAndModes();
            }
        }

        private string isAccountLock (string username )
        {
            List<stInformationUser> allInfroamtionUserStruct = LoadAllInformationUsersAfterConvertLinesToDataListStructure();

            foreach (stInformationUser infoUser in allInfroamtionUserStruct)
            {
                if (username == infoUser.stUsername)
                {
                    if (infoUser.stNumberAttempt > 0) { 
                        GRadioButtonUnLockAccount.Checked = true;
                        return "UnLock";
                    }
                    else
                    {
                        GRadioButtonLockAccount.Checked = true;
                        return "Lock";

                    }
                }
            }
            return "None";
       
        }
   
        private void UpdateInformationUser(string username) {
      
            if (GRadioButtonNone.Checked)
            {
                MessageBox.Show($"Sorry This None Mode not perform any process [Remove or Update]in system Sparkle !", "Error None Mode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearAllTextBoxiesAndModes();
                return;
            }


            if (GRadioButtonUpdateMode.Checked)
            {
                if (MessageBox.Show($"Are you sure you want to Update this This User [{username}] Information?", "Confirm Update Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {

                    if (ModifyInformationUser(username))
                    {
                        // notifyIconRemoveAndUpdateClient.ShowBalloonTip(1500, "Notification Update Information Client", "This Client Information has been successfully Updated .If you would like to view the Updated information, click on the notification.", ToolTipIcon.Info);
                        MessageBox.Show("The Update was successful.", "Note Update Information User", MessageBoxButtons.OK);
                   
                    }
                    else
                        MessageBox.Show($"Sorry This New Username is Exsits or Not Found This username in the Sparkle System !", "Error Update User Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            ClearAllTextBoxiesAndModes();
        }

        private void GButtonSearchUsername_Click(object sender, EventArgs e)
        {
            string Username = GTextBoxUsername.Text;
            if (!string.IsNullOrEmpty(Username))
            {
                if (isFoundTheUsernameInSystemSparkle(Username , ref informationUser ) )
                {
                    if(GRadioButtonRemoveMode.Checked)
                        showAllInformationUserBeforeRemove(informationUser);

                    GTextBoxNewUsername.Text = Username;
                    string statusAccount = isAccountLock(Username);
                    LabelStatusAccountLockOrUnLock.Text = $"The Account is [{statusAccount}] , Is he change status Account ?";
                   
                }
                else EnabelAllTextBoxiesInPanel(false);
            }
            else
            {
              MessageBox.Show
                    ($"Warning!! The Username is empty , Please Try to fill username to be Search "
                    , "Error Update User Information"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);

            }

        }
     
        private void GButtonRemoveUser_Click(object sender, EventArgs e)
        {
            string Username = GTextBoxUsername.Text;
            if (!string.IsNullOrEmpty(Username)) {
                RemoveUserByUsernameAfterClickRemove(username: Username);
            }
            else
            {
                MessageBox.Show
                    ($"Warning!! The Username is empty , Please Try to fill username to be Update Information User"
                    , "Error Update User Information"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);

            }

        }

        private void GButtonUpdateUser_Click(object sender, EventArgs e)
        {
            string Username = GTextBoxUsername.Text;

            if (!string.IsNullOrEmpty(Username))
            {
                UpdateInformationUser(username: Username);
            }
            else
            {
                MessageBox.Show
                    ($"Warning!! The Username is empty , Please Try to fill username to be Update Information User"
                    , "Error Update User Information"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
            }
        }

     
        // ------------------------ [ End [ Remove - Update - Search Method ] ] ----------------------



        // ------------------------ [ Start Draw Section  ] ----------------------
    
        private void DrawLineOfUserControlRemoveAndUpdate(PaintEventArgs e)
        {

            Color whiteGreen = Color.FromArgb(255, 4, 187, 156);

            Pen pen = new Pen(whiteGreen);

            pen.Width = 4;

            Point p1 = new Point(0, 430);
            Point p2 = new Point(687, 430);

            e.Graphics.DrawLine(pen, p1, p2);
        }

        private void UserControlRemoveOrUpdateUsers_Paint(object sender, PaintEventArgs e)
        {
            DrawLineOfUserControlRemoveAndUpdate(e);
        }
    
        private void changeStateRadioButtonChangePassword(object sender, EventArgs e)
        {
            if (GRadioButtonChangePassword.Checked)
                GTextBoxNewPasswordUsername.Enabled = true;
          
            if(GRadioButtonUnChangePassword.Checked)
                GTextBoxNewPasswordUsername.Enabled = false;

        }



        // ------------------------ [ End Draw Section  ] ----------------------

    }
}
