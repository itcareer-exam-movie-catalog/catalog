namespace WindowsFormsApp
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchItem1 = new WindowsFormsApp.Controls.Pages.SearchItem();
            this.SuspendLayout();
            // 
            // searchItem1
            // 
            this.searchItem1.Location = new System.Drawing.Point(12, 12);
            this.searchItem1.Name = "searchItem1";
            this.searchItem1.Size = new System.Drawing.Size(859, 534);
            this.searchItem1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 559);
            this.Controls.Add(this.searchItem1);
            this.MinimumSize = new System.Drawing.Size(900, 598);
            this.Name = "Form1";
            this.Text = "Catalog";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Pages.SearchItem searchItem1;
    }
}

