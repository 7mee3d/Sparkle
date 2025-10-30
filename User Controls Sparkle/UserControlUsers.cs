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

namespace Sparkle.User_Controls_Sparkle
{
    public partial class UserControlUsers : UserControl
    {
        public UserControlUsers()
        {
            InitializeComponent();
        }

        //Constants
        private const string _kPATH_FILE_USER = @"../../Data_Sparkle/UsersInformation.txt";
        private const int _KEY_CRYPT = 2;
        short Permissions = 0;


        struct stInformationUser
        {
            public string stUsername;
            public string stPassword;
            public int stNumberAttempt;
            public short stpermission;

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

        private void setInitalControls()
        {

            foreach(Control outterControl in this.Controls)
            {
                if(outterControl is Guna2Panel G2P)
                {
                    foreach(Control innerControl in G2P.Controls)
                    {

                        if (innerControl is Guna2RadioButton G2RB)
                            G2RB.Checked = false;

                        if(innerControl is Guna2Panel G2B2 )
                        foreach (Control innerInnerCotrol in G2B2.Controls)
                        if (innerInnerCotrol is Guna2CheckBox G2CB)
                            G2CB.Checked = false;

                    }
                }
            }
            GPanelAddUserSectionPermissions.Visible = false; 
        }
    
        private string ConvertListSplitInformationUserToLine(List <string> informationUser , string Separator = "||")
        {
            string lineInformationUser = "";

            lineInformationUser += informationUser[0] + Separator;
            lineInformationUser += informationUser[1] + Separator;
            lineInformationUser += informationUser[2] + Separator;
            lineInformationUser += Convert.ToString(3);

            return lineInformationUser; 


        }

        private List<string> LoadTheAllInformationUserLinesInTheList ()
        {
            List<string> informationAllUserLines = new List<string>();

            if (!System.IO.File.Exists(_kPATH_FILE_USER))
                System.IO.File.Create(_kPATH_FILE_USER).Close() ;

            System.IO.StreamReader loadAllInformationUsersToList = new System.IO.StreamReader(_kPATH_FILE_USER); 

            string lineInformationUser = null;

            while ((lineInformationUser = loadAllInformationUsersToList.ReadLine()) != null)
            {
                informationAllUserLines.Add(lineInformationUser); 
            }
            loadAllInformationUsersToList.Close();

            return informationAllUserLines; 
        }

        private List<string> SplitLineInformationUser(string lineInformationOneUser)
        {
            List<string> SplitLineInformationUser = new List<string>();

            if (!string.IsNullOrEmpty(lineInformationOneUser))
            {
                SplitLineInformationUser.AddRange(lineInformationOneUser.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries));
            }

            return SplitLineInformationUser;

        }

        private stInformationUser ConvertLineToDataInformationUser (List<string> informationAfterSplitLine)
        {
            stInformationUser infoOneUser = new stInformationUser();

            if (informationAfterSplitLine.Count >= 3)
            {
                infoOneUser.stUsername = informationAfterSplitLine[0];
                infoOneUser.stPassword = informationAfterSplitLine[1];
                infoOneUser.stpermission = Convert.ToInt16(informationAfterSplitLine[2]);
                infoOneUser.stNumberAttempt = Convert.ToInt32(informationAfterSplitLine[3]);
            }

            return infoOneUser;
        }

        private List<stInformationUser> SaveAllInformationUserToListSturcture()
        {

            List<string> informationAllUserLines = LoadTheAllInformationUserLinesInTheList();
            List<stInformationUser> informationAllUsersData = new List<stInformationUser>();

            if(informationAllUserLines.Count > 0)
            {

                foreach(string lineInformationUser in informationAllUserLines)
                {
                    stInformationUser informationOneUser = new stInformationUser();
                    informationOneUser = ConvertLineToDataInformationUser(SplitLineInformationUser(lineInformationUser));
                    informationAllUsersData.Add(informationOneUser);

                }
            }
            return informationAllUsersData;
        }

        private void pushInformationUserAfterAddToFile (List<string> informationOneUser )
        {
            string lineInformationUser = ConvertListSplitInformationUserToLine(informationOneUser, "||");

            if (!System.IO.File.Exists(_kPATH_FILE_USER))
                System.IO.File.Create(_kPATH_FILE_USER).Close();

            System.IO.StreamWriter saveAllInformationLineUserToFile = new System.IO.StreamWriter(_kPATH_FILE_USER, true );

            if (!string.IsNullOrEmpty(lineInformationUser))
            {
                saveAllInformationLineUserToFile.WriteLine(lineInformationUser);
            }

            saveAllInformationLineUserToFile.Close(); 



             }

        private bool AreEqualTwoString (string str1 , string str2 )
        {
            return (str1 == str2);
        }

