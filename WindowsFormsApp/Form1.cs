using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public static int controlsPadding = 12;

        public Form1()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public void UpdateView()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            reviewItem1.SetForm(this);
            searchItem1.SetReviewItem(reviewItem1);
            
            UpdateView();   
        }
    }
}
