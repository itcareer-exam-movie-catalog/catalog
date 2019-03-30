using System.Windows.Forms;
using WindowsFormsApp.Controls.Display;

namespace WindowsFormsApp.Controls.Pages
{
    public partial class ReviewItem : UserControl
    {
        private DisplayItem displayItem;
        private Form1 form;

        public ReviewItem()
        {
            InitializeComponent();

            displayItem = null;
        }

        public void SetDisplayItem(DisplayItem displayItem)
        {
            this.displayItem = displayItem;
            form.ShowLogic();
        }

        public void SetForm(Form1 form) => this.form = form;
        public bool HasItem { get => displayItem != null; }

        private void back_Click(object sender, System.EventArgs e)
        {
            this.displayItem = null;
            form.ShowLogic();
        }
    }
}
