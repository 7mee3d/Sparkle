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
    public partial class UserControlRemoveOrUpdateClients : UserControl
    {

        private void EnableAllTextBoxOrNot (bool enableOrNotEnableTextBox = true )
        {
            foreach (Control OutterControl in Controls)
            {
                if (OutterControl is Guna2Panel GP)
                {
                    foreach (Control innerControl in GP.Controls)
                    {

                        if (innerControl is Guna2TextBox GTB)
                        {
                            if (GTB.Name == GTextBoxIDClient.Name) GTB.Enabled = true ;
                            else
                                GTB.Enabled = enableOrNotEnableTextBox;
                        }
                    }

                }
            }
        }
        public UserControlRemoveOrUpdateClients()
        {
            InitializeComponent();
            EnableAllTextBoxOrNot(false);

        }

        class stInformationClient
        {
            public string stID;
            public string stNameClient;
            public string stAddressClient;
            public string stEmailClient;
            public string stPhoneClient;

        }


        const string kPATH_FILE_CLIENT = "InformationClients.txt";

        private List<string> LoadAllLineInformationClientFromFile()
        {
            List<string> infroamtionAllClientFromFile = new List<string>();

            if (!System.IO.File.Exists(kPATH_FILE_CLIENT))
                System.IO.File.Create(kPATH_FILE_CLIENT).Close();

            System.IO.StreamReader ReadAllLineFromFileInfromationClients = new System.IO.StreamReader(kPATH_FILE_CLIENT);

            string lineInformationClient = "";

            while((lineInformationClient = ReadAllLineFromFileInfromationClients.ReadLine() )!= null)
            {
                if (!string.IsNullOrEmpty(lineInformationClient))
                    infroamtionAllClientFromFile.Add(lineInformationClient);


            }
            ReadAllLineFromFileInfromationClients.Close();

            return infroamtionAllClientFromFile; 


        }

        private stInformationClient ConvertLineInfroamtionClientToData(List<string> informationOneClient)
        {

            stInformationClient infroamtionOnelientData = new stInformationClient();

            if (informationOneClient.Count >= 5)
            {
                infroamtionOnelientData.stID = informationOneClient[0];
                infroamtionOnelientData.stNameClient = informationOneClient[1];
                infroamtionOnelientData.stAddressClient = informationOneClient[2];
                infroamtionOnelientData.stEmailClient = informationOneClient[3];
                infroamtionOnelientData.stPhoneClient = informationOneClient[4];

            }

            return infroamtionOnelientData;

        }


        private List<string> SplitLineInformationClinet (string lineInformationClinet )
        {

            List<string> informationSplitLineInformationClient = new List<string>();

            if (!string.IsNullOrEmpty(lineInformationClinet))
            {
                informationSplitLineInformationClient.AddRange(lineInformationClinet.Split(new string[] { ";||;" }, StringSplitOptions.RemoveEmptyEntries)); 

            }

            return informationSplitLineInformationClient;
        }


        private List <stInformationClient> LoadAllLinesInformationClientsToListStructure ()
        {
            List<string> allInformationClientLines = LoadAllLineInformationClientFromFile();
            List<stInformationClient> allInformationClientSturcture = new List<stInformationClient>(); 

            foreach(string lineInformationOneClient in allInformationClientLines)
            {
                allInformationClientSturcture.Add(ConvertLineInfroamtionClientToData(SplitLineInformationClinet(lineInformationOneClient)));
            }

            return allInformationClientSturcture;
        }

        private string ConvertDataStructToLine (stInformationClient infromationOneClientStruct , string Separator = ";||;")
        {
            string line = "";

            line += infromationOneClientStruct.stID + Separator;
            line += infromationOneClientStruct.stNameClient + Separator;
            line += infromationOneClientStruct.stAddressClient + Separator;
            line += infromationOneClientStruct.stEmailClient + Separator;
            line += infromationOneClientStruct.stPhoneClient;

            return line; 
        }

        private void pushAllInformationClientsStructureToFile (List<stInformationClient> informationAllClientsSturcture)
        {
            if (!System.IO.File.Exists(kPATH_FILE_CLIENT))
                System.IO.File.Create(kPATH_FILE_CLIENT).Close();

            System.IO.StreamWriter LoadAllDataToFile = new System.IO.StreamWriter(kPATH_FILE_CLIENT);


            foreach(stInformationClient infoOneClient in informationAllClientsSturcture)
            {
         
                LoadAllDataToFile.WriteLine(ConvertDataStructToLine(infoOneClient, ";||;"));

            }

            LoadAllDataToFile.Close(); 

        }

        private void ModifyTheInformationOneClient (ref stInformationClient informationOneClient , List<string> allInformationGetTextBoxInformationClients )
        {

           
            informationOneClient.stNameClient = allInformationGetTextBoxInformationClients[0];
            informationOneClient.stAddressClient = allInformationGetTextBoxInformationClients[1];
            informationOneClient.stEmailClient = allInformationGetTextBoxInformationClients[2];
            informationOneClient.stPhoneClient = allInformationGetTextBoxInformationClients[3];

        }

        private bool isFoundIDClientInSystem (string ID)
        {
            List<stInformationClient> informationAllClientsStructure = LoadAllLinesInformationClientsToListStructure();

            foreach(stInformationClient infoOneClient in informationAllClientsStructure)
                if (infoOneClient.stID.Trim() == ID.Trim()) return true; 

            return false;
        }

        private bool updateInformationOneClient(string ID)
        {
            List<stInformationClient> informationAllClientsStructure = LoadAllLinesInformationClientsToListStructure();
            List<string> TextBoxNewInformationClient = new List<string>();

            TextBoxNewInformationClient.Add(GTextBoxNameClient.Text);
            TextBoxNewInformationClient.Add(GTextBoxAddressClient.Text);
            TextBoxNewInformationClient.Add(GTextBoxEmailClient.Text);
            TextBoxNewInformationClient.Add(GTextBoxPhoneClient.Text);

            /*
          for (int counter =0; counter < informationAllClientsStructure.Count; counter++ )
            {
                if (informationAllClientsStructure[counter].stID.Trim() == ID.Trim())
                {
                    ModifyTheInformationOneClient(ref informationAllClientsStructure, TextBoxNewInformationClient);
                }
            }*/

            foreach(stInformationClient infoOneClient in informationAllClientsStructure)
            {
                if (infoOneClient.stID.Trim() == ID.Trim())
                {
                    infoOneClient.stID = ID;
                    infoOneClient.stNameClient = GTextBoxNameClient.Text;
                    infoOneClient.stAddressClient = GTextBoxAddressClient.Text;
                    infoOneClient.stEmailClient = GTextBoxEmailClient.Text;
                    infoOneClient.stPhoneClient = GTextBoxPhoneClient.Text;
                }
            }

            pushAllInformationClientsStructureToFile(informationAllClientsStructure);

            return true; 

        }
     
        private void GButtonSearchIDExsits_Click(object sender, EventArgs e)
        {
            string ID = GTextBoxIDClient.Text;

            if (isFoundIDClientInSystem(ID))
                EnableAllTextBoxOrNot(true);

        }

        private void GButtonUpdateClient_Click(object sender, EventArgs e)
        {
            string ID = GTextBoxIDClient.Text;

            if (updateInformationOneClient(ID))
            {
                if(MessageBox.Show($"Are you sure you want to Update this This Client [{ID}] Information?" , "Confirm Update Client" , MessageBoxButtons.OK , MessageBoxIcon.Exclamation) == DialogResult.OK)
                MessageBox.Show("The Update was successful.", "Note Update Information Client" , MessageBoxButtons.OK);

            }
        }
    }
}
