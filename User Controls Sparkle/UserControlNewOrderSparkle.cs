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
    }
}
