using Business.Businesses;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public static BusinessActors businessActors = new BusinessActors();
        BusinessAuthors businessAuthors = new BusinessAuthors();
        BusinessBooks businessBooks = new BusinessBooks();
        BusinessCategories businessCategories = new BusinessCategories();
        BusinessDirectors businessDirectors = new BusinessDirectors();
        BusinessMovies businessMovies = new BusinessMovies();
        BusinessPublishers businessPublishers = new BusinessPublishers();

        public Form1()
        {
            InitializeComponent();

            searchItem1.SetBusinesses(businessActors, businessAuthors, businessBooks, businessCategories, businessDirectors, businessMovies, businessPublishers);
            searchItem1.Init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Remake
        //private void Form1_Resize(object sender, EventArgs e) => showPanel.Size = new Size(this.Width - showPanel.Location.X * 2 - 16, this.Height - showPanel.Location.Y * 2 - 38);

    }
}
