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
            GRadioButtonNone.Checked = true; 
        }

        private void ClearAllTextBoxiesAndModes()
        {
            GRadioButtonNone.Checked = true; 
            GTextBoxIDClient.Clear();
            GTextBoxNameClient.Clear();
            GTextBoxPhoneClient.Clear(); 
            GTextBoxEmailClient.Clear(); 
            GTextBoxAddressClient.Clear(); 
        }

        class stInformationClient
        {
            public string stID;
            public string stNameClient;
            public string stAddressClient;
            public string stEmailClient;
            public string stPhoneClient;

            //Flags 

            public bool thisIDToBeRemove = false; 

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
                if(infoOneClient.thisIDToBeRemove == false )
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
        private bool RemoveClientOfSystemSparkleAndFile(string ID)
        {
            List<stInformationClient> informationAllClientsStructure = LoadAllLinesInformationClientsToListStructure();

            foreach (stInformationClient infoOneClient in informationAllClientsStructure)
            {
                if (infoOneClient.stID == ID)
                {
                    infoOneClient.thisIDToBeRemove = true;
                    pushAllInformationClientsStructureToFile(informationAllClientsStructure);

                    return true;
                }
            }
            return false;
        }

        private void GButtonSearchIDExsits_Click(object sender, EventArgs e)
        {
            string ID = GTextBoxIDClient.Text;

            if (isFoundIDClientInSystem(ID))
                EnableAllTextBoxOrNot(true);
            else
                EnableAllTextBoxOrNot(false );
        }

        private void GButtonUpdateClient_Click(object sender, EventArgs e)
        {
            string ID = GTextBoxIDClient.Text;
            if (GRadioButtonNone.Checked)
            {
                MessageBox.Show($"Sorry This None Mode not perform any process [Remove or Update]in system Sparkle !", "Error None Mode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearAllTextBoxiesAndModes();
                return;
            }

            if (GRadioButtonUpdateMode.Checked)
            {
                if ((MessageBox.Show($"Are you sure you want to Update this This Client [{ID}] Information?", "Confirm Update Client", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK))
                {
                    if (updateInformationOneClient(ID))
                        notifyIconRemoveAndUpdateClient.ShowBalloonTip(1500, "Notification Update Information Client", "This Client Information has been successfully Updated .If you would like to view the Updated information, click on the notification.", ToolTipIcon.Info);
                    //  MessageBox.Show("The Update was successful.", "Note Update Information Client" , MessageBoxButtons.OK);

                }
            }

            ClearAllTextBoxiesAndModes();
        }


        private void notifyIconRemoveAndUpdateClient_BalloonTipClicked_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(kPATH_FILE_CLIENT);
        }

        private void GButtonRemoveClient_Click(object sender, EventArgs e)
        {
            string ID = GTextBoxIDClient.Text;
            if(GRadioButtonNone.Checked)
            {
                MessageBox.Show($"Sorry This None Mode not perform any process [Remove or Update] in system Sparkle !", "Error None Mode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearAllTextBoxiesAndModes();
                return; 
            }
            if (GRadioButtonUpdateMode.Checked)
            {
                MessageBox.Show($"Sorry This Update Mode not perform This process [Update] in system Sparkle ,Please Switch the Update Mode to Perform Update Information Client !", "Error None Mode", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClearAllTextBoxiesAndModes();
                return;
            }
            if (GRadioButtonRemoveMode.Checked)
            {
                if ((MessageBox.Show($"Are you sure you want to Remove this This Client [{ID}] Information?", "Confirm Remove Client", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK))
                    if (RemoveClientOfSystemSparkleAndFile(ID))
                        notifyIconRemoveAndUpdateClient.ShowBalloonTip(1500, $"Notification Remove Client This ID [{ID}]", "This Client Information has been successfully Remove in Sparkle System .If you would like to view the Removed This Client, click on the notification.", ToolTipIcon.Info);
                    else MessageBox.Show($"Sorry This ID [{ID}] Not Found in System Sparkle Try Agian Enter ID Valid !", "Error Remove Client", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            ClearAllTextBoxiesAndModes();
        }

        private bool isDigitCharacter (char Character)
        {
            return (Convert.ToInt32 (Character) >= 48 && Convert.ToInt32(Character) <= 57 ); 
        }
        private bool isAllCharacterInTextIsDigit (string text )
        {
            foreach(char Character in text)
            {
                if (!isDigitCharacter(Character)) return false; 
            }

            return true;
        }
        private void GTextBoxIDClient_Validating(object sender, CancelEventArgs e)
        {
            
  string ID = GTextBoxIDClient.Text;

            if (string.IsNullOrEmpty(ID)  || !isAllCharacterInTextIsDigit (ID))
            {
                e.Cancel = true;
                GTextBoxIDClient.Focus();
                errorProviderCoreectFillTextBox.SetError(GTextBoxIDClient, "");
                errorProviderRemoveOrUpdate.SetError(GTextBoxIDClient, "Please note that this field is mandatory in order to complete the rest of the operations, such as searching, updating, and deleting. ");
            }
            else
            {
                e.Cancel = false;
                errorProviderRemoveOrUpdate.SetError(GTextBoxIDClient, "");
                errorProviderCoreectFillTextBox.SetError(GTextBoxIDClient, "Successful");

            }
        }

 


   
        private void GRadioButtonUpdateMode_CheckedChanged(object sender, EventArgs e)
        {
            if (GRadioButtonUpdateMode.Checked)
            {

                GPanelFillInformationClientToUpdate.Visible = true;
            }

          
        }

        private void GRadioButtonRemoveMode_CheckedChanged(object sender, EventArgs e)
        {
            if (GRadioButtonRemoveMode.Checked)
            {

                GPanelFillInformationClientToUpdate.Visible = false;

            }
        }

        private void DrawLineOfUserControlRemoveAndUpdate(PaintEventArgs e)
        {

            Color whiteGreen = Color.FromArgb(255,4, 187, 156);

            Pen pen = new Pen(whiteGreen);

            pen.Width = 4;

            Point p1 = new Point(0, 430); 
            Point p2 = new Point(687, 430 );

            e.Graphics.DrawLine(pen, p1, p2);
        }
        private void UserControlRemoveOrUpdateClients_Paint(object sender, PaintEventArgs e)
        {
            DrawLineOfUserControlRemoveAndUpdate(e);
        }
    }
}
