using System.Drawing;
using System.Windows.Forms;
using Data.Model;

namespace WindowsFormsApp.Controls
{
    /// <summary>
    /// Class for store all book and movie information and display it
    /// </summary>
    public partial class ListItems : UserControl
    {
        private int itemHeight;

        public ListItems()
        {
            InitializeComponent();

            this.BackColor = Color.DarkGray;
            this.itemHeight = 60;
            this.AutoScroll = true;
        }

        /// <summary>
        /// Adding information for book
        /// </summary>
        /// <param name="book"></param>
        /// <param name="author"></param>
        /// <param name="publisher"></param>
        /// <param name="categories"></param>
        public void AddItem(Book book, Author author, Publisher publisher, Category[] categories)
        {
            DisplayItemBook displayItem = new DisplayItemBook(book, author, publisher, categories);
            displayItem.Location = new Point(0, (itemHeight + 2) * Controls.Count);
            UpdateControlWidth(displayItem);

            Controls.Add(displayItem);
        }

        /// <summary>
        /// Adding information for movie
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="director"></param>
        /// <param name="actors"></param>
        /// <param name="categories"></param>
        public void AddItem(Movie movie, Director director, Actor[] actors, Category[] categories)
        {
            DisplayItemMovie displayItem = new DisplayItemMovie(movie, director, actors, categories);
            displayItem.Location = new Point(0, (itemHeight + 5) * Controls.Count + 5);
            UpdateControlWidth(displayItem);

            Controls.Add(displayItem);
        }
        
        /// <summary>
        /// Removing all information for books and movies
        /// </summary>
        public void Clear() => Controls.Clear();
        
        private void UpdateControlWidth(Control control)
        {
            control.Width = this.Width - 2 - (VScroll ? SystemInformation.VerticalScrollBarWidth : 0);
        }

        private void ListItems_Resize(object sender, System.EventArgs e)
        {
            foreach(Control control in this.Controls)
            {
                UpdateControlWidth(control);
            }
        }
    }
}
