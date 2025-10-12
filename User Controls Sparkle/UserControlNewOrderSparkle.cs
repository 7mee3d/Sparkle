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

      

        public UserControlNewOrderSparkle()
        {
            InitializeComponent();
            GTextBoxIDOrderCarpet.Text = (lastIDOrderInFile() + 1).ToString();
            GTextBoxIDOrderCarpet.Enabled = false;
        }

        const string kPATH_FILE_CARPETS_ORDERS = "CarpetsOrders.txt";
       
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
            List<stInformationOrderCarpet> allInformationOrderStucture = pushAllInformationOrderCarpetToListSturtcure();
           
            if (allInformationOrderStucture.Count > 0)
                return (Convert.ToInt32(allInformationOrderStucture[allInformationOrderStucture.Count - 1].stIDCarpetOrder));
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

        private void DrawLineVarticalBetweenSectionAndInformationClient (PaintEventArgs event1 ){

            //Color Pen to be Draw line 
            Color WhiteGreen = Color.FromArgb(255, 4, 187, 156);

            Pen pen = new Pen(WhiteGreen);
            //Bold Pen to Be Draw Line
            pen.Width = 4;

            //Points Line To Be Draw 
            Point point1 = new Point(573, 300);
            Point point2 = new Point(573, 680);
                
            event1.Graphics.DrawLine(pen, point1, point2);

        }
  
        private void UserControlNewOrderSparkle_Paint(object sender, PaintEventArgs e)
        {
            DrawLineVarticalBetweenSectionAndInformationClient(e);
        }

        private void SwitchRadioButtonVisiblePanelCarAndCarpet(object sender, EventArgs e)
        {
            if (GRadioButtonCarpetsSection.Checked)
            {
                GPanelOptionsCarpets.Visible = true;
                GPanelCarsOptions.Visible = false;
                TextNoneAnyOption.Visible = false;
            }

            else if (GRadioButtonCarsSection.Checked)
            {
                GPanelOptionsCarpets.Visible = false;
                GPanelCarsOptions.Visible = true;
                TextNoneAnyOption.Visible = false;
            }
        }

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

        private void InitialValueAfterClickButtonNewOrder ()
        {
            if (GRadioButtonCarsSection.Checked)
                GRadioButtonSizeSmallCar.Checked = true; 
            
        }
      
        private int calcServiceWashPriceCar()
        {
            int priceTypeWashCar = 0;

            if (GCheckBoxServicesFullWash.Checked)
                priceTypeWashCar += 30;

            return priceTypeWashCar; 


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

        private int calcTotalPriceOfWashCar ()
        {
            return (calcSizeCarPrice() + calcServiceWashPriceCar() + calcOtherServiceWashPriceCar()); 
        }

        private void updateTotalPriceSectionCarWash ()
        {
            TotalPriceCarSection.Text = Convert.ToString(calcTotalPriceOfWashCar()) + "$";
        }

        private void resetAllCheckBoxiesOtherServive ()
        {
            GCheckBoxOtherServicesEngineCleaning.Checked = false;
            GCheckBoxOtherServicesExteriorWash.Checked = false;
            GCheckBoxOtherServicesPolishing.Checked = false;
            GCheckBoxOtherServicesInteriorWash.Checked = false;

            updateTotalPriceSectionCarWash(); 
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

        private List<string> allInformationOptionsCarpet ()
        {
            List<string> allInformationCarpet = new List<string>();

            allInformationCarpet.Add(((lastIDOrderInFile())+1).ToString()); 
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
   
        private void updateTotalPriceOfCarpet ()
        {
            TotalPriceCarpetSection.Text = Convert.ToString(calcTotalPriveAllServiceCarpet()) + "$";
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void ButtonAddNewOrder_Click(object sender, EventArgs e)
        {
            
            if (GRadioButtonCarpetsSection.Checked)
            {
               
                SaveAllInformationOrderAfterConvertDataToLineTOFile(allInformationOptionsCarpet());
                MessageBox.Show("Done");
                GTextBoxIDOrderCarpet.Text = (lastIDOrderInFile() + 1).ToString();
            }
        }
    }
}
