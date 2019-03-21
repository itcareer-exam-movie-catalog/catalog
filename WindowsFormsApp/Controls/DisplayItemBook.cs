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
    public partial class DisplayItemBook : UserControl
    {
        private Book book;
        private Author author;
        private Publisher publisher;
        private Category[] categories;

        public DisplayItemBook(Book book, Author author, Publisher publisher, Category[] categories)
        {
            InitializeComponent();

            this.book = book;
            this.author = author;
            this.publisher = publisher;
            this.categories = categories;

            RefreshDisplayInfo();
        }

        public void RefreshDisplayInfo()
        {
            this.label1.Text = book.Title;
        }
    }
}
