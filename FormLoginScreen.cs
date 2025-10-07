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

        const string kPATH_FILE = "UsersInformation.txt";

        struct stInformationUser
        {
            
           public string stUsername;
            public string stPassword;
            public int numberAttempt ;

        }
        private void ClearAlTextInTheTextBoxAfterClick(object sender)
        {
            Guna2TextBox GTextBox = (sender as Guna2TextBox  );
            GTextBox.Text = "";

        }
        private List<string> LoadLineInformationUsersFromFile ()
        {
            List<string> informationUserLine = new List<string>();

            if (!System.IO.File.Exists(kPATH_FILE))
            {
                System.IO.File.Create(kPATH_FILE).Close(); 
            }

            System.IO.StreamReader ReadInformationAllUsers = new System.IO.StreamReader(kPATH_FILE);

            string lineInformationOneUser = "";

            while ((lineInformationOneUser = ReadInformationAllUsers.ReadLine().ToString()) != null)
            {
                informationUserLine.Add(lineInformationOneUser);
                    
                }

            return informationUserLine; 

        }

        private List<string> SplitTheLineInformation ( string LineInformation ){

            List<string> splitInformationLineToParts = new List<string>();

            if (!string.IsNullOrEmpty(LineInformation))
            {
                splitInformationLineToParts.AddRange(LineInformation.Split(new string[]{ "||" }, StringSplitOptions.RemoveEmptyEntries));
            }

            return splitInformationLineToParts;
    }


        private stInformationUser ConvertLineInformationUserToDataStruct (List<string> InformationUser)
        {
            stInformationUser informationUserOne = new stInformationUser();

            informationUserOne.stUsername = InformationUser[0];
            informationUserOne.stPassword = InformationUser[1];

            if(InformationUser.Count > 2 )
            informationUserOne.numberAttempt = Convert.ToInt32(InformationUser[2]); 


            return informationUserOne;

        }

        private List<stInformationUser> storeInformationAllUserst ()
        {
            List<string> InformationUserString = LoadLineInformationUsersFromFile();
            List<stInformationUser> InformationAllUsersStruct = new List<stInformationUser>(); 

            if (InformationUserString != null)
            {
                List <string> lineInfromationUser = new List<string>() ;
                stInformationUser informationUserSt = new stInformationUser(); 

                foreach(string lineInfoUser in InformationUserString)
                {
                    lineInfromationUser = SplitTheLineInformation(lineInfoUser);
                    informationUserSt = ConvertLineInformationUserToDataStruct(lineInfromationUser);
                    InformationAllUsersStruct.Add(informationUserSt);
                }
            }

            return InformationAllUsersStruct; 
        }

        private bool areEqualSideStringCompare(string strOne , string strTwo)
        {
            return (strOne == strTwo);
        }
        private string ConvertDataInformationUserToLine(stInformationUser informationUser, string separator = "||")
        {

            string lineInformation = "";
            lineInformation += informationUser.stUsername + separator;
            lineInformation += informationUser.stPassword + separator;
            lineInformation += informationUser.numberAttempt.ToString();

            return lineInformation;
        }

        private List<string> ConvertDataInformationAllUserToLineBeforePush(List<stInformationUser> informationUsers)
        {
            List<string> informationUserLines = new List<string>();

            string line = "";

            foreach (stInformationUser infoOneUser in informationUsers)
            {
                line = ConvertDataInformationUserToLine(infoOneUser, "||");
                if (line != null)
                    informationUserLines.Add(line);
            }

            return informationUserLines;
        }
        private void SaveAllDataInformationUsersInTheFile(List<string> informationUserLines)
        {
            if (!System.IO.File.Exists(kPATH_FILE))
                System.IO.File.Create(kPATH_FILE).Close();

            System.IO.StreamWriter saveLineInTheFile = new System.IO.StreamWriter(kPATH_FILE);

            foreach (string lineInfoUser in informationUserLines)
            {
                if (lineInfoUser != null)
                    saveLineInTheFile.WriteLine(lineInfoUser);
            }

            saveLineInTheFile.Close();


        }
        private bool areFoundUsernameAndPassword(string username , string password )
        {

            List<stInformationUser> informationAllUsers = storeInformationAllUserst();

            foreach (stInformationUser infoUser in informationAllUsers)
            {
                if (areEqualSideStringCompare(infoUser.stUsername, username) &&
                    areEqualSideStringCompare(infoUser.stPassword, password)
                    ) return true; 
            }

            return false; 
        }
     
        
       
        private void ButtonLoginTheSparkle_Click(object sender, EventArgs e)
        {
            string username = GTextBoxUsernameLogin.Text;
            string password = GTextBoxPasswordLogin.Text;

            if (areFoundUsernameAndPassword(username, password))
                MessageBox.Show("Login Sccessfully Sparkle", "Note Login");
            else
                MessageBox.Show("Faild Login Sccessfully Sparkle", "Note Login");

            GTextBoxUsernameLogin.Clear();
            GTextBoxPasswordLogin.Clear();

            GTextBoxUsernameLogin.Focus(); 
        }
    }
}
