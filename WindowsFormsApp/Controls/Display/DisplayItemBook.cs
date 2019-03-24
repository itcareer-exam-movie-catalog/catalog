using Data.Model;
using System.Drawing;
using WindowsFormsApp.Controls.Display;

namespace WindowsFormsApp.Controls
{
    /// <summary>
    /// Class for store all data for book
    /// </summary>
    public partial class DisplayItemBook : DisplayItem
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
        /// Refresh display information for current book
        /// </summary>
        public override void RefreshDisplayInfo()
        {
            this.label1.Text = book.Title;
            this.pictureBox1.BackgroundImage = this.image;
        }

        public override string GetTitle() => book.Title;
        public override float GetPrice() => (float)book.Price;
        public override int GetPublicationYear() => book.PublicationYear;
    }
}