        private bool isExistsUsername(string username)
        {

            List<stInformationUser> infomationAllUsersInFile = SaveAllInformationUserToListSturcture(); 

            foreach(stInformationUser infoOneUser in infomationAllUsersInFile)
            {
                if (AreEqualTwoString (infoOneUser.stUsername , username)) return true; 
            }

            return false; 
        }

        private bool areExistsUsernameAdminInFile ()
        {

            List<stInformationUser> infomationAllUsersInFile = SaveAllInformationUserToListSturcture();

            foreach (stInformationUser infoOneUser in infomationAllUsersInFile)
            {
                if (infoOneUser.stUsername == "Admin") return true;
            }

            return false;
        }

        private string genarateThePasswordRandomlly()
        {
            Random RandNumber = new Random();

            string passwordRandom = ""; 
            for(int counter = 1; counter<= 4; counter++)
            {
                passwordRandom += Convert.ToString(RandNumber.Next(1, 9));

            }

            return passwordRandom;
        
        }

        private short addPermissionsAllSection()
        {
            short PermissionsInsideMethod = 0;

            if (GCheckBoxAddUserSpecialPermissionNewOrderSection.Checked)
                PermissionsInsideMethod += 1;

            if (GCheckBoxAddUserSpecialPermissionShowAllOrders.Checked)
                PermissionsInsideMethod += 2;

            if (GCheckBoxAddUserSpecialPermissionClientSection.Checked)
                PermissionsInsideMethod += 4;

            if (GCheckBoxAddUserSpecialPermissionClientListSection.Checked)
                PermissionsInsideMethod += 8;

            if (GCheckBoxAddUserSpecialPermissionRemoveUpdateClientSection.Checked)
                PermissionsInsideMethod += 16;

            if (GCheckBoxAddUserSpecialPermissionUsersSection.Checked)
                PermissionsInsideMethod += 32;

            if (GCheckBoxAddUserSpecialPermissionUsersListSection.Checked)
                PermissionsInsideMethod += 64;

            if (GCheckBoxAddUserSpecialPermissionRemoveUpdateUserSection.Checked)
                PermissionsInsideMethod += 128;

            if (GCheckBoxAddUserSpecialPermissionShowHistoryLoginSparkle.Checked)
                PermissionsInsideMethod += 256;


            return PermissionsInsideMethod;
        }

        private void setPermissions()
        {
            if ( GRadioButtonFullAccessAllSections.Checked) {

                GPanelAddUserSectionPermissions.Visible = false;
                Permissions = -1;
                return; 

            }

            if(GRadioButtonSpecialPremissions.Checked)
            {
                GPanelAddUserSectionPermissions.Visible = true;
                Permissions = addPermissionsAllSection();
            }
        }

        private void addNewUserToSparkle()
        {
            setPermissions();
            string username = GTextBoxUsername.Text;
            string password = GTextBoxPasswordUser.Text;
            

            List<string> informationUser = new List<string>();
            informationUser.Add(username);
            informationUser.Add(EncryptPassword(password, keyCrypt: _KEY_CRYPT));
            informationUser.Add(Permissions.ToString());


            if (!string.IsNullOrEmpty(username))
            {
                if (string.IsNullOrEmpty(password) && !isExistsUsername(username))
                {

                    informationUser[1] = genarateThePasswordRandomlly();
                    pushInformationUserAfterAddToFile(informationUser);
                    MessageBox.Show($"Username [{username}] Succssfully Add System Sparkle , Thank you", "Note Add new User", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return; 
                }

                if (areExistsUsernameAdminInFile() && username == "Admin")
                {
                    MessageBox.Show("Username [Admin] Already Exsits In the File Sparkle Not Allow add new Admin in the Sparkle, Try Add another user not Admin", "Note Warning Add new User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GTextBoxUsername.Clear();
                    GTextBoxUsername.Focus();
                }
                else
                {
                    if (!isExistsUsername(username))
                    {
                        pushInformationUserAfterAddToFile(informationUser);
                        MessageBox.Show($"Username [{username}] Succssfully Add System Sparkle , Thank you", "Note Add new User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Username [{username}] Already Exsits In the File Sparkle Not Allow add new User same Username in the Sparkle, Try Add another user not {username}", "Note Warning Add new User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        GTextBoxUsername.Clear();
                    }
                }
                setInitalControls();
            }
            else
            {
                MessageBox.Show("Please , Enter the Username & Password To Be add In The Sparkle System", "Note Error Add new User", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            GTextBoxUsername.Clear();
            GTextBoxPasswordUser.Clear();
        }

        private void ButtonAddNewUser_Click(object sender, EventArgs e)
        {
            addNewUserToSparkle();
        }

        private void GRadioButtonFullAccessAllSections_CheckedChanged(object sender, EventArgs e)
        {
            setPermissions();
        }

        private void GRadioButtonSpecialPremissions_CheckedChanged(object sender, EventArgs e)
        {
            setPermissions();
        }

       
    }
}
