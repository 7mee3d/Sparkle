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

        //File Name (Path)
        const string kPATH_FILE_CLIENT = @"../../Data_Sparkle/InformationClients.txt";

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
       
        private bool isFoundIDClientInSystem(string ID , ref stInformationClient infoClient)
        {
            List<stInformationClient> informationAllClientsStructure = LoadAllLinesInformationClientsToListStructure();

            if (!string.IsNullOrEmpty(ID)) {
                foreach (stInformationClient infoOneClient in informationAllClientsStructure)
                    if (infoOneClient.stID == ID) {
                        infoClient = infoOneClient; 
                        return true;
                    }
        }
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
                if (infoOneClient.stID == ID)
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

        stInformationClient informationClient = new stInformationClient();

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

        private void showAllInformationClientBeforeRemove(stInformationClient informationClient)
        {
            GTextBoxSectionRemoveClientAddress.Text = informationClient.stAddressClient;
            GTextBoxSectionRemoveClientPhone.Text = informationClient.stPhoneClient;
            GTextBoxSectionRemoveClientEmail.Text = informationClient.stEmailClient;
            GTextBoxSectionRemoveClientName.Text = informationClient.stNameClient;
        }

        private bool IsFoundIDClientInSystemSparkleBySearch(string ID)
        {
  

            if (!string.IsNullOrEmpty(ID))
            {
                if (isFoundIDClientInSystem(ID , ref informationClient))
                {
                    if (GRadioButtonRemoveMode.Checked)
                        showAllInformationClientBeforeRemove(informationClient);

                    if (GRadioButtonUpdateMode.Checked)
                        EnableAllTextBoxOrNot(true);
                    
                    notifyIconFoundClientInSystemSparkle.ShowBalloonTip
                        (1000,
                        "Search Cleint By ID In Sparkle System"
                        , $"This ID [{ID}] is Found In Sparkle System , Now Able To Update and Remove This Client Via By Select The Mode [ Update , Remove ] Client"
                        , ToolTipIcon.Info);

                    return true;
                }
                else
                {
                    MessageBox.Show
                        ($"Warning! This ID Cleint [{ID}] Not Found In Sparkle System , Please Try Enter Aother ID to be Search in system "
                        , "Warning Search By ID "
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                    EnableAllTextBoxOrNot(false);
                    
                }
            }
            else
                MessageBox.Show
                    ("Error! This Box already Empty , Please Enter the ID To Be Search"
                    , "Error Search By ID "
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);


            return false;
        }
      
        private void GButtonSearchIDExsits_Click(object sender, EventArgs e)
        {

            string IDClient = GTextBoxIDClient.Text; 

            IsFoundIDClientInSystemSparkleBySearch(ID: IDClient);

        }

        private void GButtonUpdateClient_Click(object sender, EventArgs e)
        {
            string ID = GTextBoxIDClient.Text;

            if (GRadioButtonNone.Checked)
            {
                MessageBox.Show
                    ($"Sorry This None Mode not perform any process [Remove or Update] in system Sparkle !"
                    , "Error None Mode"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                ClearAllTextBoxiesAndModes();
                return;
            }

            if (GRadioButtonUpdateMode.Checked)
            {
                if (!string.IsNullOrEmpty(ID))
                {
                    if (GTextBoxNameClient.Enabled)
                    {
                        if (updateInformationOneClient(ID))
                            if (
                                (MessageBox.Show
                                ($"Are you sure you want to Update this This Client [{ID}] Information?"
                                , "Confirm Update Client"
                                , MessageBoxButtons.OKCancel
                                , MessageBoxIcon.Exclamation) == DialogResult.OK)
                                ) notifyIconRemoveAndUpdateClient.ShowBalloonTip(1500, "Notification Update Information Client", "This Client Information has been successfully Updated .If you would like to view the Updated information, click on the notification.", ToolTipIcon.Info);
                    }
                    else
                        MessageBox.Show("Error! This Box already Not Enable,\nPlease Enter the ID and Go To The Search Button To Be Search ID Client To\nComplete Update Client", "Error Update Client By ID ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("Error! This Box already Empty , Please Enter the ID To Be Search", "Error Search By ID ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            ClearAllTextBoxiesAndModes();
        }

        private void notifyIconRemoveAndUpdateClient_BalloonTipClicked_1(object sender, EventArgs e)
        {

            string fullPathFile = System.IO.Path.GetFullPath(kPATH_FILE_CLIENT);

            try
            {
                if (System.IO.File.Exists(fullPathFile))
                    System.Diagnostics.Process.Start("explorer.exe", fullPathFile);
                else
                    MessageBox.Show(
                        "File not found."
                        );
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening the file:\n" + ex.Message,
                                   "Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
        }

        private void GButtonRemoveClient_Click(object sender, EventArgs e)
        {
            string ID = GTextBoxIDClient.Text;

            if(GRadioButtonNone.Checked)
            {
                MessageBox.Show
                    ($"Sorry This None Mode not perform any process [Remove or Update] in system Sparkle !"
                    , "Error None Mode"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                ClearAllTextBoxiesAndModes();
                return; 
            }
            if (GRadioButtonUpdateMode.Checked)
            {
                MessageBox.Show
                    ($"Sorry This Update Mode not perform This process [Update] in system Sparkle ,Please Switch the Update Mode to Perform Update Information Client !"
                    , "Error None Mode"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                ClearAllTextBoxiesAndModes();
                return;
            }
            if (GRadioButtonRemoveMode.Checked)
            {
                if (GTextBoxSectionRemoveClientAddress.Text != "")
                {
                    if (!string.IsNullOrEmpty(ID))
                    {
                        if ((MessageBox.Show
                            ($"Are you sure you want to Remove this This Client [{ID}] Information?"
                            , "Confirm Remove Client"
                            , MessageBoxButtons.OKCancel
                            , MessageBoxIcon.Exclamation) == DialogResult.OK))

                            if (RemoveClientOfSystemSparkleAndFile(ID))
                                notifyIconRemoveAndUpdateClient.ShowBalloonTip
                                    (1500
                                    , $"Notification Remove Client This ID [{ID}]"
                                    , "This Client Information has been successfully Remove in Sparkle System .If you would like to view the Removed This Client, click on the notification."
                                    , ToolTipIcon.Info);


                            else MessageBox.Show
                                    ($"Sorry This ID [{ID}] Not Found in System Sparkle Try Agian Enter ID Valid !"
                                    , "Error Remove Client"
                                    , MessageBoxButtons.OK
                                    , MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show
                            ("Error! This Box already Empty , Please Enter the ID To Be Search"
                            , "Error Search By ID "
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show
                        ("Warning! Must Be Search the Client Bu ID then to be remove the Client"
                        , "Error Remove By ID "
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);

                }
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

                errorProviderCoreectFillTextBox.SetError
                    (GTextBoxIDClient
                    , "");

                errorProviderRemoveOrUpdate.SetError
                    (GTextBoxIDClient
                    , "Please note that this field is mandatory in order to complete the rest of the operations, such as searching, updating, and deleting. ");
            }
            else
            {
                e.Cancel = false;
                errorProviderRemoveOrUpdate.SetError
                    (GTextBoxIDClient
                    , "");

                errorProviderCoreectFillTextBox.SetError
                    (GTextBoxIDClient
                    , "Successful");

            }
        }

        private void CheckedChangedRadioButonModesInSystemSparkle(object sender, EventArgs e)
        {
            if (GRadioButtonRemoveMode.Checked)
            {

                GPanelFillInformationClientToUpdate.Visible = false;
                GPanelInformationClientBeforeRemove.Visible = true;
                PictureBoxRemoveAndUpdateClientGIF.Visible = false;

            }


            if (GRadioButtonNone.Checked)
            {
                PictureBoxRemoveAndUpdateClientGIF.Visible = true;
                GPanelFillInformationClientToUpdate.Visible = false;
                GPanelInformationClientBeforeRemove.Visible = false;

            }

            if (GRadioButtonUpdateMode.Checked)
            {
                PictureBoxRemoveAndUpdateClientGIF.Visible = false;
                GPanelFillInformationClientToUpdate.Visible = true;
                GPanelInformationClientBeforeRemove.Visible = false;
            }

        }

        private void DrawLineOfUserControlRemoveAndUpdate(PaintEventArgs e)
        {

            Color whiteGreen = Color.FromArgb(255,4, 187, 156);

            Pen pen = new Pen(whiteGreen);

            pen.Width = 4;

            Point p1 = new Point(0, 430); 
            Point p2 = new Point(750, 430 );

            e.Graphics.DrawLine(pen, p1, p2);
        }
     
        private void UserControlRemoveOrUpdateClients_Paint(object sender, PaintEventArgs e)
        {
            DrawLineOfUserControlRemoveAndUpdate(e);
        }
    }
}
