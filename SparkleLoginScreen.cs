using Guna.UI2.WinForms;
using Sparkle.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sparkle
{
    //Information One User

    public partial class SparkleLoginScreen : Form
    {
        public SparkleLoginScreen()
        {
            InitializeComponent();

        }

        enum enViewImagePassword
        {
            ekSHOW_PASSWORD = 1 , 
            ekHIDE_PASSWORD = 2 
        }


        enViewImagePassword initalViewPassword = enViewImagePassword.ekSHOW_PASSWORD; 
        public class stInformationUser
        {

            public string stUsername;
            public string stPassword;
            public int numberAttempt;
            public short permission;

            //DateTime Login Sparkle
            public string stDateTimeNowLoginSparkle;

        }

        //Path File 
        private const string _kPATH_FILE_USERS_INFORMATION = "UsersInformation.txt";
        private const string _kPATH_FILE_HISTORY_LOGIN_SPARKLE = "HistoryLoginSparkle.txt";

        private const int _KEY_CRYPT = 2;
        private string DecreyptPassword(string password, int keyCrypt)
        {
            string passwordAfterDecrypt = "";
            foreach (char Character in password)
            {
                int ASCIICharacter = Convert.ToInt32(Character);
                int resultASCIIAfterDecryptPassword = ASCIICharacter - keyCrypt;
                passwordAfterDecrypt += Convert.ToChar(resultASCIIAfterDecryptPassword);
            }
            return passwordAfterDecrypt;
        }


      
        private void changeImageandShowOrHidePassword (Guna2CirclePictureBox PictureBoxViewPassword)
        {
            if(initalViewPassword == enViewImagePassword.ekSHOW_PASSWORD)
            {
                PictureBoxViewPassword.Image = Resources.eye_hide_image_;
                GTextBoxPasswordLogin.PasswordChar = '\0';
                initalViewPassword = enViewImagePassword.ekHIDE_PASSWORD;
            }
            else
            {

                PictureBoxViewPassword.Image = Resources.eye_show_gif_Image;
                GTextBoxPasswordLogin.PasswordChar = '*';
                initalViewPassword = enViewImagePassword.ekSHOW_PASSWORD;

            }
        }

        stInformationUser informationUser = new stInformationUser(); 
        private void ClearAlTextInTheTextBoxAfterClick(object sender)
        {
            Guna2TextBox GTextBox = (sender as Guna2TextBox);
            GTextBox.Text = "";

        }

        private List<string> LoadLineInformationUsersFromFile(string PathFileToLoadInformation )
        {
            List<string> informationUserLine = new List<string>();

            if (!System.IO.File.Exists(PathFileToLoadInformation))
            {
                System.IO.File.Create(PathFileToLoadInformation).Close();
            }

            System.IO.StreamReader ReadInformationAllUsers = new System.IO.StreamReader(PathFileToLoadInformation);

            string lineInformationOneUser = "";

            while ((lineInformationOneUser = ReadInformationAllUsers.ReadLine()) != null)
            {
                informationUserLine.Add(lineInformationOneUser);

            }

            ReadInformationAllUsers.Close();
            return informationUserLine;

        }

        private List<string> SplitTheLineInformation(string LineInformation , string Separator )
        {

            List<string> splitInformationLineToParts = new List<string>();

            if (!string.IsNullOrEmpty(LineInformation))
            {
                splitInformationLineToParts.AddRange(LineInformation.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries));
            }

            return splitInformationLineToParts;
        }

        private stInformationUser ConvertLineInformationUserToDataStruct(List<string> InformationUser)
        {
            stInformationUser informationUserOne = new stInformationUser();

            informationUserOne.stUsername = InformationUser[0];
            informationUserOne.stPassword = InformationUser[1];

            if (InformationUser.Count > 3)
            {
                informationUserOne.permission = Convert.ToInt16(InformationUser[2]);
                informationUserOne.numberAttempt = Convert.ToInt32(InformationUser[3]);
            }


            return informationUserOne;

        }
       
        private List<stInformationUser> storeInformationAllUserst()
        {
            List<string> InformationUserString = LoadLineInformationUsersFromFile(_kPATH_FILE_USERS_INFORMATION);
            List<stInformationUser> InformationAllUsersStruct = new List<stInformationUser>();

            if (InformationUserString != null)
            {
                List<string> lineInfromationUser = new List<string>();
                stInformationUser informationUserSt = new stInformationUser();

                foreach (string lineInfoUser in InformationUserString)
                {
                    lineInfromationUser = SplitTheLineInformation(lineInfoUser , "||");
                    informationUserSt = ConvertLineInformationUserToDataStruct(lineInfromationUser);
                    InformationAllUsersStruct.Add(informationUserSt);
                }
            }

            return InformationAllUsersStruct;
        }

        private string ConvertDataInformationUserHistoryLoginSparkleToLine(stInformationUser informationUser, string separator = "$$$//$$$")
        {

            string lineInformationHistoryLogin = "";
            lineInformationHistoryLogin += informationUser.stUsername + separator;
            lineInformationHistoryLogin += informationUser.stPassword + separator;
            lineInformationHistoryLogin += DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");


            return lineInformationHistoryLogin;
        }

     
        private bool areEqualSideStringCompare(string strOne, string strTwo)
        {
            return (strOne == strTwo);
        }

        private string ConvertDataInformationUserToLine(stInformationUser informationUser, string separator = "||")
        {

            string lineInformation = "";
            lineInformation += informationUser.stUsername + separator;
            lineInformation += informationUser.stPassword + separator;
            lineInformation += informationUser.permission + separator;
            lineInformation += informationUser.numberAttempt.ToString();

            return lineInformation;
        }

      
        private List<string> ConvertDataInformationAllUserToLineBeforePush(List<stInformationUser> informationUsers   )
        {
            List<string> informationUserLines = new List<string>();

            string line = "";

            foreach (stInformationUser infoOneUser in informationUsers)
            {
                line = ConvertDataInformationUserToLine(infoOneUser, "||" );
                if (line != null)
                    informationUserLines.Add(line);
            }

            return informationUserLines;
        }

        private void SaveAllDataInformationUsersInTheFile(List<string> informationUserLines)
        {
            if (!System.IO.File.Exists(_kPATH_FILE_USERS_INFORMATION))
                System.IO.File.Create(_kPATH_FILE_USERS_INFORMATION).Close();

            System.IO.StreamWriter saveLineInTheFile = new System.IO.StreamWriter(_kPATH_FILE_USERS_INFORMATION);

            foreach (string lineInformationUser in informationUserLines)
            {
                if (lineInformationUser != null)
                    saveLineInTheFile.WriteLine(lineInformationUser);
            }


            saveLineInTheFile.Close();


        }

        private void SaveAllDataHistoryLoginSparkleInTheFile(string historyLoginSparkleINformationOneUser)
        {
            if (!System.IO.File.Exists(_kPATH_FILE_HISTORY_LOGIN_SPARKLE))
                System.IO.File.Create(_kPATH_FILE_HISTORY_LOGIN_SPARKLE).Close();

            System.IO.StreamWriter saveLineInTheFile = new System.IO.StreamWriter(_kPATH_FILE_HISTORY_LOGIN_SPARKLE, true );

            if (historyLoginSparkleINformationOneUser != null)
                saveLineInTheFile.WriteLine(historyLoginSparkleINformationOneUser);

            saveLineInTheFile.Close();


        }

        private bool areFoundUsernameAndPassword(string username, string password, ref bool isFoundUsername , ref stInformationUser informationUser)
        {
            //Load all data to List 
            List<stInformationUser> informationAllUsers = storeInformationAllUserst();

            for (int counter = 0; counter < informationAllUsers.Count; counter++)
            {
                if (areEqualSideStringCompare(informationAllUsers[counter].stUsername, username))
                {
                    if (areEqualSideStringCompare(DecreyptPassword(informationAllUsers[counter].stPassword, keyCrypt: _KEY_CRYPT), password))
                    {
                        if (informationAllUsers[counter].numberAttempt > 0)
                        {
                            informationAllUsers[counter].numberAttempt = 3;
                            //Save All Change After the Login and reset the number attempt account to 3 atttempt original 
                            SaveAllDataInformationUsersInTheFile(ConvertDataInformationAllUserToLineBeforePush(informationAllUsers));
                            SaveAllDataHistoryLoginSparkleInTheFile(ConvertDataInformationUserHistoryLoginSparkleToLine(informationAllUsers[counter], "$$$//$$$"));
                            GLabelWariningLastAttemptAccount.Text = "";
                            informationUser = informationAllUsers[counter];
                            return true;
                        }
                        else
                        {

                            MessageBox.Show("Lock Account Login Sparkle,\nPlease Contact The Admin To Be UnLock Account ", "Note Login Sparkle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            GLabelWariningLastAttemptAccount.Text = "";
                        }
                    }
                    else
                    {

                        if (informationAllUsers[counter].numberAttempt == 2)
                            //Warning 
                            GLabelWariningLastAttemptAccount.Text = "Warning: Last attempt! Please enter the correct password.";


                        if (informationAllUsers[counter].numberAttempt > 1)
                        {
                            --informationAllUsers[counter].numberAttempt;
                        }
                        else
                        {

                            // MessageBox.Show("Lock Account Login Sparkle", "Note Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            informationAllUsers[counter].numberAttempt = 0;
                            GLabelWariningLastAttemptAccount.Text = "";
                        }

                    }
                    //Flag to username becouse the reset the password to entery defferant password to check
                    isFoundUsername = true;
                }

            }

            //Save All Change after to check in the file 
            SaveAllDataInformationUsersInTheFile(ConvertDataInformationAllUserToLineBeforePush(informationAllUsers ));
            //Login Faild in the account 
            return false;
        }
        FormMainScreenSparkleProgram FrmSparkleMainScreen;
        private void LoginSystemSparkle(string Username, string Password)
        {
            bool isFoundUsername = false;

            if (areFoundUsernameAndPassword(Username, Password, ref isFoundUsername , ref informationUser))
            {
                FrmSparkleMainScreen = new FormMainScreenSparkleProgram(informationUser);
                this.Hide();
                FrmSparkleMainScreen.Show();
            }

            if (isFoundUsername)
            {
                GTextBoxPasswordLogin.Clear();
                GTextBoxPasswordLogin.Focus();
            }
            else
            {
                GTextBoxUsernameLogin.Clear();
                GTextBoxPasswordLogin.Clear();
                GTextBoxUsernameLogin.Focus();
            }
        }

        private void ButtonLoginTheSparkle_Click(object sender, EventArgs e)
        {

            string username = GTextBoxUsernameLogin.Text.Trim();
            string password = GTextBoxPasswordLogin.Text.Trim();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                LoginSystemSparkle(Username: username, Password: password);
            }
            else
            {
                MessageBox.Show
                    ("The Username and Password is empty not have any information\n,Please enter the username and password To Login System Sparkle "
                    , "Warning!! Login System Sparkle"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);

                GTextBoxUsernameLogin.Focus();
            }


        }

        private void PictureBoxExitApplicationSparkle_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GCPictureBoxShowHideShowPassword_Click(object sender, EventArgs e)
        {
            changeImageandShowOrHidePassword(GCPictureBoxShowHideShowPassword);
        }
    }
}