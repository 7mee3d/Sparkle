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
            public UserControlClients()
        {
            InitializeComponent();
        }

        private void ButtonAddNewClient_Click(object sender, EventArgs e)
        {
            List<string> LiInformationClient = new List<string>();

            LiInformationClient.Add(GTextBoxIDClient.Text);
            LiInformationClient.Add(GTextBoxNameClient.Text);
            LiInformationClient.Add(GTextBoxAddressClient.Text);
            LiInformationClient.Add(GTextBoxEmailClient.Text);
            LiInformationClient.Add(GTextBoxPhoneClient.Text);

            LoadLineInformationClientToFile(ConvertSeriseStringToLine(LiInformationClient, ";||;"));
            MessageBox.Show("Done");
        }
    }
}
