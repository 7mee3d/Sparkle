using Guna.UI2.WinForms;
using Sparkle.Properties;
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
        const string _kPATH_FILE_CLIENT = @"../../Data_Sparkle/InformationClients.txt";

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
            pen.Width = 6;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //Points Line
            Point p1 = new Point(0, 330);
            Point p2 = new Point(1350, 330);

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

        // ----------------------------------------[ Start Section Show Context Menu Strip ] --------------------------------------

        private void GContextMenuStripRemoveClient_Opening(object sender, CancelEventArgs e)
        {
            bool hasSelection = (ListViewClientsLists.SelectedItems.Count > 0);

            removeClientToolStripMenuItem.Enabled = hasSelection;
            showAllInformationClientClientToolStripMenuItem.Enabled = hasSelection;
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


        // ----------------------------------------[ End Section Show Context Menu Strip ] --------------------------------------


        private void showAllInformationClientClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowInformationClientAfterSelect();
        }

        // ----------------------------------------[ Start Section Show New Form ] --------------------------------------


        Form frmShowAllInformationOneClient;

        private void ShowInformationClientAfterSelect()
        {
            frmShowAllInformationOneClient = new Form();
            setLabelShowInformationClient(frmShowAllInformationOneClient);
            setTitleAndSizeAndLocationFormAndAllSetting(frmShowAllInformationOneClient);

                frmShowAllInformationOneClient.Show();
        }
      
        private void setLabelShowInformationClient(Form frmShowAllInformationOneClientAfterlickMenuContextStip)
        {
            Label lblShowInformationClient= new Label();

            lblShowInformationClient.Text = "Info Client";
            lblShowInformationClient.Font = new Font("Garamond", 40, FontStyle.Bold);
            lblShowInformationClient.ForeColor = Color.FromArgb(255, 4, 187, 156);
            lblShowInformationClient.Width = 350;
            lblShowInformationClient.Height = 60;
            lblShowInformationClient.Top = 55;
            lblShowInformationClient.Left = 125;
            lblShowInformationClient.BackColor = Color.Transparent;

            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(lblShowInformationClient);
        }

        private void setTitleAndSizeAndLocationFormAndAllSetting(Form frmShowAllInformationOneClientAfterlickMenuContextStip)
        {

            frmShowAllInformationOneClientAfterlickMenuContextStip.Text = "Info Client";
            frmShowAllInformationOneClientAfterlickMenuContextStip.StartPosition = FormStartPosition.CenterScreen;

            //Controls Form 
            Guna2BorderlessForm GBLEF = new Guna2BorderlessForm();
            Guna2ShadowForm G2SF = new Guna2ShadowForm();
            Guna2ControlBox CloseFormControlBox = new Guna2ControlBox();
            
            //Properties Form 
            GBLEF.BorderRadius = 20;
            G2SF.ShadowColor = Color.FromArgb(90, 4, 187, 156);
            G2SF.SetShadowForm(frmShowAllInformationOneClientAfterlickMenuContextStip);
            GBLEF.ContainerControl = frmShowAllInformationOneClientAfterlickMenuContextStip;
            frmShowAllInformationOneClientAfterlickMenuContextStip.MinimizeBox = false;
            frmShowAllInformationOneClientAfterlickMenuContextStip.MaximizeBox = false;
            frmShowAllInformationOneClientAfterlickMenuContextStip.ControlBox = false;
            frmShowAllInformationOneClientAfterlickMenuContextStip.BackColor = Color.White;
            frmShowAllInformationOneClientAfterlickMenuContextStip.Size = new Size(500, Convert.ToInt32(Math.Round(700.5)));
            frmShowAllInformationOneClientAfterlickMenuContextStip.BackgroundImage = Resources.Background_Image_Form_Finial_Bill_Orders_;
            frmShowAllInformationOneClientAfterlickMenuContextStip.BackgroundImageLayout = ImageLayout.Zoom;

            //Control Box Close Form properties 
            CloseFormControlBox.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.CloseBox;
            CloseFormControlBox.FillColor = Color.Transparent;
            CloseFormControlBox.BorderColor = Color.FromArgb(4, 187, 156);
            CloseFormControlBox.BorderThickness = 2;
            CloseFormControlBox.HoverState.FillColor = Color.FromArgb(4, 187, 156);
            CloseFormControlBox.HoverState.IconColor = Color.White ;
            CloseFormControlBox.IconColor = Color.White;
            CloseFormControlBox.IconColor = Color.FromArgb(4, 187, 156); 
            CloseFormControlBox.BackColor = Color.Transparent;
            CloseFormControlBox.Size = new Size(40, 30);
            CloseFormControlBox.Location = new Point(frmShowAllInformationOneClientAfterlickMenuContextStip.Width - 80, 20); 
            CloseFormControlBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CloseFormControlBox.Animated = true;
            CloseFormControlBox.Cursor = Cursors.Hand; 

            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(CloseFormControlBox);
            setLabelShowInformationClient(frmShowAllInformationOneClientAfterlickMenuContextStip);
            SetAllLabelsToFormShowInformationClient(frmShowAllInformationOneClientAfterlickMenuContextStip);

        }

        private void setLabelIDClientAndResultIDClient(Form frmShowAllInformationOneClientAfterlickMenuContextStip , string IDClient )
        {
            Label lblIDClient = new Label();
            Label lblResultIDClient = new Label();

            // Label ID Client 
            lblIDClient.Text = "ID Client :";
            lblIDClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblIDClient.BackColor = Color.Transparent;
            lblIDClient.Top = 160;
            lblIDClient.Left = 10;
            lblIDClient.Width = 120;
            lblIDClient.Height = 40;
            lblIDClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label ID Order 
            lblResultIDClient.Text = IDClient;
            lblResultIDClient.Font = new Font("Garamond", 15, FontStyle.Bold);
            lblResultIDClient.Top = 160;
            lblResultIDClient.Left = 130;
            lblResultIDClient.Width = 50;
            lblResultIDClient.BackColor = Color.Transparent;




            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(lblIDClient);
            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(lblResultIDClient);

        }

        private void setLabelNameClientAndResultNameClient(Form frmShowAllInformationOneClientAfterlickMenuContextStip, string NameClient)
        {
            Label lblNameClient = new Label();
            Label lblResultNameClient = new Label();

            // Label name Client 
            lblNameClient.Text = "Name Client :";
            lblNameClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblNameClient.BackColor = Color.Transparent;
            lblNameClient.Top = 260;
            lblNameClient.Left = 10;
            lblNameClient.Width = 145;
            lblNameClient.Height = 40;
            lblNameClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label ID Order 
            lblResultNameClient.Text = NameClient;
            lblResultNameClient.Font = new Font("Garamond", 15, FontStyle.Bold);
            lblResultNameClient.Top = 260;
            lblResultNameClient.Left = 150;
            lblResultNameClient.Width = 250;
            lblResultNameClient.BackColor = Color.Transparent;




            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(lblNameClient);
            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(lblResultNameClient);

        }

        private void setLabelAddressClientAndResultAddressClient(Form frmShowAllInformationOneClientAfterlickMenuContextStip, string AddressClient)
        {
            Label lblAddressClient = new Label();
            Label lblResultAddressClient = new Label();

            // Label name Client 
            lblAddressClient.Text = "Address Client:";
            lblAddressClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblAddressClient.BackColor = Color.Transparent;
            lblAddressClient.Top = 360;
            lblAddressClient.Left = 10;
            lblAddressClient.Width = 155;
            lblAddressClient.Height = 40;
            lblAddressClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label ID Order 
            lblResultAddressClient.Text = AddressClient;
            lblResultAddressClient.Font = new Font("Garamond", 15, FontStyle.Bold);
            lblResultAddressClient.Top = 360;
            lblResultAddressClient.Left = 160;
            lblResultAddressClient.Width = 300;
            lblResultAddressClient.Height = 100;
            lblResultAddressClient.BackColor = Color.Transparent;




            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(lblAddressClient);
            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(lblResultAddressClient);

        }

        private void setLabelEmailClientAndResultAddressClient(Form frmShowAllInformationOneClientAfterlickMenuContextStip, string EmailClient)
        {
            Label lblEmailClient = new Label();
            Label lblResultEmailClient = new Label();

            // Label Email Client 
            lblEmailClient.Text = "Email Client:";
            lblEmailClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblEmailClient.BackColor = Color.Transparent;
            lblEmailClient.Top = 460;
            lblEmailClient.Left = 10;
            lblEmailClient.Width = 160;
            lblEmailClient.Height = 40;
            lblEmailClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Email  Client
            lblResultEmailClient.AutoSize = true; 
            lblResultEmailClient.Text = EmailClient;
            lblResultEmailClient.Font = new Font("Garamond", 15, FontStyle.Bold);
            lblResultEmailClient.Top = 460;
            lblResultEmailClient.Left = 165;
            lblResultEmailClient.Width = 300;
            lblEmailClient.Height = 80;
            lblResultEmailClient.BackColor = Color.Transparent;




            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(lblEmailClient);
            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(lblResultEmailClient);

        }

        private void setLabelPhoneClientAndResultAddressClient(Form frmShowAllInformationOneClientAfterlickMenuContextStip, string PhoneClient)
        {
            Label lblPhoneClient = new Label();
            Label lblResultPhoneClient = new Label();

            // Label Phone Client 
            lblPhoneClient.Text = "Phone Client:";
            lblPhoneClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblPhoneClient.BackColor = Color.Transparent;
            lblPhoneClient.Top = 560;
            lblPhoneClient.Left = 10;
            lblPhoneClient.Width = 150;
            lblPhoneClient.Height = 40;
            lblPhoneClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Phone  Client
            lblResultPhoneClient.Text = PhoneClient;
            lblResultPhoneClient.Font = new Font("Garamond", 15, FontStyle.Bold);
            lblResultPhoneClient.Top = 560;
            lblResultPhoneClient.Left = 155;
            lblResultPhoneClient.Width = 250;
            lblResultPhoneClient.BackColor = Color.Transparent;




            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(lblPhoneClient);
            frmShowAllInformationOneClientAfterlickMenuContextStip.Controls.Add(lblResultPhoneClient);



        }

        private void SetAllLabelsToFormShowInformationClient (Form frmShowAllInformationOneClientAfterlickMenuContextStip)
        {
            setLabelIDClientAndResultIDClient(frmShowAllInformationOneClientAfterlickMenuContextStip, ListViewClientsLists.SelectedItems[0].Text);
            setLabelNameClientAndResultNameClient(frmShowAllInformationOneClientAfterlickMenuContextStip, ListViewClientsLists.SelectedItems[0].SubItems[1].Text);
            setLabelAddressClientAndResultAddressClient(frmShowAllInformationOneClientAfterlickMenuContextStip, ListViewClientsLists.SelectedItems[0].SubItems[2].Text);
            setLabelEmailClientAndResultAddressClient(frmShowAllInformationOneClientAfterlickMenuContextStip, ListViewClientsLists.SelectedItems[0].SubItems[3].Text);
            setLabelPhoneClientAndResultAddressClient(frmShowAllInformationOneClientAfterlickMenuContextStip, ListViewClientsLists.SelectedItems[0].SubItems[4].Text);
        }



        // ----------------------------------------[ End Section Show New Form ] --------------------------------------

    }

}
