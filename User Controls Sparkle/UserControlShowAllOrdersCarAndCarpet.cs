using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sparkle.User_Controls_Sparkle
{
    public partial class UserControlShowAllOrdersCarAndCarpet : UserControl
    {

        public UserControlShowAllOrdersCarAndCarpet()
        {
            InitializeComponent();
            ListViewAllOrdersCarpet.Scrollable = true;
            psuhAllInformationOrderToListViewCarpet();



        }

        private const string _kPATH_FILE_NAME_CARPET_ORDERS = "CarpetsOrders.txt";
        private const string _kPATH_FILE_NAME_CAR_ORDERS = "CarOrders.txt";
        struct stInformationOrderCarpet
        {
            public string stIDCarpetOrder;
            public string stNameClient;
            public string stAddressClient;
            public string stEmailClient;
            public string stPhoneClient;
            public string stSizeCarpet;
            public string stTypeWashCarpet;
            public string stOtherServiceCarpet;
            public string stNumberCarpet;
            public string stOtherDeatils;
            public string stTotalPriceOrder;
        }

        struct stInformationOrderCar
        {
            public string stIDCarOrder;
            public string stNumberCar;
            public string stCarModelName;
            public string stNameClient;
            public string stAddressClient;
            public string stEmailClient;
            public string stPhoneClient;
            public string stSizeCar;
            public string stServiceCars;
            public string stOtherServiceCar;
            public string stOtherDeatilsCar;
            public string stTotalPriceOrder;
        }

        private List<string> LoadAllLineInformationOrderFromFile (string pathFile)
        {

            List<string> allLinesFromFileInformationOrder = new List<string>(); 

            if (!System.IO.File.Exists(pathFile))
                System.IO.File.Create(pathFile).Close();

            System.IO.StreamReader ReadAllLineFromFile = new System.IO.StreamReader(pathFile);

            string lineInformationOrderFromFile = ""; 

            while((lineInformationOrderFromFile = ReadAllLineFromFile.ReadLine()) !=null)
            {

                allLinesFromFileInformationOrder.Add(lineInformationOrderFromFile); 
            }

            ReadAllLineFromFile.Close();

            return allLinesFromFileInformationOrder; 
        }

        private stInformationOrderCarpet ConvertLineInformationCarpetToDataInformation(List<string> allInformationOrderCarpet)
        {
            stInformationOrderCarpet infoCarpetOrder = new stInformationOrderCarpet();

            if (allInformationOrderCarpet.Count >= 11)
            {
                infoCarpetOrder.stIDCarpetOrder = allInformationOrderCarpet[0];
                infoCarpetOrder.stNameClient = allInformationOrderCarpet[1];
                infoCarpetOrder.stAddressClient = allInformationOrderCarpet[2];
                infoCarpetOrder.stEmailClient = allInformationOrderCarpet[3];
                infoCarpetOrder.stPhoneClient = allInformationOrderCarpet[4];
                infoCarpetOrder.stSizeCarpet = allInformationOrderCarpet[5];
                infoCarpetOrder.stTypeWashCarpet = allInformationOrderCarpet[6];
                infoCarpetOrder.stOtherServiceCarpet = allInformationOrderCarpet[7];
                infoCarpetOrder.stNumberCarpet = allInformationOrderCarpet[8];
                infoCarpetOrder.stOtherDeatils = allInformationOrderCarpet[9];
                infoCarpetOrder.stTotalPriceOrder = allInformationOrderCarpet[10];
            }

            return infoCarpetOrder;
        }

        private List<string> SplitLineToConvertPartsString(string lineInformationOrder, string Separtor)
        {
            List<string> informationAfterSplitLine = new List<string>();

            if (!string.IsNullOrEmpty(lineInformationOrder))
            {
                string[] informationLineAfterSplit = lineInformationOrder.Split(new string[] { Separtor }, StringSplitOptions.RemoveEmptyEntries);
                informationAfterSplitLine.AddRange(informationLineAfterSplit);
            }
            return informationAfterSplitLine;
        }

        private List<stInformationOrderCarpet> pushAllInformationOrderCarpetToListStructure()
        {
            List<stInformationOrderCarpet> allInformationOrderCarpet = new List<stInformationOrderCarpet>();
            List<string> InformationLineOrderCarpetFromFile = LoadAllLineInformationOrderFromFile(_kPATH_FILE_NAME_CARPET_ORDERS);

            foreach (string lineInformationCarpet in InformationLineOrderCarpetFromFile)
            {
                allInformationOrderCarpet.Add(ConvertLineInformationCarpetToDataInformation(SplitLineToConvertPartsString(lineInformationCarpet , "&&//&&")));
            }
            return allInformationOrderCarpet;

        }
      
        private void psuhAllInformationOrderToListViewCarpet()
        {

            List<stInformationOrderCarpet> allInformationOrderCarpet = pushAllInformationOrderCarpetToListStructure();

            foreach (stInformationOrderCarpet infoOneOrder in allInformationOrderCarpet)
            {
                ListViewItem LVICarpet = new ListViewItem(infoOneOrder.stIDCarpetOrder);

                LVICarpet.SubItems.Add(infoOneOrder.stEmailClient);
                LVICarpet.SubItems.Add(infoOneOrder.stAddressClient);
                LVICarpet.SubItems.Add(infoOneOrder.stEmailClient);
                LVICarpet.SubItems.Add(infoOneOrder.stPhoneClient);
                LVICarpet.SubItems.Add(infoOneOrder.stSizeCarpet);
                LVICarpet.SubItems.Add(infoOneOrder.stTypeWashCarpet);
                LVICarpet.SubItems.Add(infoOneOrder.stOtherServiceCarpet);
                LVICarpet.SubItems.Add(infoOneOrder.stNumberCarpet);
                LVICarpet.SubItems.Add(infoOneOrder.stOtherDeatils);
                LVICarpet.SubItems.Add(infoOneOrder.stTotalPriceOrder);

                ListViewAllOrdersCarpet.Items.Add(LVICarpet);

            }

        }
    
        private bool isFoundTheOrderByIDCarpet(string ID)
        {

            List<stInformationOrderCarpet> informationOrderCarpet = pushAllInformationOrderCarpetToListStructure();

            foreach (stInformationOrderCarpet infoOrderCarpet in informationOrderCarpet)
            {
                if (infoOrderCarpet.stIDCarpetOrder == ID) return true; 

            }

            return false; 
        }

        private void resetBackColorAndForeColorInListView()
        {
            for (int counter = 0; counter < ListViewAllOrdersCarpet.Items.Count; counter++)
            {
                ListViewAllOrdersCarpet.Items[counter].BackColor = Color.White;
                ListViewAllOrdersCarpet.Items[counter].ForeColor = Color.Black;
            }
        }
      
    /* /*   private void SearchOrderByIDOrder (string IDOrder)
      
        {

        //  List<stInformationOrderCarpet> informationOrderCarpet = pushAllInformationOrderCarpetToListStructure();

            resetBackColorAndForeColorInListView();

       /*  

            if (ListViewAllOrdersCarpet.Items[0].Text == IDOrder)
            {
                ListViewAllOrdersCarpet.Items[0].BackColor = Color.Yellow;
                ListViewAllOrdersCarpet.Items[0].ForeColor = Color.Black;
                ListViewAllOrdersCarpet.Items[0].Focused = true;
                ListViewAllOrdersCarpet.Items[0].EnsureVisible();
                return; 
            }
            
            for (int counter = 0; counter < ListViewAllOrdersCarpet.Items.Count; counter++)
           
            {
                if (isFoundTheOrderByIDCarpet(ListViewAllOrdersCarpet.Items[counter].Text))
                {
                    ListViewAllOrdersCarpet.Items[counter].BackColor = Color.Yellow;
                    ListViewAllOrdersCarpet.Items[counter].ForeColor = Color.Black;
                    ListViewAllOrdersCarpet.Items[counter].Focused = true;
                    ListViewAllOrdersCarpet.Items[counter].EnsureVisible();
                    return; 
                }

            }

         
        }*/
     


        private void GRadioButtonCarpetsSectionList_CheckedChanged(object sender, EventArgs e)
        {
            if(GRadioButtonCarpetsSectionList.Checked)
            {
                PanelMainListViewAllOrdersCarpet.Visible = true;
                PanelMainListViewAllOrdersCar.Visible = false;

            }
        }

        private void GRadioButtonCarsSectionList_CheckedChanged(object sender, EventArgs e)
        {
            if (GRadioButtonCarsSectionList.Checked)
            {
                PanelMainListViewAllOrdersCarpet.Visible = false;
                PanelMainListViewAllOrdersCar.Visible = true;

            }
        }

        private void GButtonSearchByIDOrderCarpet_Click(object sender, EventArgs e)
        {
            string IdOrder = GTextBoxSearchIDOrderCarpet.Text; 
            SearchOrderByIDOrder(IdOrder);
        }
    }
}
