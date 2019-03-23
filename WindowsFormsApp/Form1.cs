using Business.Businesses;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public static BusinessActors businessActors = new BusinessActors();
        public static BusinessAuthors businessAuthors = new BusinessAuthors();
        public static BusinessBooks businessBooks = new BusinessBooks();
        public static BusinessCategories businessCategories = new BusinessCategories();
        public static BusinessDirectors businessDirectors = new BusinessDirectors();
        public static BusinessMovies businessMovies = new BusinessMovies();
        public static BusinessPublishers businessPublishers = new BusinessPublishers();

        public Form1()
        {
            InitializeComponent();

            searchItem1.SetBusinesses(businessActors, businessAuthors, businessBooks, businessCategories, businessDirectors, businessMovies, businessPublishers);
            searchItem1.Init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reviewItem1.Hide();

            searchItem1.Show();
            searchItem1.BringToFront();
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {

        }

        //Remake
        //private void Form1_Resize(object sender, EventArgs e) => showPanel.Size = new Size(this.Width - showPanel.Location.X * 2 - 16, this.Height - showPanel.Location.Y * 2 - 38);

    }
}
