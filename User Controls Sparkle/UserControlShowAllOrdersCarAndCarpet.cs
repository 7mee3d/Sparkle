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

            //Push Data To List View [ Carpet or Car ] 
            psuhAllInformationOrderToListViewCarpet();
            pushAllInformationOrderCarToListViewCar();

            GRadioButtonCarpetsSectionList.Checked = true; 

        }

      
        // ------------------------------------------- [ Start Constants Section  ] ----------------------------------------------

        private const string _kPATH_FILE_NAME_CARPET_ORDERS = "CarpetsOrders.txt";
        private const string _kPATH_FILE_NAME_CAR_ORDERS = "CarOrders.txt";


        // ------------------------------------------- [ End Constants Section  ] ----------------------------------------------




        //------------------------------------------------------------------------------------------------------------------




        // -------------------------------------------- [ Start Section Genaric Method styling or Reset  ] ----------------------------------------------



        //Genaric Method Load All Lines Files [ Car or Carpet ]
        private List<string> LoadAllLineInformationOrderFromFile(string pathFile)
        {

            List<string> allLinesFromFileInformationOrder = new List<string>();

            if (!System.IO.File.Exists(pathFile))
                System.IO.File.Create(pathFile).Close();

            System.IO.StreamReader ReadAllLineFromFile = new System.IO.StreamReader(pathFile);

            string lineInformationOrderFromFile = "";

            while ((lineInformationOrderFromFile = ReadAllLineFromFile.ReadLine()) != null)
            {

                allLinesFromFileInformationOrder.Add(lineInformationOrderFromFile);
            }

            ReadAllLineFromFile.Close();

            return allLinesFromFileInformationOrder;
        }
      
        //Genaric Method Split Line Information Order Files [ Car or Carpet ]
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

        //Genaric Method Reset All List View Original Color Fore and Back 
        private void resetBackColorAndForeColorInListView()
        {
            for (int counter = 0; counter < ListViewAllOrdersCarpet.Items.Count; counter++)
            {
                ListViewAllOrdersCarpet.Items[counter].BackColor = Color.White;
                ListViewAllOrdersCarpet.Items[counter].ForeColor = Color.Black;
            }
       
        }

        private void TakeAllItemListViewCarpetOrderBackForeColorWhite(int indexStartTakeColorWhite)
        {
            for (int counter = indexStartTakeColorWhite + 1; counter < ListViewAllOrdersCarpet.Items.Count; counter++)
            {
                ListViewAllOrdersCarpet.Items[counter].BackColor = Color.White;
                ListViewAllOrdersCarpet.Items[counter].ForeColor = Color.White;
            }
        }



        // -------------------------------------------- [ End Section Genaric Method styling or Reset  ] ----------------------------------------------




        //------------------------------------------------------------------------------------------------------------------




        // ------------------------------------------- [ Start Section Carpet ] ----------------------------------------------



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
                infoCarpetOrder.stTotalPriceOrder = allInformationOrderCarpet[10] ;
            }

            return infoCarpetOrder;
        }
       
        private List<stInformationOrderCarpet> pushAllInformationOrderCarpetToListStructure()
        {
            List<stInformationOrderCarpet> allInformationOrderCarpet = new List<stInformationOrderCarpet>();

            List<string> InformationLineOrderCarpetFromFile = LoadAllLineInformationOrderFromFile(_kPATH_FILE_NAME_CARPET_ORDERS);

            foreach (string lineInformationCarpet in InformationLineOrderCarpetFromFile)
            {
                allInformationOrderCarpet.Add(ConvertLineInformationCarpetToDataInformation(SplitLineToConvertPartsString(lineInformationCarpet, "&&//&&")));
            }

            return allInformationOrderCarpet;

        }
     
        private void psuhAllInformationOrderToListViewCarpet()
        {

            List<stInformationOrderCarpet> allInformationOrderCarpet = pushAllInformationOrderCarpetToListStructure();

            foreach (stInformationOrderCarpet infoOneOrder in allInformationOrderCarpet)
            {
                ListViewItem LVICarpet = new ListViewItem(infoOneOrder.stIDCarpetOrder);

                LVICarpet.SubItems.Add(infoOneOrder.stNameClient);
                LVICarpet.SubItems.Add(infoOneOrder.stAddressClient);
                LVICarpet.SubItems.Add(infoOneOrder.stEmailClient);
                LVICarpet.SubItems.Add(infoOneOrder.stPhoneClient);
                LVICarpet.SubItems.Add(infoOneOrder.stSizeCarpet);
                LVICarpet.SubItems.Add(infoOneOrder.stTypeWashCarpet);
                LVICarpet.SubItems.Add(infoOneOrder.stOtherServiceCarpet);
                LVICarpet.SubItems.Add(infoOneOrder.stNumberCarpet);
                LVICarpet.SubItems.Add(infoOneOrder.stOtherDeatils);
                LVICarpet.SubItems.Add(infoOneOrder.stTotalPriceOrder+"$");

                ListViewAllOrdersCarpet.Items.Add(LVICarpet);

            }

        }
   
        private void SearchOrderByIDOrderCarpetSection(string IDOrder)
        {


            /*  if (IDOrder == "")
              {
                  resetBackColorAndForeColorInListView();
                  return; 
              }*/

            resetBackColorAndForeColorInListView();

            if (ListViewAllOrdersCarpet.Items[0].SubItems[0].Text == IDOrder)
            {
                ListViewAllOrdersCarpet.Items[0].BackColor = Color.Yellow;
                ListViewAllOrdersCarpet.Items[0].ForeColor = Color.Black;
                ListViewAllOrdersCarpet.Items[0].Focused = true;
                ListViewAllOrdersCarpet.Items[0].EnsureVisible();
                TakeAllItemListViewCarpetOrderBackForeColorWhite(0);
                return;
            }
            else
            {
                ListViewAllOrdersCarpet.Items[0].BackColor = Color.White;
                ListViewAllOrdersCarpet.Items[0].ForeColor = Color.White;
            }

                for (int counter = 1; counter < ListViewAllOrdersCarpet.Items.Count; counter++)

                {
                    ListViewItem LVI = ListViewAllOrdersCarpet.Items[0];

                    //Nituce this statment Vheck the List vew not structure
                    if (ListViewAllOrdersCarpet.Items[counter].Text == IDOrder)
                    {
                        ListViewAllOrdersCarpet.Items[counter].BackColor = Color.Yellow;
                        ListViewAllOrdersCarpet.Items[counter].ForeColor = Color.Black;
                        ListViewAllOrdersCarpet.Items[counter].Focused = true;
                        ListViewAllOrdersCarpet.Items[counter].EnsureVisible();
                        //ListViewAllOrdersCarpet.Scrollable = false;

                        TakeAllItemListViewCarpetOrderBackForeColorWhite(counter);


                        return;
                    }
                    else
                    {
                        ListViewAllOrdersCarpet.Items[counter].BackColor = Color.White;
                        ListViewAllOrdersCarpet.Items[counter].ForeColor = Color.White;
                    }

                }


        }




        // ------------------------------------------- [ End Section Carpet ] ----------------------------------------------





        //------------------------------------------------------------------------------------------------------------------





        // ------------------------------------------- [ Start Section Car ] ----------------------------------------------



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

            private stInformationOrderCar ConvertLineInformationCarToDataInformation (List<string> allInformationOrderCarString)
        {

            stInformationOrderCar allInformationOrderCar = new stInformationOrderCar();

            if (allInformationOrderCarString.Count >= 12)
            {

                allInformationOrderCar.stIDCarOrder = allInformationOrderCarString[0];
                allInformationOrderCar.stNumberCar = allInformationOrderCarString[1];
                allInformationOrderCar.stCarModelName = allInformationOrderCarString[2];
                allInformationOrderCar.stNameClient = allInformationOrderCarString[3];
                allInformationOrderCar.stAddressClient = allInformationOrderCarString[4];
                allInformationOrderCar.stEmailClient = allInformationOrderCarString[5];
                allInformationOrderCar.stPhoneClient = allInformationOrderCarString[6];
                allInformationOrderCar.stSizeCar = allInformationOrderCarString[7];
                allInformationOrderCar.stServiceCars = allInformationOrderCarString[8];
                allInformationOrderCar.stOtherServiceCar = allInformationOrderCarString[9];
                allInformationOrderCar.stTotalPriceOrder = allInformationOrderCarString[10];
                allInformationOrderCar.stOtherDeatilsCar = allInformationOrderCarString[11];
            }

            return allInformationOrderCar;

        }
       
            private List<stInformationOrderCar> pushAllInformationOrderCarToListSturcture()
        {
            List<string> LoadAllLineInforationOrderCar = LoadAllLineInformationOrderFromFile(_kPATH_FILE_NAME_CAR_ORDERS);
            List<stInformationOrderCar> allInformationOrderCar = new List<stInformationOrderCar>(); 

            foreach(string lineInoformationOrderCar in LoadAllLineInforationOrderCar)
            {
                allInformationOrderCar.Add(ConvertLineInformationCarToDataInformation(SplitLineToConvertPartsString(lineInoformationOrderCar, "#|||#")));
            }

            return allInformationOrderCar;
        }
     
            private void pushAllInformationOrderCarToListViewCar ()
        {

            List<stInformationOrderCar> allInformationOrderCar = pushAllInformationOrderCarToListSturcture();
            
            foreach (stInformationOrderCar infoCarOrder in allInformationOrderCar)
            {
                ListViewItem LVI = new ListViewItem(infoCarOrder.stIDCarOrder);

                LVI.SubItems.Add(infoCarOrder.stNumberCar);
                LVI.SubItems.Add(infoCarOrder.stCarModelName);
                LVI.SubItems.Add(infoCarOrder.stNameClient);
                LVI.SubItems.Add(infoCarOrder.stAddressClient);
                LVI.SubItems.Add(infoCarOrder.stEmailClient);
                LVI.SubItems.Add(infoCarOrder.stPhoneClient);
                LVI.SubItems.Add(infoCarOrder.stSizeCar);
                LVI.SubItems.Add(infoCarOrder.stServiceCars);
                LVI.SubItems.Add(infoCarOrder.stOtherServiceCar);
                LVI.SubItems.Add(infoCarOrder.stTotalPriceOrder);

                ListViewAllOrdersCar.Items.Add(LVI); 

            }
        
        }





        // ------------------------------------------- [ End Section Car ] ----------------------------------------------




        //------------------------------------------------------------------------------------------------------------------

      
        
        // ------------------------------------------- [ Start Section Controls ] ----------------------------------------------

       
        
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
            GTextBoxSearchIDOrderCarpet.Clear();

            SearchOrderByIDOrderCarpetSection(IdOrder);
        }


        private void GTextBoxSearchIDOrderCarpet_Click_1(object sender, EventArgs e)
        {
            // ListViewAllOrdersCarpet.Scrollable = true;
            resetBackColorAndForeColorInListView();
        }



        // ------------------------------------------- [ End Section Controls ] ----------------------------------------------


    }
}
