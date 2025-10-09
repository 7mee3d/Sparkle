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
    public partial class UserControUsersList : UserControl
    {
        public UserControUsersList()
        {
            InitializeComponent();
        }

        const string kPATH_FILE_USER = "UsersInformation.txt";

        struct stInformationUser
        {
            public string stUsername;
            public string stPassword;
            public int stNumberAttempt;

        }
        private string ConvertListSplitInformationUserToLine(List<string> informationUser, string Separator = "||")
        {
            string lineInformationUser = "";

            lineInformationUser += informationUser[0] + Separator;
            lineInformationUser += informationUser[1] + Separator;
            lineInformationUser += Convert.ToString(3);

            return lineInformationUser;


        }

        private List<string> LoadTheAllInformationUserLinesInTheList()
        {
            List<string> informationAllUserLines = new List<string>();

            if (!System.IO.File.Exists(kPATH_FILE_USER))
                System.IO.File.Create(kPATH_FILE_USER).Close();

            System.IO.StreamReader loadAllInformationUsersToList = new System.IO.StreamReader(kPATH_FILE_USER);

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

        private stInformationUser ConvertLineToDataInformationUser(List<string> informationAfterSplitLine)
        {
            stInformationUser infoOneUser = new stInformationUser();

            if (informationAfterSplitLine.Count >= 3)
            {
                infoOneUser.stUsername = informationAfterSplitLine[0];
                infoOneUser.stPassword = informationAfterSplitLine[1];
                infoOneUser.stNumberAttempt = Convert.ToInt32(informationAfterSplitLine[2]);
            }

            return infoOneUser;
        }

        private List<stInformationUser> SaveAllInformationUserToListSturcture()
        {

            List<string> informationAllUserLines = LoadTheAllInformationUserLinesInTheList();
            List<stInformationUser> informationAllUsersData = new List<stInformationUser>();

            if (informationAllUserLines.Count > 0)
            {

                foreach (string lineInformationUser in informationAllUserLines)
                {
                    stInformationUser informationOneUser = new stInformationUser();
                    informationOneUser = ConvertLineToDataInformationUser(SplitLineInformationUser(lineInformationUser));
                    informationAllUsersData.Add(informationOneUser);

                }
            }
            return informationAllUsersData;
        }

        private void pushInformationUserAfterAddToFile(List<string> informationOneUser)
        {
            string lineInformationUser = ConvertListSplitInformationUserToLine(informationOneUser, "||");

            if (!System.IO.File.Exists(kPATH_FILE_USER))
                System.IO.File.Create(kPATH_FILE_USER).Close();

            System.IO.StreamWriter saveAllInformationLineUserToFile = new System.IO.StreamWriter(kPATH_FILE_USER, true);

            if (!string.IsNullOrEmpty(lineInformationUser))
            {
                saveAllInformationLineUserToFile.WriteLine(lineInformationUser);
            }

            saveAllInformationLineUserToFile.Close();



        }

        private void pushAllInformationUsersToListView ()
        {
            List<stInformationUser> informationAllUsersData = SaveAllInformationUserToListSturcture();

            for (int counter = 0; counter < informationAllUsersData.Count; counter++) {

            
                ListViewItem LVI = new ListViewItem(informationAllUsersData[counter].stUsername);
                LVI.SubItems.Add(informationAllUsersData[counter].stPassword);
                
                ListViewUsersLists.Items.Add(LVI);

                if (informationAllUsersData[counter].stUsername == "Admin")
                {
                    ListViewUsersLists.Items[counter].BackColor = Color.Yellow;
                    ListViewUsersLists.Items[counter].ForeColor = Color.Black;
                }
            }

        }

 
        private void UserControUsersList_Load(object sender, EventArgs e)
        {
            pushAllInformationUsersToListView();
        }
    }
}
