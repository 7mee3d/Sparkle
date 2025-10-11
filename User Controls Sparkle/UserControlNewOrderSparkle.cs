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

        public UserControlNewOrderSparkle()
        {
            InitializeComponent();
        }

        private void DrawLineVarticalBetweenSectionAndInformationClient (PaintEventArgs event1 ){

            //Color Pen to be Draw line 
            Color WhiteGreen = Color.FromArgb(255, 4, 187, 156);

            Pen pen = new Pen(WhiteGreen);
            //Bold Pen to Be Draw Line
            pen.Width = 4;

            //Points Line To Be Draw 
            Point point1 = new Point(573, 250);
            Point point2 = new Point(573, 620);
                
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
            }

            else if (GRadioButtonCarsSection.Checked)
            {
                GPanelOptionsCarpets.Visible = false;
                GPanelCarsOptions.Visible = true;
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
    }
}
