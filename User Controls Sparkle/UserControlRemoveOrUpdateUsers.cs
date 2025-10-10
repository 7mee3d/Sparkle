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
        public UserControlRemoveOrUpdateUsers()
        {
            InitializeComponent();

            GRadioButtonNone.Checked = true; 
        }
        const string kPATH_FILE_USER = "UsersInformation.txt";

        struct stInformationUser
        {
            public string stUsername;
            public string stPassword;
            public int stNumberAttempt;

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

        private void SaveAllInformationUsersStructureToFile()
        {
            List<stInformationUser> allInfroamtionUserStruct = LoadAllInformationUsersAfterConvertLinesToDataListStructure();

            if (!System.IO.File.Exists(kPATH_FILE_USER))
                System.IO.File.Create(kPATH_FILE_USER).Close();

            System.IO.StreamWriter WriteAllInformationUserToFile = new System.IO.StreamWriter(kPATH_FILE_USER);

            foreach (stInformationUser infoOneUser in allInfroamtionUserStruct)
            {
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
     
    }
}
