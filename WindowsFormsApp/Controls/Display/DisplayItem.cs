using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp.Controls.Display
{
    /// <summary>
    /// Base class for displaying book or movie info in ListItems
    /// </summary>
    public partial class DisplayItem : UserControl
    {
        private Color defaultBackColor;
        private Color mouseOverBackColor;

        public DisplayItem()
        {
            InitializeComponent();

            this.defaultBackColor = Color.LightGray;
            this.mouseOverBackColor = Color.DarkGray;
        }

        /// <summary>
        /// Refresh display information for current book or movie
        /// </summary>
        public virtual void RefreshDisplayInfo() { }

        /// <summary>
        /// Update the background color when the mouse comes out of control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayItem_MouseLeave(object sender, System.EventArgs e) => this.BackColor = defaultBackColor;

        /// <summary>
        /// Update background color when mouse enter the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayItem_MouseEnter(object sender, System.EventArgs e) => this.BackColor = mouseOverBackColor;

        /// <summary>
        /// Changing current page to review information for book or movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayItem_MouseDoubleClick(object sender, MouseEventArgs e) {}
    }
}
