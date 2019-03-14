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

namespace WindowsFromApp.Controls
{
    public partial class GridItemBook : UserControl
    {
        private Book book;
        private Author author;
        private Publisher publisher;
        private List<Category> categories;
        /*
        public GridItemBook()
        {
            InitializeComponent();
        }*/

        public GridItemBook(Book book, Author author, Publisher publisher, List<Category> categories) : base()
        {
            InitializeComponent();

            this.book = book;
            this.author = author;
            this.publisher = publisher;
            this.categories = categories;

            this.labelDisplayTitle.Text = book.title;
        }
    }
}
