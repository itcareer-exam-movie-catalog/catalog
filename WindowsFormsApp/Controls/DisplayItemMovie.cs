using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Model;

namespace WindowsFormsApp.Controls
{
    public partial class DisplayItemMovie : UserControl
    {
        private Movie movie;
        private Director director;
        private Actor[] actors;
        private Category[] categories;

        public DisplayItemMovie(Movie movie, Director director, Actor[] actors, Category[] categories)
        {
            InitializeComponent();

            this.movie = movie;
            this.director = director;
            this.actors = actors;
            this.categories = categories;

            RefreshDisplayInfo();
        }

        public void RefreshDisplayInfo()
        {
            this.label1.Text = movie.Title;
        }
    }
}
