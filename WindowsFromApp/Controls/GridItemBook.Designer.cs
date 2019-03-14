namespace WindowsFromApp.Controls
{
    partial class GridItemBook
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelDisplayTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDisplayTitle
            // 
            this.labelDisplayTitle.AutoSize = true;
            this.labelDisplayTitle.Location = new System.Drawing.Point(30, 55);
            this.labelDisplayTitle.Name = "labelDisplayTitle";
            this.labelDisplayTitle.Size = new System.Drawing.Size(35, 13);
            this.labelDisplayTitle.TabIndex = 0;
            this.labelDisplayTitle.Text = "label1";
            // 
            // GridItemBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDisplayTitle);
            this.Name = "GridItemBook";
            this.Size = new System.Drawing.Size(300, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDisplayTitle;
    }
}
