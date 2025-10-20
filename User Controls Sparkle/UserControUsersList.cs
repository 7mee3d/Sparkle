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
            pushAllInformationUsersToListView();
            LblNumberUser.Text = numberUserInSystemSparkle().ToString(); 
        }

        //Path File
       private const string _kPATH_FILE_USER = "UsersInformation.txt";

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

            if (!System.IO.File.Exists(_kPATH_FILE_USER))
                System.IO.File.Create(_kPATH_FILE_USER).Close();

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

            if (!System.IO.File.Exists(_kPATH_FILE_USER))
                System.IO.File.Create(_kPATH_FILE_USER).Close();

            System.IO.StreamWriter saveAllInformationLineUserToFile = new System.IO.StreamWriter(_kPATH_FILE_USER, true);

            if (!string.IsNullOrEmpty(lineInformationUser))
            {
                saveAllInformationLineUserToFile.WriteLine(lineInformationUser);
            }

            saveAllInformationLineUserToFile.Close();



        }
    
        private void PaintTheLine(PaintEventArgs e)
        {
            Color WhiteGreen = Color.FromArgb(255, 4, 187, 156);

            Pen pen = new Pen(WhiteGreen);
            pen.Width = 4;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //Points Line
            Point p1 = new Point(0, 290);
            Point p2 = new Point(1200, 290);

            //Draw the Line
            e.Graphics.DrawLine(pen, p1, p2);
        }
      
        private void pushAllInformationUsersToListView ()
        {
            List<stInformationUser> informationAllUsersData = SaveAllInformationUserToListSturcture();

            for (int counter = 0; counter < informationAllUsersData.Count; counter++) {

            
                ListViewItem LVI = new ListViewItem(informationAllUsersData[counter].stUsername);
                LVI.SubItems.Add(DecreyptPassword (informationAllUsersData[counter].stPassword , 2));
                
                ListViewUsersLists.Items.Add(LVI);

                if (informationAllUsersData[counter].stUsername == "Admin")
                {
                    ListViewUsersLists.Items[counter].BackColor = Color.Red;
                    ListViewUsersLists.Items[counter].ForeColor = Color.White;
                }
            }

        }

        private bool SreachTheUsernameInListView (string username )
        {

            //Reset all back color and fore color list view 
            for (int counterOutSide = 0; counterOutSide < ListViewUsersLists.Items.Count; counterOutSide++)
            {
              
                ListViewUsersLists.Items[counterOutSide].BackColor = Color.White;
                ListViewUsersLists.Items[counterOutSide].ForeColor = Color.Black;

            }

            if (ListViewUsersLists.Items[0].Text == username)
            {
                ListViewUsersLists.Items[0].BackColor = Color.Yellow;
                ListViewUsersLists.Items[0].ForeColor = Color.Black;
                return true;
            }
            else
            {

                for (int counterInside = 0; counterInside < ListViewUsersLists.Items.Count; counterInside++)
                {
                    if (ListViewUsersLists.Items[counterInside].Text == username)
                    {
                        ListViewUsersLists.Items[counterInside].BackColor = Color.Yellow;
                        ListViewUsersLists.Items[counterInside].ForeColor = Color.Black;
                        return true;
                    }
                }

            }
            GTextBoxSearchUsersList.Clear();
            GTextBoxSearchUsersList.Focus(); 
            return false;

        }
    
        private void UserControUsersList_Load(object sender, EventArgs e)
        {
            pushAllInformationUsersToListView();
        }

        private void GButtonSearchByUsername_Click(object sender, EventArgs e)
        {
            string username = GTextBoxSearchUsersList.Text;

            if (!string.IsNullOrEmpty(username))
                if (SreachTheUsernameInListView(username)) { }
                else
                {
                    if (MessageBox.Show($"This Username [{username}] Not Found In Sparkle System Try enter Again", "Note Search By Username", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        GTextBoxSearchUsersList.Clear();
                        GTextBoxSearchUsersList.Focus();
                    }
                }

            else
                MessageBox.Show($"The Box Username Already empty\nPlease Enter the Username to be Search in Sparkle System", "Warning! Username Box Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);



        }

        private int numberUserInSystemSparkle()
        {
            return (ListViewUsersLists.Items.Count);
        }
     
        private void UserControUsersList_Paint(object sender, PaintEventArgs e)
        {
            PaintTheLine(e);
        }

        private void ListViewUsersLists_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
