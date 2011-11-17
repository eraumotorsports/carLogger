using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Ribbon;

namespace Dashboard
{
    public partial class Form1 : C1RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            switch (c1Ribbon1.VisualStyle)
            {
                case VisualStyle.Office2007Blue:
                    blue2007Button.Pressed = true;
                    break;
                case VisualStyle.Office2007Silver:
                    silver2007Button.Pressed = true;
                    break;
                case VisualStyle.Office2007Black:
                    black2007Button.Pressed = true;
                    break;
                case VisualStyle.Office2010Blue:
                    blue2010Button.Pressed = true;
                    break;
                case VisualStyle.Office2010Silver:
                    silver2010Button.Pressed = true;
                    break;
                case VisualStyle.Office2010Black:
                    black2010Button.Pressed = true;
                    break;
                case VisualStyle.Windows7:
                    windows7Button.Pressed = true;
                    break;
            }
        }

        private void visualStyle_PressedButtonChanged(object sender, EventArgs e)
        {
            if (blue2007Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2007Blue;
            else if (silver2007Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2007Silver;
            else if (black2007Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2007Black;
            else if (blue2010Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2010Blue;
            else if (silver2010Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2010Silver;
            else if (black2010Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2010Black;
            else if (windows7Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Windows7;
        }

        private void ribbonButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
