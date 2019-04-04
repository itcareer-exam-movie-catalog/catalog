using Data.Model;
using WindowsFormsApp.Controls.Display;

namespace WindowsFormsApp.Controls
{
    /// <summary>
    /// Class for storing all the data for book
    /// </summary>
    public partial class DisplayItemBook : DisplayItemBase
    {
        private Book book;
        private Author author;
        private Publisher publisher;
        private Category[] categories;

        public DisplayItemBook(Book book, Author author, Publisher publisher, Category[] categories) : base()
        {
            InitializeComponent();

            this.book = book;
            this.author = author;
            this.publisher = publisher;
            this.categories = categories;
        }

        /// <summary>
        /// Refreshing display information for current book
        /// </summary>
        public override void RefreshDisplayInfo()
        {
            this.displayTitle.Text = book.Title;
            this.displayAuthor.Text = author.FirstName + " " + author.LastName;
            this.pictureBox1.BackgroundImage = this.Image;
        }

        public Book Book { get => book; }
        public Author Author { get => author; }
        public Publisher Publisher { get => publisher; }
        public Category[] Categories { get => categories; }
    }
}
