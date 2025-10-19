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
 
    public partial class UserControlClients : UserControl
    {
        public UserControlClients()
        {
            InitializeComponent();
            GTextBoxIDClient.Enabled = false;
            GTextBoxIDClient.Text = (getLastIDClientInList() + 1).ToString();

        }

        struct stInformationClient
        {
            public string stID; 
            public string stName; 
            public string stAddress; 
            public string stEmail; 
            public string stPhone; 
        }
   
        //Path File
        private const string _kPATH_FILE_CLIENT = "InformationClients.txt";

        private void ResetAllTextBoxToDefault()
        {

            foreach(Control OutterControl in this.Controls)
                if(OutterControl is Guna2Panel G2P)
                    foreach(Control innerControl in OutterControl.Controls)
                        if (innerControl is Guna2TextBox G2TB)
                            G2TB.Clear();


            errorProviderFormClients.Clear();
            CorrectProviderAddCleint.Clear();
        }
   
        private string ConvertSeriseStringToLine(List<string> informationClient, string Separator = ";||;")
        {
            string lineInfromationClient = "";

            lineInfromationClient += informationClient[0] + Separator;
            lineInfromationClient += informationClient[1] + Separator;
            lineInfromationClient += informationClient[2] + Separator;
            lineInfromationClient += informationClient[3] + Separator;
            lineInfromationClient += informationClient[4];

            return lineInfromationClient;
        }

        private void LoadLineInformationClientToFile(string lineInformationClient )
        {
            if (!System.IO.File.Exists(_kPATH_FILE_CLIENT))
                System.IO.File.Create(_kPATH_FILE_CLIENT).Close();

            System.IO.StreamWriter LoadInformationToFile = new System.IO.StreamWriter(_kPATH_FILE_CLIENT, true ); //True -> Append the information to push file no clear all info client 

            if (!String.IsNullOrEmpty(lineInformationClient))
            {
                LoadInformationToFile.WriteLine(lineInformationClient);
            }

            LoadInformationToFile.Close(); 

        }
     
        private List <string> LoadAllLineInformationClientFromFile ()
        {
            List<string> LiInfromationAllClientsFromFile = new List<string>();

            if (System.IO.File.Exists(_kPATH_FILE_CLIENT))
            {
                System.IO.StreamReader readLineInformationFromFile = new System.IO.StreamReader(_kPATH_FILE_CLIENT);

                string lineInformationClient = "";

                while ((lineInformationClient = readLineInformationFromFile.ReadLine()) != null)
                {
                    LiInfromationAllClientsFromFile.Add(lineInformationClient);
                }

                readLineInformationFromFile.Close(); 

            }
            return LiInfromationAllClientsFromFile;
        }

        private List<string> SplitLineInformationOneClinet (string lineInformationClient)
        {
            List<string> informationOneClient = new List<string>();

            if(lineInformationClient !=null)
            {
                informationOneClient.AddRange(lineInformationClient.Split(new String[] { ";||;" }, StringSplitOptions.RemoveEmptyEntries) ); 
            }

            return informationOneClient; 
        }

        private stInformationClient ConvertLineToDataInformationOneClient (List<string> informationOneClient )
        {
            stInformationClient infoClient = new stInformationClient();

            if (informationOneClient.Count >= 5)
            {

                infoClient.stID = informationOneClient[0];
                infoClient.stName = informationOneClient[1];
                infoClient.stAddress = informationOneClient[2];
                infoClient.stEmail = informationOneClient[3];
                infoClient.stPhone = informationOneClient[4];

            }

            return infoClient;

        }

        private List<stInformationClient> LoadAllInformationToListStructure ()
        {
            List<string> AllLineInformationClient = LoadAllLineInformationClientFromFile(); 
            List<stInformationClient> stAllInformationClients = new List<stInformationClient>() ; 

            foreach (string lineInfoClient in AllLineInformationClient)
            {
                stInformationClient informatiomOneClinet = new stInformationClient(); 

                List<string> SplitsLineToInformation = SplitLineInformationOneClinet(lineInfoClient);
                informatiomOneClinet = ConvertLineToDataInformationOneClient(SplitsLineToInformation);
                stAllInformationClients.Add(informatiomOneClinet);

            }

            return stAllInformationClients; 


        }

        private bool isIDExistsInFile(string ID)
        {
            List<stInformationClient> stAllInformationClients = LoadAllInformationToListStructure();

            foreach (stInformationClient infoClient in stAllInformationClients)
            {

                if (infoClient.stID == ID) return true; 
            }

            return false; 
        }
    
        private void addNewClient()
        {
            List<string> LiInformationClient = new List<string>();

            if (!String.IsNullOrEmpty(GTextBoxIDClient.Text))
            {
                // This verification is to reduce any future errors.
                if (!isIDExistsInFile(GTextBoxIDClient.Text))
                {
                    LiInformationClient.Add(GTextBoxIDClient.Text);
                    LiInformationClient.Add(GTextBoxNameClient.Text);
                    LiInformationClient.Add(GTextBoxAddressClient.Text);
                    LiInformationClient.Add(GTextBoxEmailClient.Text);
                    LiInformationClient.Add(GTextBoxPhoneClient.Text);

                    LoadLineInformationClientToFile(ConvertSeriseStringToLine(LiInformationClient, ";||;"));

                    //Notification
                    notifyIconAddClients.ShowBalloonTip(1500, "Sparkle Add New Client Notification", $"The Client ID [{GTextBoxIDClient.Text}] Add Sccuessfully , And you need to show list Client Click the Notification to open file Clients", ToolTipIcon.Info);
                    ResetAllTextBoxToDefault();

                    //Automatically generate an ID based on the file
                    GTextBoxIDClient.Text = (getLastIDClientInList() + 1).ToString();

                }
                else
                {

                    MessageBox.Show("This is ID Already Exsits in the List ", "Note The Add Clients", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GTextBoxIDClient.Clear();
                }
            }
          }

        private void addNewClintInSparkle()
        {
            addNewClient();

        }
      
        private void ButtonAddNewClient_Click(object sender, EventArgs e)
        {
            addNewClintInSparkle();

        }

        private void setErrorProvider(object sender, CancelEventArgs e , string captionError , string captionCorrect )
        {

            Guna2TextBox GTB = sender as Guna2TextBox;

           if(string.IsNullOrEmpty(GTB.Text))
            {
                //Error Provider must included this method
                e.Cancel = true;
                GTB.Focus();
                //MessageBox.Show($"This {captionError} Must Be Fill ", "Note The Add Clients", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CorrectProviderAddCleint.SetError(GTB ,"");
                errorProviderFormClients.SetError(GTB, captionError);
            }
            else
            {
                //Correct Provider must included this method
                e.Cancel = false;
                //  MessageBox.Show($"This {captionError} Must Be Fill ", "Note The Add Clients", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorProviderFormClients.SetError(GTB, "");
                CorrectProviderAddCleint.SetError(GTB, captionCorrect);
            }

        }

        private bool isDigit (char Character)
        {
            return ((Convert.ToInt32(Character) >= 48) && (Convert.ToInt32(Character) <= 57));
        }
      
        private bool areHaveTextLettersOrNot (string text)
        {
            foreach (char Character in text)
            {
                if (!isDigit(Character))
                {
                    return true; 
                }

            }

            return false;
        }
     
        private void setErrorProviderWithoutLetters(object sender, CancelEventArgs e, string captionError, string captionCorrect)
        {

            Guna2TextBox GTB = sender as Guna2TextBox;

            if (string.IsNullOrEmpty(GTB.Text) || areHaveTextLettersOrNot(GTB.Text))
            {
                //Error Provider must included this method
                e.Cancel = true;
                GTB.Focus();
                //MessageBox.Show($"This {captionError} Must Be Fill ", "Note The Add Clients", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CorrectProviderAddCleint.SetError(GTB, "");
                errorProviderFormClients.SetError(GTB, captionError);
            }
            else
            {
                //Correct Provider must included this method
                e.Cancel = false;
                //  MessageBox.Show($"This {captionError} Must Be Fill ", "Note The Add Clients", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorProviderFormClients.SetError(GTB, "");
                CorrectProviderAddCleint.SetError(GTB, captionCorrect);
            }

        }
     
        private void GTextBoxIDClient_Validating(object sender, CancelEventArgs e)
        {
            
            setErrorProvider(sender, e , "You must fill in this field to complete the customer addition process.", "Successful");
        }

        private void notifyIconAddClients_BalloonTipClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_kPATH_FILE_CLIENT);
        }

        private int getLastIDClientInList()
        {
            List<string> infromationClientsLines = LoadAllLineInformationClientFromFile();
            List<string> LastLineInformation = new List<string>();
            LastLineInformation.AddRange(SplitLineInformationOneClinet(infromationClientsLines[infromationClientsLines.Count - 1]));

            int lastIDClient = Convert.ToInt32(LastLineInformation[0]);

            return lastIDClient;
        }

        private void GTextBoxNameClient_Validating(object sender, CancelEventArgs e)
        {
            setErrorProvider(sender, e, "You must fill in this field to complete the customer addition process.", "Successful");

        }

        private void GTextBoxEmailClient_Validating(object sender, CancelEventArgs e)
        {
            setErrorProvider(sender, e, "You must fill in this field to complete the customer addition process.", "Successful");

        }

        private void GTextBoxPhoneClient_Validating(object sender, CancelEventArgs e)
        {

            setErrorProviderWithoutLetters(sender, e, "You must fill in this field to complete the customer addition process. , You must enter a number, not letters.", "Successful");

        }

        private void GTextBoxAddressClient_Validating(object sender, CancelEventArgs e)
        {
            setErrorProvider(sender, e, "You must fill in this field to complete the customer addition process.", "Successful");

        }

  
    }
}
