using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sparkle.User_Controls_Sparkle
{
    public partial class UserControlHistoryLoginSparkle : UserControl
    {
        public class stInformationUser
        {

            public string stUsername;
            public string stPassword;

            //DateTime Login Sparkle
            public string stDateTimeNowLoginSparkle;

        }

        public UserControlHistoryLoginSparkle()
        {
            InitializeComponent();
            pushAllInformationHistoryLoginSparkleToListView();
            setNumberHisrtoySparkleLoginToScreen();
        }

        //Constants
        private const string _kPATH_FILE_HISTORY_LOGIN_SPARKLE = "HistoryLoginSparkle.txt";
        private const int _KEY_CRYPT = 2;

       private bool areSameUsernameOrNot (string username , string partsOfUsername)
        {
            return (username.Contains(partsOfUsername));
        }

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

        private List<string> LoadLineInformationUsersHistoryLoginFromFile(string PathFileToLoadInformation)
        {
            List<string> informationUserLine = new List<string>();

            if (!System.IO.File.Exists(PathFileToLoadInformation))
                System.IO.File.Create(PathFileToLoadInformation).Close();

            System.IO.StreamReader ReadInformationAllUsers = new System.IO.StreamReader(PathFileToLoadInformation);

            string lineInformationOneUser = "";

            while ((lineInformationOneUser = ReadInformationAllUsers.ReadLine()) != null)
            {
                informationUserLine.Add(lineInformationOneUser);

            }

            ReadInformationAllUsers.Close();
            return informationUserLine;

        }
      
        private stInformationUser ConvertLineInformationUserHistoryLoginToDataStruct(List<string> InformationUserHistoryLoginSparkle )
        {
            stInformationUser informationUserOneHistoryLoginSparkle = new stInformationUser();

            informationUserOneHistoryLoginSparkle.stUsername = InformationUserHistoryLoginSparkle[0];
            informationUserOneHistoryLoginSparkle.stPassword = InformationUserHistoryLoginSparkle[1];

            if (InformationUserHistoryLoginSparkle.Count >= 2)
            {
                informationUserOneHistoryLoginSparkle.stDateTimeNowLoginSparkle = InformationUserHistoryLoginSparkle[2];
            }

            return informationUserOneHistoryLoginSparkle;

        }
       
        private List<string> SplitTheLineInformation(string LineInformation, string Separator)
        {

            List<string> splitInformationLineToParts = new List<string>();

            if (!string.IsNullOrEmpty(LineInformation))
            {
                splitInformationLineToParts.AddRange(LineInformation.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries));
            }

            return splitInformationLineToParts;
        }

        private List<stInformationUser> storeInformationAllUsersHistoryLoginSystemSparkleToStructure()
        {
            List<string> InformationUsersHistoryLoginSparkleString = LoadLineInformationUsersHistoryLoginFromFile(_kPATH_FILE_HISTORY_LOGIN_SPARKLE);
            List<stInformationUser> InformationAllUsersHistoryLoginSparkleStruct = new List<stInformationUser>();

            if (InformationUsersHistoryLoginSparkleString != null)
            {
                List<string> lineInfromationUser = new List<string>();
                stInformationUser informationUserHistoryLogSt = new stInformationUser();

                foreach (string lineInfoUserHistoryLog in InformationUsersHistoryLoginSparkleString)
                {
                    lineInfromationUser = SplitTheLineInformation(lineInfoUserHistoryLog, "$$$//$$$");
                    informationUserHistoryLogSt = ConvertLineInformationUserHistoryLoginToDataStruct(lineInfromationUser);
                    InformationAllUsersHistoryLoginSparkleStruct.Add(informationUserHistoryLogSt);
                }
            }

            return InformationAllUsersHistoryLoginSparkleStruct;
        }
    
        private void pushAllInformationHistoryLoginSparkleToListView ()
        {
            List<stInformationUser> AllInformationUsersHistoryLogin = storeInformationAllUsersHistoryLoginSystemSparkleToStructure();

            foreach (stInformationUser informationHistoryLog in AllInformationUsersHistoryLogin)
            {
                ListViewItem LVI = new ListViewItem(informationHistoryLog.stUsername);

                LVI.SubItems.Add(DecreyptPassword (informationHistoryLog.stPassword , _KEY_CRYPT));
                LVI.SubItems.Add(informationHistoryLog.stDateTimeNowLoginSparkle);

                ListViewHistoryLoginSparkle.Items.Add(LVI);
            }
            
        }

        private void pushAllInformationHistoryLoginSparkleToListViewAfterSearch(string partsOfUsernameToSearch, ref int numberHistoryUserLoginSparkle)
        {
            List<stInformationUser> AllInformationUsersHistoryLogin = storeInformationAllUsersHistoryLoginSystemSparkleToStructure();

            foreach (stInformationUser informationHistoryLog in AllInformationUsersHistoryLogin)
            {
                if (areSameUsernameOrNot(informationHistoryLog.stUsername.ToLower(), partsOfUsernameToSearch.ToLower()))
                {
                    ListViewItem LVI = new ListViewItem(informationHistoryLog.stUsername);

                    LVI.SubItems.Add(DecreyptPassword(informationHistoryLog.stPassword, _KEY_CRYPT));
                    LVI.SubItems.Add(informationHistoryLog.stDateTimeNowLoginSparkle);

                    ListViewHistoryLoginSparkle.Items.Add(LVI);
                }

                numberHistoryUserLoginSparkle = ListViewHistoryLoginSparkle.Items.Count;

            }
        }

        private void searchToUsernameHistoryLoginSparkleSystemOperation (string Username )
        {
         
            if (!string.IsNullOrEmpty(Username))
            {
                int numberOfHistoryLogUser = 0;
                ListViewHistoryLoginSparkle.Items.Clear();
                pushAllInformationHistoryLoginSparkleToListViewAfterSearch(Username, ref numberOfHistoryLogUser);
                numberLoginUserInSparkleSystem.Text = numberOfHistoryLogUser.ToString();
            }
            else
                MessageBox.Show(
                        "The Text Username Already Empty\nPlease Enter the Username to be Search in History Login"
                        , "Warning!! Search History Login"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning
                        );
        }
      
        private void searchTheHistoryLoginUsername()
        {
            string username = GTextBoxSearchHistoryLoginByUsername.Text;

            searchToUsernameHistoryLoginSparkleSystemOperation(Username:  username); 

        }
  
        private int numberHistoryLoginSparkle()
        {
            return (ListViewHistoryLoginSparkle.Items.Count); 
        }

        private void setNumberHisrtoySparkleLoginToScreen ()
        {
            LblNumberHistoryLoginSparkle.Text = numberHistoryLoginSparkle().ToString(); 
        }

        private void AfterClickTextBoxUsernameEnterToBeSearch()
        {

            if (!string.IsNullOrEmpty(GTextBoxSearchHistoryLoginByUsername.Text))
            {
                GTextBoxSearchHistoryLoginByUsername.Clear();
                pushAllInformationHistoryLoginSparkleToListView();
                numberLoginUserInSparkleSystem.Text = "0"; 
            }
        }
    
        
        //Draw Section 
        private void PaintTheLine(PaintEventArgs e)
        {
            Color WhiteGreen = Color.FromArgb(255, 4, 187, 156);

            Pen pen = new Pen(WhiteGreen);
            pen.Width = 4;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //Points Line
            Point p1 = new Point(0, 310);
            Point p2 = new Point(1200, 310);

            //Draw the Line
            e.Graphics.DrawLine(pen, p1, p2);
        }

        private void UserControlHistoryLoginSparkle_Paint(object sender, PaintEventArgs e)
        {
            PaintTheLine(e);
        }

        private void GButtonSearchByUsernameHistoryLogin_Click(object sender, EventArgs e)
        {
            searchTheHistoryLoginUsername();
        }

        private void GTextBoxSearchHistoryLoginByUsername_Click(object sender, EventArgs e)
        {
            AfterClickTextBoxUsernameEnterToBeSearch();
        }

        
    }
}
