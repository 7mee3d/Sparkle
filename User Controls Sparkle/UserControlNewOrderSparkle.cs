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
    public partial class UserControlNewOrderSparkle : UserControl
    {


          //Path File 
        const string kPATH_FILE_CARPETS_ORDERS = "CarpetsOrders.txt";
        const string kPATH_FILE_CARS_ORDERS = "CarOrders.txt";

        bool[] FlagsFillTextBoxInformationCarpet = { false , false , false , false , false , false};
        
        public UserControlNewOrderSparkle()
        {
            InitializeComponent();
            GTextBoxIDOrderCarpet.Text = (lastIDOrderInFile() + 1).ToString();
            GTextBoxIDOrderCarSection.Text = (TakeLastIDOrderCarSection() + 1).ToString();
            GTextBoxIDOrderCarpet.Enabled = false;
            GTextBoxIDOrderCarSection.Enabled = false;
            GRadioButtonCarpetsSection.Checked = true; 
        }


        //Reset All Text Boxies
        private void ResetAllTextBoxInUserControl ()
        {
            foreach (Control outterControls in this.Controls)
            {

                if(outterControls is Guna2Panel G2P)
                {
                    foreach (Control innerControls in G2P.Controls)
                    {
                        if (innerControls is Guna2TextBox G2TB && (G2TB != GTextBoxIDOrderCarpet) && (G2TB != GTextBoxIDOrderCarSection))
                            G2TB.Text = ""; 

                    }
                }
            }
        }

        private void resetAllCheckBoxiesOtherServive()
        {
            GCheckBoxOtherServicesEngineCleaning.Checked = false;
            GCheckBoxOtherServicesExteriorWash.Checked = false;
            GCheckBoxOtherServicesPolishing.Checked = false;
            GCheckBoxOtherServicesInteriorWash.Checked = false;

            updateTotalPriceSectionCarWash();
        }

        private void ResetAllControlPanel ()
        {

            foreach (Control outterControl in this.Controls )
            {
                if(outterControl is Guna2Panel G2P )
                {
                    // Reset All CheckBox or Radio Button and Numeric Up Down in the Panel Paerant
                    foreach (Control InnerControl in outterControl.Controls)
                    {
                        if (InnerControl is Guna2RadioButton R2B)
                            R2B.Checked = false;

                        if (InnerControl is Guna2CheckBox G2CB)
                            G2CB.Checked = false;

                        if (InnerControl is Guna2NumericUpDown G2NUD)
                            G2NUD.Value = 1;

                        // Reset All CheckBox or Radio Button and Numeric Up Down in the Panel child 
                        if (InnerControl is Guna2Panel G2P2)
                            foreach (Control InnerInnerControl in InnerControl.Controls)
                            {
                                if (InnerInnerControl is Guna2RadioButton R2B2)
                                    R2B2.Checked = false;

                                if (InnerInnerControl is Guna2CheckBox G2CB2)
                                    G2CB2.Checked = false;

                                if (InnerInnerControl is Guna2NumericUpDown G2NUD2)
                                    G2NUD2.Value = 1; 

                            }
                    }
                }
            }
            errorProviderCarpet.Clear();
            CoreectProviderCarpet.Clear();
            errorProviderCarSection.Clear();
            CorrectProvidorCarSection.Clear();
        }


        //------------------------------ [Start Section Carpet]-------------------------------


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
        
        private List<string> LoadAllInformationOrderCarpetFromFile()
        {
            List<string> allLinesInformationCarpetOrders = new List<string>(); 

            if (!System.IO.File.Exists(kPATH_FILE_CARPETS_ORDERS))
                System.IO.File.Create(kPATH_FILE_CARPETS_ORDERS).Close();

            System.IO.StreamReader ReadAllINformationOrderCarpet = new System.IO.StreamReader(kPATH_FILE_CARPETS_ORDERS);

            string lineInformationDetailsCarpetOrder = ""; 
            while((lineInformationDetailsCarpetOrder = ReadAllINformationOrderCarpet.ReadLine())!= null)
            {
                allLinesInformationCarpetOrders.Add(lineInformationDetailsCarpetOrder);
            }

            ReadAllINformationOrderCarpet.Close(); 

            return allLinesInformationCarpetOrders; 
        }

        private stInformationOrderCarpet ConvertLineInformationOrderToData (List<string> allInformationOrderCarpet )
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
      
        private string ConvertDataInformationOrderCarpetToLine (stInformationOrderCarpet informationOrderCarpet , string Separtor = "&&//&&")
        {
            string lineInformationOrder = "";

            lineInformationOrder += informationOrderCarpet.stIDCarpetOrder + Separtor; 
            lineInformationOrder += informationOrderCarpet.stNameClient + Separtor; 
            lineInformationOrder += informationOrderCarpet.stAddressClient + Separtor; 
            lineInformationOrder += informationOrderCarpet.stEmailClient + Separtor; 
            lineInformationOrder += informationOrderCarpet.stPhoneClient + Separtor; 
            lineInformationOrder += informationOrderCarpet.stSizeCarpet + Separtor; 
            lineInformationOrder += informationOrderCarpet.stTypeWashCarpet + Separtor; 
            lineInformationOrder += informationOrderCarpet.stOtherServiceCarpet + Separtor; 
            lineInformationOrder += informationOrderCarpet.stNumberCarpet + Separtor; 
            lineInformationOrder += informationOrderCarpet.stOtherDeatils + Separtor; 
            lineInformationOrder += informationOrderCarpet.stTotalPriceOrder;

            return lineInformationOrder; 
        }
        
        private string ConvertListInformationOrderToLine (List<string> informationOrder , string Separtor = "&&//&&")
        {
            string lineInformationOrder = "";

            lineInformationOrder += informationOrder[0] + Separtor;
            lineInformationOrder += informationOrder[1] + Separtor;
            lineInformationOrder += informationOrder[2] + Separtor;
            lineInformationOrder += informationOrder[3] + Separtor;
            lineInformationOrder += informationOrder[4] + Separtor;
            lineInformationOrder += informationOrder[5] + Separtor;
            lineInformationOrder += informationOrder[6] + Separtor;
            lineInformationOrder += informationOrder[7] + Separtor;
            lineInformationOrder += informationOrder[8] + Separtor;
            lineInformationOrder += informationOrder[9] + Separtor;
            lineInformationOrder += informationOrder[10]  ;


            return lineInformationOrder; 
        }
     
        private List<string> SplitLineInformationOrderCarpet (string lineInformationOrderCarpet)
        {
            List<string> allInformationOrderCarpetAfterSplit = new List<string>(); 

            if (!string.IsNullOrEmpty(lineInformationOrderCarpet))
            {
                allInformationOrderCarpetAfterSplit.AddRange(lineInformationOrderCarpet.Split( new string[] { "&&//&&" }, StringSplitOptions.RemoveEmptyEntries));
            }

            return allInformationOrderCarpetAfterSplit; 
        }
        
        private List<stInformationOrderCarpet> pushAllInformationOrderCarpetToListSturtcure ()
        {
            List<string> allInformationLineOrders = LoadAllInformationOrderCarpetFromFile();
            List<stInformationOrderCarpet> allInformationOrderStucture = new List<stInformationOrderCarpet>(); 

            foreach(string lineInfoOrder in allInformationLineOrders )
            {
                allInformationOrderStucture.Add(ConvertLineInformationOrderToData(SplitLineInformationOrderCarpet(lineInfoOrder)));
            }
            return allInformationOrderStucture; 

        }
      
        private int lastIDOrderInFile()
        {
            /*  List<stInformationOrderCarpet> allInformationOrderStucture = pushAllInformationOrderCarpetToListSturtcure();

              if (allInformationOrderStucture.Count > 0)
                  return (Convert.ToInt32(allInformationOrderStucture[allInformationOrderStucture.Count - 1].stIDCarpetOrder));
              else
                  return 0; */

            List<string> allLinesInformationOrder = LoadAllInformationOrderCarpetFromFile();
            if (allLinesInformationOrder.Count > 0)
            {
                List<string> informationAfterSplit = SplitLineInformationOrderCarpet(allLinesInformationOrder[allLinesInformationOrder.Count - 1]);
                return (Convert.ToInt32(informationAfterSplit[0]));
            }
            else
                return 0;
        }

        private void SaveAllInformationOrderAfterConvertDataToLineTOFile (List<string> informationCarpet)
        {
            string lineInformation = ConvertListInformationOrderToLine(informationCarpet, "&&//&&");

            if (!System.IO.File.Exists(kPATH_FILE_CARPETS_ORDERS))
                System.IO.File.Create(kPATH_FILE_CARPETS_ORDERS).Close();

            System.IO.StreamWriter WriteLineToFile = new System.IO.StreamWriter(kPATH_FILE_CARPETS_ORDERS , true );

            if (!string.IsNullOrEmpty(lineInformation))
            {
                WriteLineToFile.WriteLine(lineInformation);

            }
            WriteLineToFile.Close();

        }
      
        private void pushAllInformationOrderCarpetToFile (List<stInformationOrderCarpet> allInformationOrderCarpet )
        {
            if (!System.IO.File.Exists(kPATH_FILE_CARPETS_ORDERS))
                System.IO.File.Create(kPATH_FILE_CARPETS_ORDERS).Close();

            System.IO.StreamWriter WriteAllInformationOrderCarpetToFile = new System.IO.StreamWriter(kPATH_FILE_CARPETS_ORDERS);

            foreach(stInformationOrderCarpet infoOneOrderCarpet in allInformationOrderCarpet)
            {
                WriteAllInformationOrderCarpetToFile.WriteLine(ConvertDataInformationOrderCarpetToLine(infoOneOrderCarpet, "&&//&&"));
            }

            WriteAllInformationOrderCarpetToFile.Close(); 

        }

        private List<string> allInformationOptionsCarpet()
        {
            List<string> allInformationCarpet = new List<string>();

            allInformationCarpet.Add(((lastIDOrderInFile()) + 1).ToString());
            allInformationCarpet.Add(GTextBoxNameClientSectionCarpet.Text);
            allInformationCarpet.Add(GTextBoxAddressClientSectionCarpet.Text);
            allInformationCarpet.Add(GTextBoxEmailClientSectionCarpet.Text);
            allInformationCarpet.Add(GTextBoxPhoneClientSectionCarpet.Text);
            allInformationCarpet.Add(returnWordSizeCarpt());
            allInformationCarpet.Add(returnWordTypeWash());
            allInformationCarpet.Add(returnTextOtherServiceCarpet());
            allInformationCarpet.Add(GNumricUPDownNumberCarpets.Value.ToString());
            allInformationCarpet.Add(GTextBoxOtherSeviceCarpet.Text == "" ?"None" : GTextBoxOtherSeviceCarpet.Text);
            allInformationCarpet.Add(calcTotalPriveAllServiceCarpet().ToString() );

            return allInformationCarpet;
        }



        //------------------------------ [End Section Carpet]-------------------------------





        //------------------------------ [Start Section Car]-------------------------------


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

        private List<string> LoadAllInformationOrderCarSectionFromFile ()
        {
            List<string> allLinesLoadAllFromFileInformationAllOrders = new List<string>();

            if (!System.IO.File.Exists(kPATH_FILE_CARS_ORDERS))
                System.IO.File.Create(kPATH_FILE_CARS_ORDERS).Close();

            System.IO.StreamReader ReadAllInformationOrderCar = new System.IO.StreamReader(kPATH_FILE_CARS_ORDERS);

            string lineInformationOrderCar = "";

            while((lineInformationOrderCar = ReadAllInformationOrderCar.ReadLine() ) != null )
            {
                if(!String.IsNullOrEmpty(lineInformationOrderCar))
                allLinesLoadAllFromFileInformationAllOrders.Add(lineInformationOrderCar);
            }

            ReadAllInformationOrderCar.Close();

            return allLinesLoadAllFromFileInformationAllOrders; 
        }
      
        private stInformationOrderCar ConvertAllInformtionLineToData(List<string> allInformationOrderCarString)
        {
            stInformationOrderCar allInformationOrderCar = new stInformationOrderCar();

            if(allInformationOrderCarString.Count >=12)
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
      
        private string ConvertDataInformationOrderCarToLine(stInformationOrderCar informationOrderCar , string Separtor ="#|||#" )
        {
            string lineInformationOrderCar = "";

            lineInformationOrderCar += informationOrderCar.stIDCarOrder + Separtor; 
            lineInformationOrderCar += informationOrderCar.stNumberCar + Separtor; 
            lineInformationOrderCar += informationOrderCar.stCarModelName + Separtor; 
            lineInformationOrderCar += informationOrderCar.stNameClient + Separtor; 
            lineInformationOrderCar += informationOrderCar.stAddressClient + Separtor; 
            lineInformationOrderCar += informationOrderCar.stEmailClient + Separtor; 
            lineInformationOrderCar += informationOrderCar.stPhoneClient + Separtor; 
            lineInformationOrderCar += informationOrderCar.stSizeCar + Separtor; 
            lineInformationOrderCar += informationOrderCar.stServiceCars + Separtor; 
            lineInformationOrderCar += informationOrderCar.stOtherServiceCar + Separtor; 
            lineInformationOrderCar += informationOrderCar.stTotalPriceOrder + Separtor; 
            lineInformationOrderCar += informationOrderCar.stOtherDeatilsCar;

            return lineInformationOrderCar; 
        }

        private List<string> SplitLineInformationOrderCar (string LineInformationOrderCar )
        {
            List<string> allInformationAfterSplitOrderCar  = new List<string>();

            if (!string.IsNullOrEmpty(LineInformationOrderCar))
            {
                allInformationAfterSplitOrderCar.AddRange(LineInformationOrderCar.Split(new string[] { "#|||#" }, StringSplitOptions.RemoveEmptyEntries));
            }

            return allInformationAfterSplitOrderCar;
        }
      
        private List<stInformationOrderCar> pushAllInformationOrderCarToStructure()
        {
            List<string> allInformationLineOrderCar = LoadAllInformationOrderCarSectionFromFile();
            List<stInformationOrderCar> allInformationOrderCarSturcture = new List<stInformationOrderCar>();

            foreach (string lineInformationCarOrder in allInformationLineOrderCar)
            {
                allInformationOrderCarSturcture.Add(ConvertAllInformtionLineToData(SplitLineInformationOrderCar(lineInformationCarOrder)));
            }

            return allInformationOrderCarSturcture; 
        }
    
        private string ConvertListStringToLineInformationCarOrder (List<string> allInformationCarOrderInformation, string Separtor = "#|||#")
        {
            string lineInformationCarOrder = "";
            lineInformationCarOrder += allInformationCarOrderInformation[0] + Separtor; 
            lineInformationCarOrder += allInformationCarOrderInformation[1] + Separtor; 
            lineInformationCarOrder += allInformationCarOrderInformation[2] + Separtor; 
            lineInformationCarOrder += allInformationCarOrderInformation[3] + Separtor; 
            lineInformationCarOrder += allInformationCarOrderInformation[4] + Separtor; 
            lineInformationCarOrder += allInformationCarOrderInformation[5] + Separtor; 
            lineInformationCarOrder += allInformationCarOrderInformation[6] + Separtor; 
            lineInformationCarOrder += allInformationCarOrderInformation[7] + Separtor; 
            lineInformationCarOrder += allInformationCarOrderInformation[8] + Separtor; 
            lineInformationCarOrder += allInformationCarOrderInformation[9] + Separtor; 
            lineInformationCarOrder += allInformationCarOrderInformation[10] + Separtor; 
            lineInformationCarOrder += allInformationCarOrderInformation[11] ;

            return lineInformationCarOrder; 
        }
    
        private void SaveAllInformationOrderCarToFile(List<string> allInformationCarOrderInformation)
        {
            if (!System.IO.File.Exists(kPATH_FILE_CARS_ORDERS))
                System.IO.File.Create(kPATH_FILE_CARS_ORDERS).Close();

            System.IO.StreamWriter WriteAllInformationOrderCarToFile = new System.IO.StreamWriter(kPATH_FILE_CARS_ORDERS   , true );

            string lineInfroamtionCarOrder = ConvertListStringToLineInformationCarOrder(allInformationCarOrderInformation);

            if (!string.IsNullOrEmpty(lineInfroamtionCarOrder))
                WriteAllInformationOrderCarToFile.WriteLine(lineInfroamtionCarOrder);

            WriteAllInformationOrderCarToFile.Close(); 


        }
     
       private List<string> AllInformationStringCarSection ()
        {

            List<string> allInformationCarSection = new List<string>();

            allInformationCarSection.Add(GTextBoxIDOrderCarSection.Text);
            allInformationCarSection.Add(GTextBoxNumberCar.Text);
            allInformationCarSection.Add(GTextBoxCarModel.Text);
            allInformationCarSection.Add(GTextBoxNameClientCarSection.Text);
            allInformationCarSection.Add(GTextBoxAddressClientCarSection.Text);
            allInformationCarSection.Add(GTextBoxEmailClientCarSection.Text);
            allInformationCarSection.Add(GTextBoxPhoneClientCarSection.Text);
            allInformationCarSection.Add(returnWordSizeCar());
            allInformationCarSection.Add(returnTypeWashCarWord());
            allInformationCarSection.Add(returnLineWordServiceCar());
            allInformationCarSection.Add(TotalPriceCarSection.Text);
            allInformationCarSection.Add(GTextBoxCarDetailsCarSection.Text);

            return allInformationCarSection;

        }

       private int TakeLastIDOrderCarSection ()
        {
            List<string> allInformationLineSectionCar = LoadAllInformationOrderCarSectionFromFile();

            if (allInformationLineSectionCar.Count > 0)
            {
                List<string> SplitLineInformationOneLine = SplitLineInformationOrderCar(allInformationLineSectionCar[allInformationLineSectionCar.Count - 1]);
                return Convert.ToInt32(SplitLineInformationOneLine[0]);
            }
            else
                return 0; 
        }




        //------------------------------ [End Section Car]-------------------------------




        //------------------------------ [ Start Draw Line Section ]-------------------------------


        private void DrawLineVarticalBetweenSectionAndInformationClient (PaintEventArgs event1 ){

            //Color Pen to be Draw line 
            Color WhiteGreen = Color.FromArgb(255, 4, 187, 156);

            Pen pen = new Pen(WhiteGreen);
            //Bold Pen to Be Draw Line
            pen.Width = 4;

            //Points Line To Be Draw 
            Point point1 = new Point(590, 300);
            Point point2 = new Point(590, 740);
                
            event1.Graphics.DrawLine(pen, point1, point2);

        }
  
        private void UserControlNewOrderSparkle_Paint(object sender, PaintEventArgs e)
        {
            DrawLineVarticalBetweenSectionAndInformationClient(e);
        }




        //------------------------------ [ End Draw Line Section ]-------------------------------


        private void SwitchRadioButtonVisiblePanelCarAndCarpet(object sender, EventArgs e)
        {
            if (GRadioButtonCarpetsSection.Checked)
            {
                GPanelOptionsCarpets.Visible = true;
                GPanelCarsOptions.Visible = false;
                TextNoneAnyOption.Visible = false;
                GPnaelIDOrderCarpet.Visible = true;
                PanelFillInformationClientsCarpet.Visible = true;
                GPnaelInfroamtionOrderCar.Visible = false;
                GPnaelIDOrderCar.Visible = false;
                GPictureBoxCarpetGIF.Visible = true;
                GPictureBoxCarGIF.Visible = false;

            }

            else if (GRadioButtonCarsSection.Checked)
            {
                GPanelOptionsCarpets.Visible = false;
                GPanelCarsOptions.Visible = true;
                TextNoneAnyOption.Visible = false;
                GPnaelIDOrderCarpet.Visible = false;
                PanelFillInformationClientsCarpet.Visible = false;

                GPnaelInfroamtionOrderCar.Visible = true;
                GPnaelIDOrderCar.Visible = true;

                GPictureBoxCarpetGIF.Visible = false;
                GPictureBoxCarGIF.Visible = true;
            }
        }



        //------------------------------ [Start Section Car Options]-------------------------------



        private int calcSizeCarPrice  ()
        {
            int SizePriceCar = 0;

            if (GRadioButtonSizeSmallCar.Checked)
                SizePriceCar = 5;

            if (GRadioButtonMediumCar.Checked)
                SizePriceCar = 10;

            if (GRadioButtonSizeLargeCar.Checked)
                SizePriceCar = 15;

            return SizePriceCar; 
        }

        private string returnWordSizeCar ()
        {
            string sizeCarWord = "";

            if (GRadioButtonSizeSmallCar.Checked)
                sizeCarWord = "Small Car";

            if (GRadioButtonMediumCar.Checked)
                sizeCarWord = "Medium Car";
                    
            if (GRadioButtonSizeLargeCar.Checked)
                sizeCarWord = "Large Car";

            return sizeCarWord;
        }


       /*   private void InitialValueAfterClickButtonNewOrder ()
        {
            if (GRadioButtonCarsSection.Checked)
                GRadioButtonSizeSmallCar.Checked = true; 
            
        }*/
      

        private int calcServiceWashPriceCar()
        {
            int priceTypeWashCar = 0;

            if (GCheckBoxServicesFullWash.Checked)
                priceTypeWashCar += 30;

            return priceTypeWashCar; 


        }
     
        private string returnTypeWashCarWord()
        {
            string wordTypeWashCar  = "";

            if (GCheckBoxServicesFullWash.Checked)
                wordTypeWashCar = "Full Wash";

            if (!GCheckBoxServicesFullWash.Checked)
                wordTypeWashCar = "None";


            return wordTypeWashCar;


        }
   
        private int calcOtherServiceWashPriceCar ()
        {

            int priceOtherSeviceWashCar = 0;

            if (GCheckBoxOtherServicesExteriorWash.Checked)
                priceOtherSeviceWashCar += 5;

            if (GCheckBoxOtherServicesInteriorWash.Checked)
                priceOtherSeviceWashCar += 5;

            if (GCheckBoxOtherServicesEngineCleaning.Checked)
                priceOtherSeviceWashCar += 2;

            if (GCheckBoxOtherServicesPolishing.Checked)
                priceOtherSeviceWashCar += 5;

            return priceOtherSeviceWashCar;


        }
       
        private string returnLineWordServiceCar ()
        {

            string wordServiceCar = "";

            if (GCheckBoxServicesFullWash.Checked)
            {
               return  "None";

            }

            if (GCheckBoxOtherServicesExteriorWash.Checked)
                wordServiceCar += "Exterior Wash";

            if (GCheckBoxOtherServicesInteriorWash.Checked)
                wordServiceCar += "Interior Wash";

            if (GCheckBoxOtherServicesEngineCleaning.Checked)
                wordServiceCar += "Engine Cleaning";

            if (GCheckBoxOtherServicesPolishing.Checked)
                wordServiceCar += "Polishing";

            return wordServiceCar;


        }

        private string returnLineWordServiceCarSpecialFinialBillForm()
        {

            string wordServiceCar = "";

            if (GCheckBoxServicesFullWash.Checked)
            {
                return "None";

            }

            if (GCheckBoxOtherServicesExteriorWash.Checked)
                wordServiceCar += "Exterior Wash\n";

            if (GCheckBoxOtherServicesInteriorWash.Checked)
                wordServiceCar += "Interior Wash\n";

            if (GCheckBoxOtherServicesEngineCleaning.Checked)
                wordServiceCar += "Engine Cleaning\n";

            if (GCheckBoxOtherServicesPolishing.Checked)
                wordServiceCar += "Polishing\n";

            return wordServiceCar;


        }
     
        private int calcTotalPriceOfWashCar ()
        {
            return (calcSizeCarPrice() + calcServiceWashPriceCar() + calcOtherServiceWashPriceCar()); 
        }

        private void updateTotalPriceSectionCarWash ()
        {
            TotalPriceCarSection.Text = Convert.ToString(calcTotalPriceOfWashCar()) + "$";
        }



        //------------------------------ [End Section Car Options]-------------------------------


       
   

        //------------------------------ [Start Section Carpet Options]-------------------------------




        private int calcPriceSizeCarpet ()
        {
            int totalPriceSizeCarpet = 0;

            if (GRadioButtonSizeCarpetSmall.Checked)
                totalPriceSizeCarpet = 5;

            if (GRadioButtonSizeCarpetMedium.Checked)
                totalPriceSizeCarpet = 10;

            if (GRadioButtonSizeCarpetLarge.Checked)
                totalPriceSizeCarpet = 15;

            return totalPriceSizeCarpet; 
        }

        private string returnWordSizeCarpt()
        {
            string wordSizeCarpet = "";


            if (GRadioButtonSizeCarpetSmall.Checked)
            {
                wordSizeCarpet = "Small";
                FlagsFillTextBoxInformationCarpet[3] = true;
            }

            if (GRadioButtonSizeCarpetMedium.Checked)
            {
                wordSizeCarpet = "Medium";
                FlagsFillTextBoxInformationCarpet[3] = true;
            }

            if (GRadioButtonSizeCarpetLarge.Checked)
            {
                wordSizeCarpet = "Large";
                FlagsFillTextBoxInformationCarpet[3] = true;
            }

            return wordSizeCarpet;
        }

        private int calcPriceTypeWash()
        {

            int totalPriceTypeWash = 0;

            if (GRadioButtonWashTypNormalWash.Checked)
                totalPriceTypeWash = 5;

            if (GRadioButtonWashTypDeepWash.Checked)
                totalPriceTypeWash = 10;

            return totalPriceTypeWash;

        }
       
        private string returnWordTypeWash(){

            string wordTypeWash = "";

            if (GRadioButtonWashTypNormalWash.Checked)
            {
                wordTypeWash = "Normal Wash";
                FlagsFillTextBoxInformationCarpet[4] = true;
            }

            if (GRadioButtonWashTypDeepWash.Checked)
            {
                wordTypeWash = "Deep Wash";
                FlagsFillTextBoxInformationCarpet[4] = true;
            }

            return wordTypeWash; 

        }
    
        private int calcPriceOtherServices ()
        {

            int totalPriceOtherSevices = 0;

            if (GCheckBoxOtherServicesQuickDrying.Checked)
                totalPriceOtherSevices += 5;

            if (GCheckBoxOtherServicesHomeDelivery.Checked)
                totalPriceOtherSevices += 15;

            return totalPriceOtherSevices;
        }

        private string returnTextOtherServiceCarpet()
        {

            string wordOtherSevice = "";

            if (GCheckBoxOtherServicesQuickDrying.Checked)
            {
                wordOtherSevice += " Quick Drying";
                FlagsFillTextBoxInformationCarpet[5] = true;
            }

            if (GCheckBoxOtherServicesHomeDelivery.Checked){

                wordOtherSevice += " Home Delivery";
                FlagsFillTextBoxInformationCarpet[5] = true;

            }

            return wordOtherSevice.TrimStart().TrimEnd();
        }
    
        private int totalNumberCarpetToNeedWashing()
        {
            return (Convert.ToInt32(GNumricUPDownNumberCarpets.Value));
        }

        private int calcTotalPriveAllServiceCarpet()
        {
            return ((calcPriceSizeCarpet() + calcPriceTypeWash() + calcPriceOtherServices()) * totalNumberCarpetToNeedWashing());
        }

        private void updateTotalPriceOfCarpet()
        {
            TotalPriceCarpetSection.Text = Convert.ToString(calcTotalPriveAllServiceCarpet()) + "$";
        }




        //------------------------------ [End Section Carpet Options]-------------------------------







        //------------------------------ [Start Section Controls]-------------------------------


        //Method Button Add Order Now 

        private void OrderNow ()
        {
            if (GRadioButtonCarpetsSection.Checked)
            {

                SaveAllInformationOrderAfterConvertDataToLineTOFile(allInformationOptionsCarpet());
                MessageBox.Show("Done Save Order");
                ResetAllTextBoxInUserControl();

                GTextBoxIDOrderCarpet.Text = (lastIDOrderInFile() + 1).ToString();
               
                ResetAllControlPanel();
              
            }
            else if (GRadioButtonCarsSection.Checked)
            {
                SaveAllInformationOrderCarToFile(AllInformationStringCarSection());
                MessageBox.Show("Done Save Order");

                ResetAllTextBoxInUserControl();

                GTextBoxIDOrderCarSection.Text = (TakeLastIDOrderCarSection() + 1).ToString();
                ResetAllControlPanel();

            }
        }

        private bool checkCharacterDigitOrNot (char Character)
        {
            return (Convert.ToInt32(Character) >= 48 && Convert.ToInt32(Character) <= 57);
        }

        private bool checkTextHaveDigitOrNot (string text)
        {
            foreach (char Character in text)
                if (checkCharacterDigitOrNot(Character)) return true;

            return false;
        }

        private void setErrorAndCorrectControlsTextBoxCarpet (object sender, CancelEventArgs eventCancel , string CaptionError , string CaptionCorrect )
        {
            Guna2TextBox GunaTextBox = sender as Guna2TextBox; 

            if(string.IsNullOrEmpty(GunaTextBox.Text) || checkTextHaveDigitOrNot(GunaTextBox.Text))
            {
                eventCancel.Cancel = true;
                GunaTextBox.Focus();
                CoreectProviderCarpet.SetError(GunaTextBox, "");
                errorProviderCarpet.SetError(GunaTextBox, CaptionError);
            }
            else
            {
                eventCancel.Cancel = false;
                errorProviderCarpet.SetError(GunaTextBox, "");
                CoreectProviderCarpet.SetError(GunaTextBox, CaptionCorrect);
           
            }
        }
      
        private void setErrorAndCorrectControlsTextBoxCarwithoutDigit(object sender, CancelEventArgs eventCancel, string CaptionError, string CaptionCorrect)
        {
            Guna2TextBox GunaTextBox = sender as Guna2TextBox;

            if (string.IsNullOrEmpty(GunaTextBox.Text) || checkTextHaveDigitOrNot(GunaTextBox.Text))
            {
                eventCancel.Cancel = true;
                GunaTextBox.Focus();
                CorrectProvidorCarSection.SetError(GunaTextBox, "");
                errorProviderCarSection.SetError(GunaTextBox, CaptionError);
            }
            else
            {
                eventCancel.Cancel = false;
                errorProviderCarSection.SetError(GunaTextBox, "");
                CorrectProvidorCarSection.SetError(GunaTextBox, CaptionCorrect);

            }
        }

        private void setErrorAndCorrectControlsTextBoxCarWithDigitWithoutLetters(object sender, CancelEventArgs eventCancel, string CaptionError, string CaptionCorrect)
        {
            Guna2TextBox GunaTextBox = sender as Guna2TextBox;

            if (string.IsNullOrEmpty(GunaTextBox.Text) || !checkTextHaveDigitOrNot(GunaTextBox.Text))
            {
                eventCancel.Cancel = true;
                GunaTextBox.Focus();
                CorrectProvidorCarSection.SetError(GunaTextBox, "");
                errorProviderCarSection.SetError(GunaTextBox, CaptionError);
            }
            else
            {
                eventCancel.Cancel = false;
                errorProviderCarSection.SetError(GunaTextBox, "");
                CorrectProvidorCarSection.SetError(GunaTextBox, CaptionCorrect);

            }
        }
    
        private void GCheckBoxOtherServicesInteriorWash_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceSectionCarWash();
        }

        private void GCheckBoxOtherServicesExteriorWash_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceSectionCarWash();
        }

        private void GCheckBoxOtherServicesEngineCleaning_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceSectionCarWash();
        }

        private void GCheckBoxOtherServicesPolishing_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceSectionCarWash();
        }

        private void GRadioButtonSizeCarpetLarge_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceOfCarpet();
        }

        private void GRadioButtonWashTypNormalWash_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceOfCarpet();
        }

        private void GRadioButtonSizeCarpetSmall_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceOfCarpet();
        }

        private void GRadioButtonSizeCarpetMedium_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceOfCarpet();
        }

        private void GRadioButtonWashTypDeepWash_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceOfCarpet();
        }

        private void GCheckBoxOtherServicesQuickDrying_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceOfCarpet();
        }

        private void GCheckBoxOtherServicesHomeDelivery_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceOfCarpet();
        }

        private void GNumricUPDownNumberCarpets_ValueChanged(object sender, EventArgs e)
        {
            updateTotalPriceOfCarpet();
        }

        private void UserControlNewOrderSparkle_Load(object sender, EventArgs e)
        {
            updateTotalPriceSectionCarWash();
        }

        private void GRadioButtonSizeSmallCar_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceSectionCarWash();
        }

        private void GRadioButtonMediumCar_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceSectionCarWash();
        }

        private void GRadioButtonSizeLargeCar_CheckedChanged(object sender, EventArgs e)
        {
            updateTotalPriceSectionCarWash();
        }

        private void GCheckBoxServicesFullWash_CheckedChanged(object sender, EventArgs e)
        {
            if (GCheckBoxServicesFullWash.Checked)
            {
                GPnaelOtherServices.Enabled = false;
                resetAllCheckBoxiesOtherServive();
                updateTotalPriceSectionCarWash();
            }

            if (!GCheckBoxServicesFullWash.Checked)
            {
                GPnaelOtherServices.Enabled = true;
                updateTotalPriceSectionCarWash();
            }
        }
     
        /*private bool ValidateCarpetSection()
        {
            return FlagsFillTextBoxInformationCarpet[0] &&
                   FlagsFillTextBoxInformationCarpet[1] &&
                   FlagsFillTextBoxInformationCarpet[2] &&
                   FlagsFillTextBoxInformationCarpet[3] &&
                   FlagsFillTextBoxInformationCarpet[4] &&
                   FlagsFillTextBoxInformationCarpet[5];
        }*/


        private void ButtonAddNewOrder_Click(object sender, EventArgs e) 
        {
            //setTitleAndSizeAndLocationFormSectionCarpet();


            if (GRadioButtonCarpetsSection.Checked /*&& ValidateCarpetSection()*/) ButtonOrderNowNewForm();
            /* else
             {
                 MessageBox.Show("Cant Complete this operation");
             }*/

            else if (GRadioButtonCarsSection.Checked) ButtonOrderNowNewFormCar();

        }



        //------------------------------ [Start Section Controls Validating ]-------------------------------


        private void GTextBoxNameClientSectionCarpet_Validating(object sender, CancelEventArgs e)
        {
            setErrorAndCorrectControlsTextBoxCarpet(sender, e, "Please do not enter any numbers or leave this field blank. ", "Successful");
            FlagsFillTextBoxInformationCarpet[0] = true;
        }

        private void GTextBoxAddressClientSectionCarpet_Validating(object sender, CancelEventArgs e)
        {
            setErrorAndCorrectControlsTextBoxCarpet(sender, e, "Please do not enter any numbers or leave this field blank. ", "Successful");
            FlagsFillTextBoxInformationCarpet[1] = true;
        }

        private void GTextBoxPhoneClientSectionCarpet_Validating(object sender, CancelEventArgs e)
        {
            setErrorAndCorrectControlsTextBoxCarWithDigitWithoutLetters(sender, e, "Please do not enter any numbers or leave this field blank. ", "Successful");
            FlagsFillTextBoxInformationCarpet[2] = true;
        }

        private void GTextBoxNumberCar_Validating(object sender, CancelEventArgs e)
        {
            setErrorAndCorrectControlsTextBoxCarWithDigitWithoutLetters(sender, e, "Please do not enter any numbers or leave this field blank. ", "Successful"); 
        }

        private void GTextBoxCarModel_Validating(object sender, CancelEventArgs e)
        {
            setErrorAndCorrectControlsTextBoxCarwithoutDigit(sender, e, "Please do not enter any numbers or leave this field blank. ", "Successful");

        }

        private void GTextBoxNameClientCarSection_Validating(object sender, CancelEventArgs e)
        {
            setErrorAndCorrectControlsTextBoxCarwithoutDigit(sender, e, "Please do not enter any numbers or leave this field blank. ", "Successful");

        }

        private void GTextBoxPhoneClientCarSection_Validating(object sender, CancelEventArgs e)
        {
            setErrorAndCorrectControlsTextBoxCarWithDigitWithoutLetters(sender, e, "Please do not enter any numbers or leave this field blank. ", "Successful");

        }

        private void GTextBoxAddressClientCarSection_Validating(object sender, CancelEventArgs e)
        {
            setErrorAndCorrectControlsTextBoxCarwithoutDigit(sender, e, "Please do not enter any numbers or leave this field blank. ", "Successful");

        }

        private void ButtonResetAllOrder_Click(object sender, EventArgs e)
        {
            resetAllCheckBoxiesOtherServive();
            ResetAllControlPanel();
            ResetAllTextBoxInUserControl();
        
        }


        //--------------------------- [End Section Controls Validating ]-------------------------------


        //-------------------------------- [End Section Controls]-------------------------------


        //Decleration The Form -> To Avoid Daplicate The Form Calling 

        Form frmConfirmAddOrderSection;


        //-------------------------------- [Start Section Carpet Create Form Finial Bill ]-------------------------------


        private void setTitleAndSizeAndLocationFormSectionCarpet (Form frmConfirmAddOrderCarpetSection)
        {

            frmConfirmAddOrderCarpetSection.Text = "Confirm Add Order Carpet";
            frmConfirmAddOrderCarpetSection.StartPosition = FormStartPosition.CenterScreen;

            Guna2BorderlessForm GBLEF = new Guna2BorderlessForm() ;
            Guna2ShadowForm G2SF = new Guna2ShadowForm(); 

            GBLEF.BorderRadius = 20;
            G2SF.ShadowColor = Color.FromArgb( 90, 4, 187, 156);
            G2SF.SetShadowForm (frmConfirmAddOrderCarpetSection);

            GBLEF.ContainerControl = frmConfirmAddOrderCarpetSection;

            frmConfirmAddOrderCarpetSection.MinimizeBox = false;
            frmConfirmAddOrderCarpetSection.MaximizeBox = false;
            frmConfirmAddOrderCarpetSection.ControlBox = false;

            frmConfirmAddOrderCarpetSection.BackColor = Color.White;
            frmConfirmAddOrderCarpetSection.Size = new Size (500 , Convert.ToInt32(Math.Round(700.5)) );

            setLabelFinialBill(frmConfirmAddOrderCarpetSection);
      
            setLabelsOrderCarpetSection(frmConfirmAddOrderCarpetSection);
           
        }

        private void setLabelFinialBill(Form frmConfirmAddOrderCarpetSection)
        {
            Label lblFinialBill = new Label();

            lblFinialBill.Text = "Finial Bill";
            lblFinialBill.Font = new Font("Garamond", 35, FontStyle.Bold);
            lblFinialBill.ForeColor = Color.FromArgb(255, 4, 187, 156);
            lblFinialBill.Width = 250;
            lblFinialBill.Height = 100; 
            lblFinialBill.Top = 30;
            lblFinialBill.Left = 140; 
            frmConfirmAddOrderCarpetSection.Controls.Add(lblFinialBill);
        }

        private void setLabelIDOrderAndResultIDOrder (Form frmConfirmAddOrderCarpetSection)
        {
            Label lblIDOrder = new Label();
            Label lblResultIDOrder = new Label();

            // Label ID Order 
           lblIDOrder.Text = "ID Order :";
            lblIDOrder.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblIDOrder.BackColor = Color.Transparent; 
            lblIDOrder.Top = 150;
            lblIDOrder.Left = 10;
            lblIDOrder.Width = 120;
            lblIDOrder.Height = 40;
            lblIDOrder.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label ID Order 
            lblResultIDOrder.Text = GTextBoxIDOrderCarpet.Text;
            lblResultIDOrder.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultIDOrder.Top = 150;
            lblResultIDOrder.Left = 130;
            lblResultIDOrder.Width = 50;
      
            lblIDOrder.Height = 20;
            
            lblResultIDOrder.BackColor = Color.Transparent;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblIDOrder);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultIDOrder);

        }
      
        private void setLabelNameClientAndResultNameClientCarpet (Form frmConfirmAddOrderCarpetSection)
        {
            Label lblNameClient = new Label();
            Label lblResultNameClient = new Label();


            //Label Name Client 
            lblNameClient.Text = "Name Client :";
            lblNameClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblNameClient.Top = 210;
            lblNameClient.Width = 150;
            lblNameClient.Left = 10;
            lblNameClient.Height = 40; 
            lblNameClient.BackColor = Color.Transparent;
            lblNameClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Name Client 
            lblResultNameClient.Text = GTextBoxNameClientSectionCarpet.Text;
            lblResultNameClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultNameClient.Top = 210;
            lblResultNameClient.Left = 160;
            lblResultNameClient.Width = 150;
            lblResultNameClient.BackColor = Color.Transparent;
            lblResultNameClient.Height = 40;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblNameClient);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultNameClient);

        }

        private void setLabelAddressClientAndLabelResultAddressClient(Form frmConfirmAddOrderCarpetSection)
        {
            Label lblAddressClient = new Label(); 
            Label lblResultAddressClient = new Label();




            //Label Address Client 
            lblAddressClient.Text = "Address Client :";
            lblAddressClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblAddressClient.Top = 270;
            lblAddressClient.Width = 160;
            lblAddressClient.Left = 10;
            lblAddressClient.Height = 40;
            lblAddressClient.BackColor = Color.Transparent;
            lblAddressClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Address Client 
            lblResultAddressClient.Text = GTextBoxAddressClientSectionCarpet.Text;
            lblResultAddressClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultAddressClient.Top = 270;
            lblResultAddressClient.Left = 170;
            lblResultAddressClient.Width = 200;
            lblResultAddressClient.BackColor = Color.Transparent;
            lblResultAddressClient.Height = 40;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblAddressClient);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultAddressClient);

        }

        private void setLabelEmailClientAndLabelResultEmailClient(Form frmConfirmAddOrderCarpetSection)
        {
            Label lblEmailClient = new Label();
            Label lblResultEmailClient = new Label();

            //Label Email Client 
            lblEmailClient.Text = "Email Client : ";
            lblEmailClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblEmailClient.Top = 330;
            lblEmailClient.Width = 150;
            lblEmailClient.Left = 10;
            lblEmailClient.Height = 40;
            lblEmailClient.BackColor = Color.Transparent;
            lblEmailClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Email Client 
            lblResultEmailClient.Text = GTextBoxEmailClientSectionCarpet.Text;
            lblResultEmailClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultEmailClient.Top = 330;
            lblResultEmailClient.Left = 160;
            lblResultEmailClient.Width = 200;
            lblResultEmailClient.BackColor = Color.Transparent;
            lblResultEmailClient.Height = 40;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblEmailClient);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultEmailClient);

        }

        private void setLabelPhoneClientAndLabelResultPhoneClient(Form frmConfirmAddOrderCarpetSection)
        {
            Label lblPhoneClient = new Label();
            Label lblResultPhoneClient = new Label();


            //Label Phone Client 
            lblPhoneClient.Text = "Phone Client : ";
            lblPhoneClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblPhoneClient.Top = 390;
            lblPhoneClient.Width = 150;
            lblPhoneClient.Left = 10;
            lblPhoneClient.Height = 40;
            lblPhoneClient.BackColor = Color.Transparent;
            lblPhoneClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Phone Client 
            lblResultPhoneClient.Text = GTextBoxPhoneClientSectionCarpet.Text;
            lblResultPhoneClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultPhoneClient.Top = 390;
            lblResultPhoneClient.Left = 160;
            lblResultPhoneClient.Width = 100;
            lblResultPhoneClient.BackColor = Color.Transparent;
            lblResultPhoneClient.Height = 40;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblPhoneClient);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultPhoneClient);

        }

        private void setLabelSizeCarpetAndLabelResultSizeCarpet(Form frmConfirmAddOrderCarpetSection)
        {

            Label lblSizeCarpet = new Label();
            Label lblResultSizeCarpet = new Label();




            //Label Size Carpet
            lblSizeCarpet.Text = "Size Carpet : ";
            lblSizeCarpet.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblSizeCarpet.Top = 450;
            lblSizeCarpet.Width = 150;
            lblSizeCarpet.Left = 10;
            lblSizeCarpet.Height = 40;
            lblSizeCarpet.BackColor = Color.Transparent;
            lblSizeCarpet.ForeColor = Color.FromArgb(255, 4, 187, 156);


            // Result Label Size Carpet
            lblResultSizeCarpet.Text = returnWordSizeCarpt();
            lblResultSizeCarpet.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultSizeCarpet.Top = 450;
            lblResultSizeCarpet.Left = 160;
            lblResultSizeCarpet.Width = 60;
            lblResultSizeCarpet.BackColor = Color.Transparent;
            lblResultSizeCarpet.Height = 40;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblSizeCarpet);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultSizeCarpet);

        }

        private void setLabelTypeWashCarpetAndLabelResultTypeWashCarpet(Form frmConfirmAddOrderCarpetSection)
        {



            Label lblTypeWashCarpet = new Label();
            Label lblResultTypeWashCarpet = new Label();


            //Label Type Wash Carpet
            lblTypeWashCarpet.Text = "Type Wash : ";
            lblTypeWashCarpet.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblTypeWashCarpet.Top = 510;
            lblTypeWashCarpet.Width = 150;
            lblTypeWashCarpet.Left = 10;
            lblTypeWashCarpet.Height = 40;
            lblTypeWashCarpet.BackColor = Color.Transparent;
            lblTypeWashCarpet.ForeColor = Color.FromArgb(255, 4, 187, 156);


            // Result Label Type Wash Carpet
            lblResultTypeWashCarpet.Text = returnWordTypeWash();
            lblResultTypeWashCarpet.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultTypeWashCarpet.Top = 510;
            lblResultTypeWashCarpet.Left = 155;
            lblResultTypeWashCarpet.Width = 160;
            lblResultTypeWashCarpet.BackColor = Color.Transparent;
            lblResultTypeWashCarpet.Height = 50;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblTypeWashCarpet);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultTypeWashCarpet);

        }

        private void setLabelOtherServiceCarpetAndLabelResultOtherServiceCarpet(Form frmConfirmAddOrderCarpetSection)
        {




            Label lblOtherSeviceCarpet = new Label();
            Label lblResultOtherSeviceCarpet = new Label();



            //Label Other Service  Carpet
            lblOtherSeviceCarpet.Text = "Other Service : ";
            lblOtherSeviceCarpet.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblOtherSeviceCarpet.Top = 570;
            lblOtherSeviceCarpet.Width = 350;
            lblOtherSeviceCarpet.Left = 10;
            lblOtherSeviceCarpet.Height = 40;
            lblOtherSeviceCarpet.BackColor = Color.Transparent;
            lblOtherSeviceCarpet.ForeColor = Color.FromArgb(255, 4, 187, 156);


            // Result Label Type Wash Carpet
            lblResultOtherSeviceCarpet.Text = returnTextOtherServiceCarpet();
            lblResultOtherSeviceCarpet.Font = new Font("Garamond", 12, FontStyle.Bold);
            lblResultOtherSeviceCarpet.Top = 620;
            lblResultOtherSeviceCarpet.Left = 100;
            lblResultOtherSeviceCarpet.Width = 150;
            lblResultOtherSeviceCarpet.BackColor = Color.Transparent;
            lblResultOtherSeviceCarpet.Height = 150;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblOtherSeviceCarpet);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultOtherSeviceCarpet);

        }
     
        private void setLabelsOrderCarpetSection(Form frmConfirmAddOrderCarpetSection)
        {


            setLabelIDOrderAndResultIDOrder(frmConfirmAddOrderCarpetSection);
            setLabelNameClientAndResultNameClientCarpet(frmConfirmAddOrderCarpetSection);
            setLabelAddressClientAndLabelResultAddressClient(frmConfirmAddOrderCarpetSection);
            setLabelEmailClientAndLabelResultEmailClient(frmConfirmAddOrderCarpetSection);
            setLabelPhoneClientAndLabelResultPhoneClient(frmConfirmAddOrderCarpetSection);
            setLabelSizeCarpetAndLabelResultSizeCarpet(frmConfirmAddOrderCarpetSection);
            setLabelTypeWashCarpetAndLabelResultTypeWashCarpet(frmConfirmAddOrderCarpetSection);
            setLabelOtherServiceCarpetAndLabelResultOtherServiceCarpet(frmConfirmAddOrderCarpetSection);
         

        }

        private void ButtonOrderNowNewForm()
        {
            //setLabelsOrderCarpetSection();
            frmConfirmAddOrderSection = new Form();
            setTitleAndSizeAndLocationFormSectionCarpet(frmConfirmAddOrderSection);

            
            Guna2GradientButton G2B = new Guna2GradientButton();

            G2B.Text = "Order Now";
            G2B.Location = new Point(300, 620);
            G2B.FillColor = Color.FromArgb(255, 4, 187, 156);
            G2B.FillColor2 = Color.White; 
            G2B.Animated = true;
            G2B.AnimatedGIF = true;
            G2B.BorderRadius = 10;
            frmConfirmAddOrderSection.Controls.Add(G2B);

            
            G2B.Click += (Sender, e) =>
            {
                OrderNow();
                frmConfirmAddOrderSection.Close();
            };

            frmConfirmAddOrderSection.ShowDialog();



        }



        //-------------------------------- [End Section Carpet Create Form Finial Bill ]-------------------------------





        //-------------------------------- [start Section Car Create Form Finial Bill ]-------------------------------


        private void setTitleAndSizeAndLocationFormSectionCar(Form frmConfirmAddOrderSection)
        {

            frmConfirmAddOrderSection.Text = "Confirm Add Order Car";
            frmConfirmAddOrderSection.StartPosition = FormStartPosition.CenterScreen;

            Guna2BorderlessForm GBLEF = new Guna2BorderlessForm();
            Guna2ShadowForm G2SF = new Guna2ShadowForm();

            GBLEF.BorderRadius = 20;
            G2SF.ShadowColor = Color.FromArgb(90, 4, 187, 156);
            G2SF.SetShadowForm(frmConfirmAddOrderSection);

            GBLEF.ContainerControl = frmConfirmAddOrderSection;

            frmConfirmAddOrderSection.MinimizeBox = false;
            frmConfirmAddOrderSection.MaximizeBox = false;
            frmConfirmAddOrderSection.ControlBox = false;

            frmConfirmAddOrderSection.BackColor = Color.White;
            frmConfirmAddOrderSection.Size = new Size(500, Convert.ToInt32(Math.Round(700.5)));

            setLabelFinialBill(frmConfirmAddOrderSection);

            setLabelsOrderCarSection(frmConfirmAddOrderSection);

        }

        private void setLabelIDOrderAndResultIDOrderCar(Form frmConfirmAddOrderSection)
        {
            Label lblIDOrder = new Label();
            Label lblResultIDOrder = new Label();

            // Label ID Order 
            lblIDOrder.Text = "ID Order :";
            lblIDOrder.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblIDOrder.BackColor = Color.Transparent;
            lblIDOrder.Top = 150;
            lblIDOrder.Left = 10;
            lblIDOrder.Width = 120;
            lblIDOrder.Height = 40;
            lblIDOrder.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label ID Order 
            lblResultIDOrder.Text = GTextBoxIDOrderCarSection.Text;
            lblResultIDOrder.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultIDOrder.Top = 150;
            lblResultIDOrder.Left = 130;
            lblResultIDOrder.Width = 50;

            lblIDOrder.Height = 20;

            lblResultIDOrder.BackColor = Color.Transparent;

            frmConfirmAddOrderSection.Controls.Add(lblIDOrder);
            frmConfirmAddOrderSection.Controls.Add(lblResultIDOrder);

        }
       
        private void setLabelNumberCarAndResultNumberCar(Form frmConfirmAddOrderSection)
        {
            Label lblNumberCar = new Label();
            Label lblResultNumberCar = new Label();

            // Label Number Car
            lblNumberCar.Text = "Number Car :";
            lblNumberCar.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblNumberCar.BackColor = Color.Transparent;
            lblNumberCar.Top = 190;
            lblNumberCar.Left = 10;
            lblNumberCar.Width = 145;
            lblNumberCar.Height = 40;
            lblNumberCar.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Number Car
            lblResultNumberCar.Text = GTextBoxNumberCar.Text;
            lblResultNumberCar.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultNumberCar.Top = 190;
            lblResultNumberCar.Left = 160;
            lblResultNumberCar.Width = 150;

            lblResultNumberCar.Height = 20;

            lblResultNumberCar.BackColor = Color.Transparent;

            frmConfirmAddOrderSection.Controls.Add(lblNumberCar);
            frmConfirmAddOrderSection.Controls.Add(lblResultNumberCar);

        }
       
        private void setLabelNameModelCarAndResultModelCar(Form frmConfirmAddOrderCarpetSection)
        {
            Label lblModelCar = new Label();
            Label lblResultModelCar = new Label();


            //Label Model Car
            lblModelCar.Text = "Model Car :";
            lblModelCar.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblModelCar.Top = 230;
            lblModelCar.Width = 150;
            lblModelCar.Left = 10;
            lblModelCar.Height = 40;
            lblModelCar.BackColor = Color.Transparent;
            lblModelCar.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Model Car
            lblResultModelCar.Text = GTextBoxCarModel.Text;
            lblResultModelCar.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultModelCar.Top = 230;
            lblResultModelCar.Left = 160;
            lblResultModelCar.Width = 150;
            lblResultModelCar.BackColor = Color.Transparent;
            lblResultModelCar.Height = 40;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblModelCar);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultModelCar);

        }

        private void setLabelNameClientAndResultNameClientCar(Form frmConfirmAddOrderCarpetSection)
        {
            Label lblNameClient = new Label();
            Label lblResultNameClient = new Label();


            //Label Name Client 
            lblNameClient.Text = "Name Client :";
            lblNameClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblNameClient.Top = 270;
            lblNameClient.Width = 150;
            lblNameClient.Left = 10;
            lblNameClient.Height = 40;
            lblNameClient.BackColor = Color.Transparent;
            lblNameClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Name Client 
            lblResultNameClient.Text = GTextBoxNameClientCarSection.Text;
            lblResultNameClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultNameClient.Top = 270;
            lblResultNameClient.Left = 160;
            lblResultNameClient.Width = 150;
            lblResultNameClient.BackColor = Color.Transparent;
            lblResultNameClient.Height = 40;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblNameClient);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultNameClient);

        }

        private void setLabelAddressClientAndLabelResultAddressClientCar(Form frmConfirmAddOrderCarpetSection)
        {
            Label lblAddressClient = new Label();
            Label lblResultAddressClient = new Label();


            //Label Address Client 
            lblAddressClient.Text = "Address Client :";
            lblAddressClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblAddressClient.Top = 310;
            lblAddressClient.Width = 160;
            lblAddressClient.Left = 10;
            lblAddressClient.Height = 40;
            lblAddressClient.BackColor = Color.Transparent;
            lblAddressClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Address Client 
            lblResultAddressClient.Text = GTextBoxAddressClientCarSection.Text;
            lblResultAddressClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultAddressClient.Top = 310;
            lblResultAddressClient.Left = 170;
            lblResultAddressClient.Width = 200;
            lblResultAddressClient.BackColor = Color.Transparent;
            lblResultAddressClient.Height = 40;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblAddressClient);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultAddressClient);

        }

        private void setLabelEmailClientAndLabelResultEmailClientCar(Form frmConfirmAddOrderCarpetSection)
        {
            Label lblEmailClient = new Label();
            Label lblResultEmailClient = new Label();


            //Label Email Client 
            lblEmailClient.Text = "Email Client : ";
            lblEmailClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblEmailClient.Top = 350;
            lblEmailClient.Width = 150;
            lblEmailClient.Left = 10;
            lblEmailClient.Height = 40;
            lblEmailClient.BackColor = Color.Transparent;
            lblEmailClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Email Client 
            lblResultEmailClient.Text = GTextBoxEmailClientCarSection.Text;
            lblResultEmailClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultEmailClient.Top = 350;
            lblResultEmailClient.Left = 160;
            lblResultEmailClient.Width = 200;
            lblResultEmailClient.BackColor = Color.Transparent;
            lblResultEmailClient.Height = 40;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblEmailClient);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultEmailClient);

        }

        private void setLabelPhoneClientAndLabelResultPhoneClientCar(Form frmConfirmAddOrderCarpetSection)
        {
            Label lblPhoneClient = new Label();
            Label lblResultPhoneClient = new Label();


            //Label Phone Client 
            lblPhoneClient.Text = "Phone Client : ";
            lblPhoneClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblPhoneClient.Top = 390;
            lblPhoneClient.Width = 150;
            lblPhoneClient.Left = 10;
            lblPhoneClient.Height = 40;
            lblPhoneClient.BackColor = Color.Transparent;
            lblPhoneClient.ForeColor = Color.FromArgb(255, 4, 187, 156);

            // Result Label Phone Client 
            lblResultPhoneClient.Text = GTextBoxPhoneClientCarSection.Text;
            lblResultPhoneClient.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultPhoneClient.Top = 390;
            lblResultPhoneClient.Left = 160;
            lblResultPhoneClient.Width = 100;
            lblResultPhoneClient.BackColor = Color.Transparent;
            lblResultPhoneClient.Height = 40;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblPhoneClient);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultPhoneClient);

        }

        private void setLabelSizeCarpetAndLabelResultSizeCar(Form frmConfirmAddOrderCarpetSection)
        {

            Label lblSizeCar= new Label();
            Label lblResultSizeCar = new Label();




            //Label Size Carpet
            lblSizeCar.Text = "Size Car : ";
            lblSizeCar.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblSizeCar.Top = 430;
            lblSizeCar.Width = 150;
            lblSizeCar.Left = 10;
            lblSizeCar.Height = 40;
            lblSizeCar.BackColor = Color.Transparent;
            lblSizeCar.ForeColor = Color.FromArgb(255, 4, 187, 156);


            // Result Label Size Carpet
            lblResultSizeCar.Text = returnWordSizeCar();
            lblResultSizeCar.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultSizeCar.Top = 430;
            lblResultSizeCar.Left = 160;
            lblResultSizeCar.Width = 150;
            lblResultSizeCar.BackColor = Color.Transparent;
            lblResultSizeCar.Height = 40;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblSizeCar);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultSizeCar);

        }

        private void setLabelTypeWashCarpetAndLabelResultTypeWashServiceCar(Form frmConfirmAddOrderCarpetSection)
        {


            Label lblTypeWashCar = new Label();
            Label lblResultTypeWashCar = new Label();


            //Label Type Wash Carpet
            lblTypeWashCar.Text = "Serivce: ";
            lblTypeWashCar.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblTypeWashCar.Top = 470;
            lblTypeWashCar.Width = 100;
            lblTypeWashCar.Left = 10;
            lblTypeWashCar.Height = 40;
            lblTypeWashCar.BackColor = Color.Transparent;
            lblTypeWashCar.ForeColor = Color.FromArgb(255, 4, 187, 156);


            // Result Label Type Wash Carpet
            lblResultTypeWashCar.Text = returnTypeWashCarWord();
            lblResultTypeWashCar.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblResultTypeWashCar.Top = 470;
            lblResultTypeWashCar.Left = 120;
            lblResultTypeWashCar.Width = 100;
            lblResultTypeWashCar.BackColor = Color.Transparent;
            lblResultTypeWashCar.Height = 50;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblTypeWashCar);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultTypeWashCar);

        }

        private void setLabelOtherServiceCarpetAndLabelResultOtherServiceCar(Form frmConfirmAddOrderCarpetSection)
        {


            Label lblOtherSeviceCar = new Label();
            Label lblResultOtherSeviceCar = new Label();



            //Label Other Service  Car
            lblOtherSeviceCar.Text = "Other Service : ";
            lblOtherSeviceCar.Font = new Font("Garamond", 16, FontStyle.Bold);
            lblOtherSeviceCar.Top = 530;
            lblOtherSeviceCar.Width = 350;
            lblOtherSeviceCar.Left = 10;
            lblOtherSeviceCar.Height = 40;
            lblOtherSeviceCar.BackColor = Color.Transparent;
            lblOtherSeviceCar.ForeColor = Color.FromArgb(255, 4, 187, 156);


            // Result Label Other Service Car
            lblResultOtherSeviceCar.Text = returnLineWordServiceCarSpecialFinialBillForm();
            lblResultOtherSeviceCar.Font = new Font("Garamond", 12, FontStyle.Bold);
            lblResultOtherSeviceCar.Top = 570;
            lblResultOtherSeviceCar.Left = 60;
            lblResultOtherSeviceCar.Width = 200;
            lblResultOtherSeviceCar.BackColor = Color.Transparent;
            lblResultOtherSeviceCar.Height = 400;

            frmConfirmAddOrderCarpetSection.Controls.Add(lblOtherSeviceCar);
            frmConfirmAddOrderCarpetSection.Controls.Add(lblResultOtherSeviceCar);

        }

        private void setLabelsOrderCarSection(Form frmConfirmAddOrderCarpetSection)
        {


            setLabelIDOrderAndResultIDOrderCar(frmConfirmAddOrderCarpetSection);
            setLabelNumberCarAndResultNumberCar(frmConfirmAddOrderCarpetSection);
            setLabelNameModelCarAndResultModelCar(frmConfirmAddOrderCarpetSection);
            setLabelNameClientAndResultNameClientCar(frmConfirmAddOrderCarpetSection);
            setLabelAddressClientAndLabelResultAddressClientCar(frmConfirmAddOrderCarpetSection);
            setLabelEmailClientAndLabelResultEmailClientCar(frmConfirmAddOrderCarpetSection);
            setLabelPhoneClientAndLabelResultPhoneClientCar(frmConfirmAddOrderCarpetSection);
            setLabelSizeCarpetAndLabelResultSizeCar(frmConfirmAddOrderCarpetSection);
            setLabelTypeWashCarpetAndLabelResultTypeWashServiceCar(frmConfirmAddOrderCarpetSection);
            setLabelOtherServiceCarpetAndLabelResultOtherServiceCar(frmConfirmAddOrderCarpetSection);


        }

        private void ButtonOrderNowNewFormCar()
        {
            //setLabelsOrderCarpetSection();
            frmConfirmAddOrderSection = new Form();
            setTitleAndSizeAndLocationFormSectionCar(frmConfirmAddOrderSection);


            Guna2GradientButton G2B = new Guna2GradientButton();

            G2B.Text = "Order Now";
            G2B.Location = new Point(300, 620);
            G2B.FillColor = Color.FromArgb(255, 4, 187, 156);
            G2B.FillColor2 = Color.White;
            G2B.Animated = true;
            G2B.AnimatedGIF = true;
            G2B.BorderRadius = 10;
            frmConfirmAddOrderSection.Controls.Add(G2B);


            G2B.Click += (Sender, e) =>
            {
                OrderNow();
                frmConfirmAddOrderSection.Close();
            };

            frmConfirmAddOrderSection.ShowDialog();



        }

        private void GTextBoxIDOrderCarSection_TextChanged(object sender, EventArgs e)
        {

        }



        //-------------------------------- [End Section Car Create Form Finial Bill ]-------------------------------


    }
}
