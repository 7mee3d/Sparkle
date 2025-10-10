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

namespace Sparkle.User_Controls_Sparkle
{
    public partial class UserControlRemoveOrUpdateUsers : UserControl
    {

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
                            }
                            else
                                GTB.Enabled = flagEnableAllTextBoxiesOrNot;
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
 
        }
        public UserControlRemoveOrUpdateUsers()
        {
            InitializeComponent();
            EnabelAllTextBoxiesInPanel(false);
            GRadioButtonNone.Checked = true; 
        }
        const string kPATH_FILE_USER = "UsersInformation.txt";

        class stInformationUser
        {
            public string stUsername;
            public string stPassword;
            public int stNumberAttempt;

            //Flags 

            //Flag Remove 
            public bool IsUsernameToBeRemove = false; 


        }

        private List<string> LoadAllInformationUsersLinesFromFile() {


            if (!System.IO.File.Exists(kPATH_FILE_USER))
                System.IO.File.Create(kPATH_FILE_USER).Close();

            System.IO.StreamReader ReadAllLinesFromFileInfromationUsers = new System.IO.StreamReader(kPATH_FILE_USER);

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
                informationUserAfterSplitLine.AddRange(lineInformationOneUser.Split(new String[] { "||" }, StringSplitOptions.RemoveEmptyEntries)) ; 
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

            if (!System.IO.File.Exists(kPATH_FILE_USER))
                System.IO.File.Create(kPATH_FILE_USER).Close();

            System.IO.StreamWriter WriteAllInformationUserToFile = new System.IO.StreamWriter(kPATH_FILE_USER);

            foreach (stInformationUser infoOneUser in allInfroamtionUserStruct)
            {
                if(infoOneUser.IsUsernameToBeRemove == false )
                WriteAllInformationUserToFile.WriteLine(ConvertDataToLine(infoOneUser, "||"));
            }

            WriteAllInformationUserToFile.Close(); 

            
        }


        private bool isFoundTheUsernameInSystemSparkle (string username )
        {
            List<stInformationUser> allInfroamtionUserStruct = LoadAllInformationUsersAfterConvertLinesToDataListStructure();

            foreach (stInformationUser infoUser in allInfroamtionUserStruct)
            {
                if (infoUser.stUsername == username) return true; 
            }

            return false; 

        }
        private void CheckedChangedRadioButonModesInSystemSparkle(object sender, EventArgs e)
        {
            if (GRadioButtonRemoveMode.Checked)
            {

                GPanelFillInformationUsernameToUpdate.Visible = false;

            }


            if (GRadioButtonNone.Checked)
            {

                GPanelFillInformationUsernameToUpdate.Visible = false;

            }

            if (GRadioButtonUpdateMode.Checked)
            {

                GPanelFillInformationUsernameToUpdate.Visible = true;
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

            foreach (stInformationUser infoUser in allInfroamtionUserStruct)
            {
                if (username == infoUser.stUsername)
                {
                    infoUser.stUsername = GTextBoxNewUsername.Text;
                    if (isFoundTheUsernameInSystemSparkle(infoUser.stUsername)) return false;
                    else 
                        infoUser.stPassword = GTextBoxNewPasswordUsername.Text; 

                    SaveAllInformationUsersStructureToFile(allInfroamtionUserStruct);
                    return true;
                }
            }

            return false;

        }

        private void RemoveUserByUsernameAfterClickRemove ()
        {
            string username = GTextBoxUsername.Text;

            if (GRadioButtonNone.Checked)
            {
                MessageBox.Show($"Sorry This None Mode not perform any process [Remove or Update] in system Sparkle !", "Error None Mode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearAllTextBoxiesAndModes();
                return;
            }
            if (GRadioButtonUpdateMode.Checked)
            {
                MessageBox.Show($"Sorry This Update Mode not perform This process [Update] in system Sparkle ,Please Switch the Update Mode to Perform Update Information User !", "Error Update Mode", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClearAllTextBoxiesAndModes();
                return;
            }
            if (GRadioButtonRemoveMode.Checked)
            {
                if ((MessageBox.Show($"Are you sure you want to Remove this User [{username}] Information?", "Confirm Remove User", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK))
                    if (RemoveUsernameInSystemSparkle(username))
                        MessageBox.Show("Done");
                    else MessageBox.Show($"Sorry This Username [{username}] Not Found in System Sparkle Try Agian Enter Username Valid !", "Error Remove User", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            ClearAllTextBoxiesAndModes();
        }

           private void UpdateInformationUser ()
        {
            string username = GTextBoxUsername.Text;
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
                       // notifyIconRemoveAndUpdateClient.ShowBalloonTip(1500, "Notification Update Information Client", "This Client Information has been successfully Updated .If you would like to view the Updated information, click on the notification.", ToolTipIcon.Info);
                      MessageBox.Show("The Update was successful.", "Note Update Information User" , MessageBoxButtons.OK);
                    else
                        MessageBox.Show($"Sorry This New Username is Exsits or Not Found This username in the Sparkle System !", "Error Update User Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            ClearAllTextBoxiesAndModes();
        }

        private void GButtonSearchUsername_Click(object sender, EventArgs e)
        {
            string Username = GTextBoxUsername.Text;

            if (isFoundTheUsernameInSystemSparkle(Username) && GRadioButtonUpdateMode.Checked )
                EnabelAllTextBoxiesInPanel(true);
            else EnabelAllTextBoxiesInPanel(false);
        }

        private void GButtonRemoveUser_Click(object sender, EventArgs e)
        {
            RemoveUserByUsernameAfterClickRemove();
        }

        private void GButtonUpdateUser_Click(object sender, EventArgs e)
        {
            UpdateInformationUser();
        }
    }
}
