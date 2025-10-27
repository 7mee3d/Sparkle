using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Sparkle.User_Controls_Sparkle
{
    public partial class UserControlClientsList : UserControl
    {
        public UserControlClientsList()
        {
            InitializeComponent();
        }

        //File Path 
        const string _kPATH_FILE_CLIENT = "InformationClients.txt";

        class stInformationOneClient
        {
            public string stIDClient;
            public string stNameClient;
            public string stAddressClient;
            public string stEmailClient;
            public string stPhoneClient;

            public bool IsClientToBeRemove;
        }


        private void RefreshDataAfterRemoveClient()
        {
            ListViewClientsLists.Items.Clear();
            pushAllInformationClientsToListView();
            ListViewClientsLists.Refresh();
            LblNumberClient.Text = numberClientInSystem().ToString();
        }

        private List<string> LoadAllLineInformationClientsFromFile()
        {
            List<string> allInformationClientsFromFile = new List<string>();

            if (!System.IO.File.Exists(_kPATH_FILE_CLIENT))
                System.IO.File.Create(_kPATH_FILE_CLIENT).Close();

            System.IO.StreamReader ReadAllLinesFromFile = new System.IO.StreamReader(_kPATH_FILE_CLIENT);

            string lineInformationOneClient = null;

            while ((lineInformationOneClient = ReadAllLinesFromFile.ReadLine()) != null)
            {
                allInformationClientsFromFile.Add(lineInformationOneClient);

            }

            ReadAllLinesFromFile.Close();

            return allInformationClientsFromFile;

        }

        private void UserControlClientsList_Load(object sender, EventArgs e)
        {

            pushAllInformationClientsToListView();
            LblNumberClient.Text = numberClientInSystem().ToString();
            removeClientToolStripMenuItem.Enabled = false;


        }
        
        private stInformationOneClient ConvertLineToDataStruct (List<string> informationOneClient )
        {
            stInformationOneClient infoOneClient = new stInformationOneClient(); 

            if(informationOneClient.Count >= 5)
            {
                infoOneClient.stIDClient = informationOneClient[0];
                infoOneClient.stNameClient = informationOneClient[1];
                infoOneClient.stAddressClient = informationOneClient[2];
                infoOneClient.stEmailClient = informationOneClient[3];
                infoOneClient.stPhoneClient = informationOneClient[4];
            }

            return infoOneClient;
        }

        private List<string> SplitTheLineInformationClient (string lineInformationOneClientString)
        {
            List<string> informationOneClientString = new List<string>();

            if (!string.IsNullOrEmpty(lineInformationOneClientString))
            {
                informationOneClientString.AddRange(lineInformationOneClientString.Split(new string[] { ";||;" }, StringSplitOptions.RemoveEmptyEntries));
            }

            return informationOneClientString;
        }

        private List<stInformationOneClient> SaveAllInformationClientToListStructure()
        {
            List<string> informationallClients = LoadAllLineInformationClientsFromFile();

            List<stInformationOneClient> informationAllClientStucture = new List<stInformationOneClient>(); 

            foreach (string lineInfoOneClient in informationallClients)
            {
                stInformationOneClient infoOneClient = new stInformationOneClient(); 

                if (!string.IsNullOrEmpty(lineInfoOneClient))
                {
                    infoOneClient = ConvertLineToDataStruct(SplitTheLineInformationClient(lineInfoOneClient));
                    informationAllClientStucture.Add(infoOneClient);
                }
            }

            return informationAllClientStucture;
        }

        private void pushAllInformationClientsToListView ( )
        {
            List<stInformationOneClient> informationAllClientStucture = SaveAllInformationClientToListStructure();

            if (informationAllClientStucture.Count == 0) return; 

            for (int counter = 0; counter < informationAllClientStucture.Count; counter++ )
            {
                ListViewItem LVI = new ListViewItem(informationAllClientStucture[counter].stIDClient);


                if (informationAllClientStucture.Count != 0)
                {
                    LVI.SubItems.Add(informationAllClientStucture[counter].stNameClient);
                    LVI.SubItems.Add(informationAllClientStucture[counter].stAddressClient);
                    LVI.SubItems.Add(informationAllClientStucture[counter].stEmailClient);
                    LVI.SubItems.Add(informationAllClientStucture[counter].stPhoneClient);
                }

                ListViewClientsLists.Items.Add(LVI);
            }


        }
        
        private bool AreEqual(string textOne , string textTwo )
        {
            return (textOne == textTwo);

        }

        private bool isExsitsIDInTheList(string ID )
        {
            List<stInformationOneClient> informationAllClientStucture = SaveAllInformationClientToListStructure();

            if (AreEqual(ListViewClientsLists.Items[0].Text, ID))
            {
                ListViewClientsLists.Items[0].BackColor = Color.Yellow;
                ListViewClientsLists.Items[0].ForeColor = Color.Black;

                for (int counter = 0; counter < ListViewClientsLists.Items.Count; counter++)
                {
                    if(!AreEqual(ListViewClientsLists.Items[counter].Text, ID))
                        ListViewClientsLists.Items[counter].BackColor = Color.White;
                    ListViewClientsLists.Items[counter].ForeColor = Color.Black;

                }
                return true; 
            }

            for (int counter = 0; counter < ListViewClientsLists.Items.Count; counter++)
            {
                ListViewClientsLists.Items[counter].BackColor = Color.White;
                ListViewClientsLists.Items[counter].ForeColor = Color.Black;

                if (AreEqual (ListViewClientsLists.Items[counter].Text , ID) && ( !string.IsNullOrEmpty(ListViewClientsLists.Items[counter].Text)&&  !string.IsNullOrEmpty(ID)) )
                {
                    ListViewClientsLists.Items[counter].BackColor = Color.Yellow;   
                    ListViewClientsLists.Items[counter].ForeColor = Color.Black;

                    //This Statments Focuse the Line Client Information and move to 
                    ListViewClientsLists.Items[counter].Focused = true;
                    ListViewClientsLists.Items[counter].EnsureVisible();
                    //ListViewClientsLists.Items[counter].Selected = true;
                    return true; 
                }
            }
            /*
            foreach (stInformationOneClient infoOneClient in informationAllClientStucture)
            {
                if (AreEqual(infoOneClient.stIDClient, ID)) return true; 
            }

            return false; */
            GTextBoxSearch.Clear();
            GTextBoxSearch.Focus();

            return false; 
        }

        private int numberClientInSystem ()
        {
            return (ListViewClientsLists.Items.Count);
        }
      
        private void GButtonSearchByID_Click(object sender, EventArgs e)
        {
            string ID = GTextBoxSearch.Text;

            if (!isExsitsIDInTheList(ID))
            {
                MessageBox.Show($"This ID {ID} Not Found Go to the Section Client add this ID in the DB OR The Box Is Empty ", "Note The Clients List ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            GTextBoxSearch.Clear();
            GTextBoxSearch.Focus(); 
        }
      

        // -- Start Paint The Line Section --
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

        private void UserControlClientsList_Paint(object sender, PaintEventArgs e)
        {
            PaintTheLine(e);
        }

    
        // -- End Paint The Line Section --


        private string ConvertDataInformationClientToLine(stInformationOneClient informationOneClient, string Separator = ";||;")
        {

            string lineInformationCleint = "";

            lineInformationCleint += informationOneClient.stIDClient + Separator;
            lineInformationCleint += informationOneClient.stNameClient + Separator;
            lineInformationCleint += informationOneClient.stAddressClient + Separator;
            lineInformationCleint += informationOneClient.stEmailClient + Separator;
            lineInformationCleint += informationOneClient.stPhoneClient;

            return lineInformationCleint;

        }

        private void SaveAllInformationClientsStructureToFile(List<stInformationOneClient> allInfroamtionClientsStruct)
        {

            if (!System.IO.File.Exists(_kPATH_FILE_CLIENT))
                System.IO.File.Create(_kPATH_FILE_CLIENT).Close();

            System.IO.StreamWriter WriteAllInformationUserToFile = new System.IO.StreamWriter(_kPATH_FILE_CLIENT);

            foreach (stInformationOneClient infoOneClient in allInfroamtionClientsStruct)
            {
                if (infoOneClient.IsClientToBeRemove == false)
                    WriteAllInformationUserToFile.WriteLine(ConvertDataInformationClientToLine(infoOneClient, ";||;"));
            }

            WriteAllInformationUserToFile.Close();


        }
       
        private bool RemoveClientInSystemSparkle(string IDClient)
        {
            List<stInformationOneClient> allInfroamtionClientsStruct = SaveAllInformationClientToListStructure();

            foreach (stInformationOneClient informationClient in allInfroamtionClientsStruct)
            {
                if (IDClient == informationClient.stIDClient)
                {
                    informationClient.IsClientToBeRemove = true;
                    SaveAllInformationClientsStructureToFile(allInfroamtionClientsStruct);
                    return true;
                }
            }

            return false;

        }
    
        private void GContextMenuStripRemoveClient_Opening(object sender, CancelEventArgs e)
        {
            bool hasSelection = (ListViewClientsLists.SelectedItems.Count > 0);

            removeClientToolStripMenuItem.Enabled = hasSelection;
        }

        private void removeClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListViewClientsLists.SelectedItems.Count > 0)
                if (MessageBox.Show($"Are You Sure To Be Remove This Client ID [{ListViewClientsLists.SelectedItems[0].Text}]", "Note Remove Client", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    RemoveClientInSystemSparkle(ListViewClientsLists.SelectedItems[0].Text);
                    RefreshDataAfterRemoveClient();
                    MessageBox.Show("Done Remove Cleint", "Message After Remove Client" , MessageBoxButtons.OK , MessageBoxIcon.Information);
               
                }

            
           
        }
   
    
    }
    
}
