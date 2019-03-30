using Business.Businesses;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public static int controlsPadding = 12;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void OnResize()
        {
            Point controlsPoint = new Point(controlsPadding, controlsPadding);
            Size searchItemSize = new Size(mainPanel.Width - controlsPadding * 2, mainPanel.Height - controlsPadding * 2);
            Size reviewItemSize = searchItemSize;

            searchItem1.Location = controlsPoint;
            
            if(this.WindowState == FormWindowState.Maximized)
            {
                int freeSpace = mainPanel.Width - searchItem1.DisplayItemsX - controlsPadding * 2;
                searchItemSize.Width = freeSpace / 2 + searchItem1.DisplayItemsX;

                reviewItemSize.Width = freeSpace / 2 - controlsPadding;
                controlsPoint.X = searchItemSize.Width + controlsPadding * 2;

                System.Diagnostics.Debug.WriteLine(reviewItem1.Size);
            }

            searchItem1.Size = searchItemSize;
            reviewItem1.Size = reviewItemSize;
            reviewItem1.Location = controlsPoint;

            ShowLogic();
        }

        private void ShowLogic()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                searchItem1.Show();
                reviewItem1.Show();
            }
            else
            {
                if (reviewItem1.HasItem)
                {
                    searchItem1.Hide();

                    reviewItem1.Show();
                    reviewItem1.BringToFront();
                }
                else
                {
                    reviewItem1.Hide();

                    searchItem1.Show();
                    searchItem1.BringToFront();
                }
            }
        }

        private void mainPanel_Resize(object sender, EventArgs e) => OnResize();
        private void Form1_Load(object sender, EventArgs e) => ShowLogic();
    }
}
