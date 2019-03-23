using Data.Model;
using WindowsFormsApp.Controls.Display;

namespace WindowsFormsApp.Controls
{
    /// <summary>
    /// Class for store all data for movie
    /// </summary>
    public partial class DisplayItemMovie : DisplayItem
    {
        private Movie movie;
        private Director director;
        private Actor[] actors;
        private Category[] categories;

        public DisplayItemMovie(Movie movie, Director director, Actor[] actors, Category[] categories) : base()
        {
            InitializeComponent();

            this.movie = movie;
            this.director = director;
            this.actors = actors;
            this.categories = categories;

            RefreshDisplayInfo();
        }

        /// <summary>
        /// Refresh display information for current book
        /// </summary>
        public override void RefreshDisplayInfo()
        {
            this.label1.Text = movie.Title;
        }
    }
}
