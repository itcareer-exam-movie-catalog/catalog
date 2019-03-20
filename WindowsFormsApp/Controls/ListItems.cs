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

        public void AddItem(Book book, Author author, Publisher publisher, Category[] categories)
        {
            DisplayItemBook displayItem = new DisplayItemBook(book, author, publisher, categories);
            displayItem.Size = new Size(this.Width - 20, itemHeight);
            displayItem.Location = new Point(0, (itemHeight + 5) * Controls.Count + 5);

            Controls.Add(displayItem);
        }

        public void AddItem(Movie movie, Director director, Actor[] actors, Category[] categories)
        {
            DisplayItemMovie displayItem = new DisplayItemMovie(movie, director, actors, categories);
            displayItem.Size = new Size(this.Width - 20, itemHeight);
            displayItem.Location = new Point(0, (itemHeight + 5) * Controls.Count + 5);

            Controls.Add(displayItem);
        }

        public void Clear()
        {
            Controls.Clear();
        }
    }
}
