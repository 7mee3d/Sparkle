using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        const string kPATH_FILE_CLIENT = "InformationClients.txt";

        struct stInformationOneClient
        {
            public string stIDClient;
            public string stNameClient;
            public string stAddressClient;
            public string stEmailClient;
            public string stPhoneClient; 

        }

        private List<string> LoadAllLineInformationClientsFromFile()
        {
            List<string> allInformationClientsFromFile = new List<string>();

            if (!System.IO.File.Exists(kPATH_FILE_CLIENT))
                System.IO.File.Create(kPATH_FILE_CLIENT).Close();

            System.IO.StreamReader ReadAllLinesFromFile = new System.IO.StreamReader(kPATH_FILE_CLIENT);

            string lineInformationOneClient = null;

            while ((lineInformationOneClient = ReadAllLinesFromFile.ReadLine()) != null)
            {
                allInformationClientsFromFile.Add(lineInformationOneClient);

            }

            ReadAllLinesFromFile.Close();

            return allInformationClientsFromFile;

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

        private void pushAllInformationClientsToListView ()
        {
            List<stInformationOneClient> informationAllClientStucture = SaveAllInformationClientToListStructure();

            if (informationAllClientStucture.Count == 0) return; 

            for (int counter = 0; counter < informationAllClientStucture.Count; counter++ )
            {
                ListViewItem LVI = new ListViewItem(informationAllClientStucture[counter].stIDClient.ToString());


                if (informationAllClientStucture.Count != 0)
                {
                    LVI.SubItems.Add(informationAllClientStucture[counter].stNameClient.ToString());
                    LVI.SubItems.Add(informationAllClientStucture[counter].stAddressClient.ToString());
                    LVI.SubItems.Add(informationAllClientStucture[counter].stEmailClient.ToString());
                    LVI.SubItems.Add(informationAllClientStucture[counter].stPhoneClient.ToString());
                }

                ListViewClientsLists.Items.Add(LVI);

            }


        }
        
        private void UserControlClientsList_Load(object sender, EventArgs e)
        {
            pushAllInformationClientsToListView();
        }
    }
}
