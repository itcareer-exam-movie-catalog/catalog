using System.Windows.Forms;
using WindowsFormsApp.Controls.Display;

namespace WindowsFormsApp.Controls.Pages
{
    public partial class ReviewItem : UserControl
    {
        private DisplayItem displayItem;

        public ReviewItem()
        {
            InitializeComponent();
        }

        public void SetDisplayItem(DisplayItem displayItem) => this.displayItem = displayItem;
    }
}
