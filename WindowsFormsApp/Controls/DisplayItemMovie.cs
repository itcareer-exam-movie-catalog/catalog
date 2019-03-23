using System.Drawing;
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

        private Color defaultBackColor;
        private Color overItemBackColor;

        private bool clicked;

        public DisplayItemMovie(Movie movie, Director director, Actor[] actors, Category[] categories)
        {
            InitializeComponent();

            this.movie = movie;
            this.director = director;
            this.actors = actors;
            this.categories = categories;

            defaultBackColor = Color.LightGray;
            overItemBackColor = Color.DarkGray;
            this.BackColor = defaultBackColor;

            this.clicked = false;

            RefreshDisplayInfo();
        }

        public void RefreshDisplayInfo()
        {
            this.label1.Text = movie.Title;
        }

        private void OnMouseOver(bool isOver) => this.BackColor = isOver ? overItemBackColor : defaultBackColor;
        private void DisplayItemMovie_MouseEnter(object sender, System.EventArgs e) => OnMouseOver(true);
        private void DisplayItemMovie_MouseLeave(object sender, System.EventArgs e) => OnMouseOver(false);
        private void DisplayItemMovie_MouseDoubleClick(object sender, MouseEventArgs e) => clicked = true;
    }
}
