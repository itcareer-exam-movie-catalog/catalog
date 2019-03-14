using Business.Businesses;
using Data.Model;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFromApp
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

            this.panelSearch.Visible = true;
            UpdateItemsForSearchPanel();
        }

        private void UpdateItemsForSearchPanel()
        {
            displayItemGrid1.SetItems(businessBooks.GetAllBooks(), businessAuthors, businessCategories, businessPublishers);
        }
    }
}
