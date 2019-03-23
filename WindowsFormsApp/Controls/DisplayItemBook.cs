using System.Drawing;
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

        private Color defaultBackColor;
        private Color overItemBackColor;

        private bool clicked;

        public DisplayItemBook(Book book, Author author, Publisher publisher, Category[] categories)
        {
            InitializeComponent();

            this.book = book;
            this.author = author;
            this.publisher = publisher;
            this.categories = categories;

            defaultBackColor = Color.LightGray;
            overItemBackColor = Color.DarkGray;
            this.BackColor = defaultBackColor;

            this.clicked = false;

            RefreshDisplayInfo();
        }

        public void RefreshDisplayInfo()
        {
            this.label1.Text = book.Title;
        }
        
        private void OnMouseOver(bool isOver) => this.BackColor = isOver ? overItemBackColor : defaultBackColor;
        private void DisplayItemBook_MouseEnter(object sender, System.EventArgs e) => OnMouseOver(true);
        private void DisplayItemBook_MouseLeave(object sender, System.EventArgs e) => OnMouseOver(false);
        private void DisplayItemBook_MouseDoubleClick(object sender, MouseEventArgs e) => clicked = true;

        
    }
}
