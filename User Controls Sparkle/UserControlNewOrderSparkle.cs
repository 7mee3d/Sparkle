using Guna.UI2.WinForms;
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
    public partial class UserControlNewOrderSparkle : UserControl
    {


          //Path File 
        const string kPATH_FILE_CARPETS_ORDERS = "CarpetsOrders.txt";
        const string kPATH_FILE_CARS_ORDERS = "CarOrders.txt";
      
        
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
                        if (innerControls is Guna2TextBox G2TB && G2TB != GTextBoxIDOrderCarpet)
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
                infoCarpetOrder.stTotalPriceOrder = allInformationOrderCarpet[10];
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
            lineInformationOrder += informationOrderCarpet.stTotalPriceOrder ;

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
            lineInformationOrder += informationOrder[10] ;


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
            allInformationCarpet.Add(GTextBoxOtherSeviceCarpet.Text);
            allInformationCarpet.Add(calcTotalPriveAllServiceCarpet().ToString());

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
       
        private string returnWordSizeCarpt ()
        {
            string wordSizeCarpet = "";


            if (GRadioButtonSizeCarpetSmall.Checked)
                wordSizeCarpet = "Small";

            if (GRadioButtonSizeCarpetMedium.Checked)
                wordSizeCarpet = "Medium";

            if (GRadioButtonSizeCarpetLarge.Checked)
                wordSizeCarpet = "Large";

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
                wordTypeWash = "Normal Wash";

            if (GRadioButtonWashTypDeepWash.Checked)
                wordTypeWash = "Deep Wash";

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
                wordOtherSevice += " Quick Drying";

            if (GCheckBoxOtherServicesHomeDelivery.Checked)
                wordOtherSevice += " Home Delivery";

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

        private void OrderNow ()
        {
            if (GRadioButtonCarpetsSection.Checked)
            {

                SaveAllInformationOrderAfterConvertDataToLineTOFile(allInformationOptionsCarpet());
                MessageBox.Show("Done");

                ResetAllTextBoxInUserControl();

                GTextBoxIDOrderCarpet.Text = (lastIDOrderInFile() + 1).ToString();
                ResetAllControlPanel();
            }
            else if (GRadioButtonCarsSection.Checked)
            {
                SaveAllInformationOrderCarToFile(AllInformationStringCarSection());
                MessageBox.Show("Done");

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

        private void ButtonAddNewOrder_Click(object sender, EventArgs e)
        {
            OrderNow();
        }

        private void GTextBoxNameClientSectionCarpet_Validating(object sender, CancelEventArgs e)
        {
            setErrorAndCorrectControlsTextBoxCarpet(sender, e, "Please do not enter any numbers or leave this field blank. ", "Successful");
        }

        private void GTextBoxAddressClientSectionCarpet_Validating(object sender, CancelEventArgs e)
        {
            setErrorAndCorrectControlsTextBoxCarpet(sender, e, "Please do not enter any numbers or leave this field blank. ", "Successful");

        }

        private void GTextBoxPhoneClientSectionCarpet_Validating(object sender, CancelEventArgs e)
        {
            setErrorAndCorrectControlsTextBoxCarpet(sender, e, "Please do not enter any numbers or leave this field blank. ", "Successful");

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



        //------------------------------ [End Section Controls]-------------------------------

    }
}
