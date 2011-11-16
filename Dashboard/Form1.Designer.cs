namespace Dashboard
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.c1Ribbon1 = new C1.Win.C1Ribbon.C1Ribbon();
            this.ribbonApplicationMenu1 = new C1.Win.C1Ribbon.RibbonApplicationMenu();
            this.ribbonConfigToolBar1 = new C1.Win.C1Ribbon.RibbonConfigToolBar();
            this.colorSchemeMenu = new C1.Win.C1Ribbon.RibbonMenu();
            this.blue2007Button = new C1.Win.C1Ribbon.RibbonToggleButton();
            this.silver2007Button = new C1.Win.C1Ribbon.RibbonToggleButton();
            this.black2007Button = new C1.Win.C1Ribbon.RibbonToggleButton();
            this.blue2010Button = new C1.Win.C1Ribbon.RibbonToggleButton();
            this.silver2010Button = new C1.Win.C1Ribbon.RibbonToggleButton();
            this.black2010Button = new C1.Win.C1Ribbon.RibbonToggleButton();
            this.windows7Button = new C1.Win.C1Ribbon.RibbonToggleButton();
            this.ribbonQat1 = new C1.Win.C1Ribbon.RibbonQat();
            this.ribbonTab1 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup1 = new C1.Win.C1Ribbon.RibbonGroup();
            this.c1StatusBar1 = new C1.Win.C1Ribbon.C1StatusBar();
            this.ribbonTab2 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup2 = new C1.Win.C1Ribbon.RibbonGroup();
            this.ribbonButton1 = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonButton2 = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonButton3 = new C1.Win.C1Ribbon.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Ribbon1
            // 
            this.c1Ribbon1.ApplicationMenuHolder = this.ribbonApplicationMenu1;
            this.c1Ribbon1.ConfigToolBarHolder = this.ribbonConfigToolBar1;
            this.c1Ribbon1.Location = new System.Drawing.Point(0, 0);
            this.c1Ribbon1.Name = "c1Ribbon1";
            this.c1Ribbon1.QatHolder = this.ribbonQat1;
            this.c1Ribbon1.Size = new System.Drawing.Size(611, 153);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab1);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab2);
            // 
            // ribbonApplicationMenu1
            // 
            this.ribbonApplicationMenu1.Name = "ribbonApplicationMenu1";
            // 
            // ribbonConfigToolBar1
            // 
            this.ribbonConfigToolBar1.Items.Add(this.colorSchemeMenu);
            this.ribbonConfigToolBar1.Name = "ribbonConfigToolBar1";
            // 
            // colorSchemeMenu
            // 
            this.colorSchemeMenu.Items.Add(this.blue2007Button);
            this.colorSchemeMenu.Items.Add(this.silver2007Button);
            this.colorSchemeMenu.Items.Add(this.black2007Button);
            this.colorSchemeMenu.Items.Add(this.blue2010Button);
            this.colorSchemeMenu.Items.Add(this.silver2010Button);
            this.colorSchemeMenu.Items.Add(this.black2010Button);
            this.colorSchemeMenu.Items.Add(this.windows7Button);
            this.colorSchemeMenu.Name = "colorSchemeMenu";
            this.colorSchemeMenu.SmallImage = ((System.Drawing.Image)(resources.GetObject("colorSchemeMenu.SmallImage")));
            this.colorSchemeMenu.Text = "Style";
            // 
            // blue2007Button
            // 
            this.blue2007Button.CanDepress = false;
            this.blue2007Button.Name = "blue2007Button";
            this.blue2007Button.SmallImage = ((System.Drawing.Image)(resources.GetObject("blue2007Button.SmallImage")));
            this.blue2007Button.Text = "Blue 2007";
            this.blue2007Button.ToggleGroupName = "visualStyle";
            this.blue2007Button.PressedButtonChanged += new System.EventHandler(this.visualStyle_PressedButtonChanged);
            // 
            // silver2007Button
            // 
            this.silver2007Button.CanDepress = false;
            this.silver2007Button.Name = "silver2007Button";
            this.silver2007Button.SmallImage = ((System.Drawing.Image)(resources.GetObject("silver2007Button.SmallImage")));
            this.silver2007Button.Text = "Silver 2007";
            this.silver2007Button.ToggleGroupName = "visualStyle";
            // 
            // black2007Button
            // 
            this.black2007Button.CanDepress = false;
            this.black2007Button.Name = "black2007Button";
            this.black2007Button.SmallImage = ((System.Drawing.Image)(resources.GetObject("black2007Button.SmallImage")));
            this.black2007Button.Text = "Black 2007";
            this.black2007Button.ToggleGroupName = "visualStyle";
            // 
            // blue2010Button
            // 
            this.blue2010Button.CanDepress = false;
            this.blue2010Button.Name = "blue2010Button";
            this.blue2010Button.SmallImage = ((System.Drawing.Image)(resources.GetObject("blue2010Button.SmallImage")));
            this.blue2010Button.Text = "Blue 2010";
            this.blue2010Button.ToggleGroupName = "visualStyle";
            // 
            // silver2010Button
            // 
            this.silver2010Button.CanDepress = false;
            this.silver2010Button.Name = "silver2010Button";
            this.silver2010Button.SmallImage = ((System.Drawing.Image)(resources.GetObject("silver2010Button.SmallImage")));
            this.silver2010Button.Text = "Silver 2010";
            this.silver2010Button.ToggleGroupName = "visualStyle";
            // 
            // black2010Button
            // 
            this.black2010Button.CanDepress = false;
            this.black2010Button.Name = "black2010Button";
            this.black2010Button.SmallImage = ((System.Drawing.Image)(resources.GetObject("black2010Button.SmallImage")));
            this.black2010Button.Text = "Black 2010";
            this.black2010Button.ToggleGroupName = "visualStyle";
            // 
            // windows7Button
            // 
            this.windows7Button.CanDepress = false;
            this.windows7Button.Name = "windows7Button";
            this.windows7Button.SmallImage = ((System.Drawing.Image)(resources.GetObject("windows7Button.SmallImage")));
            this.windows7Button.Text = "Windows 7";
            this.windows7Button.ToggleGroupName = "visualStyle";
            // 
            // ribbonQat1
            // 
            this.ribbonQat1.Name = "ribbonQat1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.Add(this.ribbonGroup1);
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Home";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Group";
            // 
            // c1StatusBar1
            // 
            this.c1StatusBar1.Location = new System.Drawing.Point(0, 436);
            this.c1StatusBar1.Name = "c1StatusBar1";
            this.c1StatusBar1.Size = new System.Drawing.Size(611, 23);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Groups.Add(this.ribbonGroup2);
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "Configuration";
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Items.Add(this.ribbonButton1);
            this.ribbonGroup2.Items.Add(this.ribbonButton2);
            this.ribbonGroup2.Items.Add(this.ribbonButton3);
            this.ribbonGroup2.Name = "ribbonGroup2";
            this.ribbonGroup2.Text = "Network Settings";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Hostname";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Port";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Search";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 459);
            this.Controls.Add(this.c1StatusBar1);
            this.Controls.Add(this.c1Ribbon1);
            this.Name = "Form1";
            this.Text = "Dashboard";
            this.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Windows7;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Ribbon.C1Ribbon c1Ribbon1;
        private C1.Win.C1Ribbon.RibbonApplicationMenu ribbonApplicationMenu1;
        private C1.Win.C1Ribbon.RibbonConfigToolBar ribbonConfigToolBar1;
        private C1.Win.C1Ribbon.RibbonQat ribbonQat1;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab1;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup1;
        private C1.Win.C1Ribbon.C1StatusBar c1StatusBar1;
        private C1.Win.C1Ribbon.RibbonMenu colorSchemeMenu;
        private C1.Win.C1Ribbon.RibbonToggleButton blue2007Button;
        private C1.Win.C1Ribbon.RibbonToggleButton silver2007Button;
        private C1.Win.C1Ribbon.RibbonToggleButton black2007Button;
        private C1.Win.C1Ribbon.RibbonToggleButton blue2010Button;
        private C1.Win.C1Ribbon.RibbonToggleButton silver2010Button;
        private C1.Win.C1Ribbon.RibbonToggleButton black2010Button;
        private C1.Win.C1Ribbon.RibbonToggleButton windows7Button;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab2;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup2;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton1;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton2;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton3;
    }
}

