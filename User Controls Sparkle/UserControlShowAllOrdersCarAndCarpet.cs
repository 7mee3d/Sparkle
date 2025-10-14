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
    public partial class UserControlShowAllOrdersCarAndCarpet : UserControl
    {
        public UserControlShowAllOrdersCarAndCarpet()
        {
            InitializeComponent();
            ListViewAllOrdersCarpet.Scrollable = true; 
           
           
        }

        private void ListViewAllOrdersCarAndCarpet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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
    }
}
