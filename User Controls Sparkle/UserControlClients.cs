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
        }

        struct stInformationClient
        {
            public string stID; 
            public string stName; 
            public string stAddress; 
            public string stEmail; 
            public string stPhone; 
        }
        const string kPATH_FILE_CLIENT = "InformationClients.txt";

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
            if (!System.IO.File.Exists(kPATH_FILE_CLIENT))
                System.IO.File.Create(kPATH_FILE_CLIENT).Close();

            System.IO.StreamWriter LoadInformationToFile = new System.IO.StreamWriter(kPATH_FILE_CLIENT , true ); //True -> Append the information to push file no clear all info client 

            if (!String.IsNullOrEmpty(lineInformationClient))
            {
                LoadInformationToFile.WriteLine(lineInformationClient);
            }

            LoadInformationToFile.Close(); 

        }
     
        private List <string> LoadAllLineInformationClientFromFile ()
        {
            List<string> LiInfromationAllClientsFromFile = new List<string>();

            if (System.IO.File.Exists(kPATH_FILE_CLIENT))
            {
                System.IO.StreamReader readLineInformationFromFile = new System.IO.StreamReader(kPATH_FILE_CLIENT);

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
        private void ButtonAddNewClient_Click(object sender, EventArgs e)
        {
            List<string> LiInformationClient = new List<string>();

            if (!isIDExistsInFile(GTextBoxIDClient.Text))
            {
                LiInformationClient.Add(GTextBoxIDClient.Text);
                LiInformationClient.Add(GTextBoxNameClient.Text);
                LiInformationClient.Add(GTextBoxAddressClient.Text);
                LiInformationClient.Add(GTextBoxEmailClient.Text);
                LiInformationClient.Add(GTextBoxPhoneClient.Text);
                LoadLineInformationClientToFile(ConvertSeriseStringToLine(LiInformationClient, ";||;"));
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("This is ID Already Exsits in the List ", "Note The Add Clients", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        
        }
    }
}
