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
            this.showPanel = new System.Windows.Forms.Panel();
            this.applyFilters = new System.Windows.Forms.Button();
            this.filters = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.searchInEverything = new System.Windows.Forms.RadioButton();
            this.searchInTitles = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.showMovies = new System.Windows.Forms.CheckBox();
            this.showBooks = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectAllCategories = new System.Windows.Forms.CheckBox();
            this.selectCategories = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.enterMaxPrice = new System.Windows.Forms.TextBox();
            this.enterMinPrice = new System.Windows.Forms.TextBox();
            this.showItems = new WindowsFormsApp.Controls.ListItems();
            this.showPanel.SuspendLayout();
            this.filters.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showPanel
            // 
            this.showPanel.Controls.Add(this.applyFilters);
            this.showPanel.Controls.Add(this.filters);
            this.showPanel.Controls.Add(this.showItems);
            this.showPanel.Location = new System.Drawing.Point(13, 13);
            this.showPanel.Name = "showPanel";
            this.showPanel.Size = new System.Drawing.Size(859, 536);
            this.showPanel.TabIndex = 0;
            // 
            // applyFilters
            // 
            this.applyFilters.Location = new System.Drawing.Point(4, 492);
            this.applyFilters.Name = "applyFilters";
            this.applyFilters.Size = new System.Drawing.Size(184, 40);
            this.applyFilters.TabIndex = 3;
            this.applyFilters.Text = "Apply";
            this.applyFilters.UseVisualStyleBackColor = true;
            this.applyFilters.Click += new System.EventHandler(this.applyFilters_Click);
            // 
            // filters
            // 
            this.filters.AutoScroll = true;
            this.filters.Controls.Add(this.groupBox4);
            this.filters.Controls.Add(this.groupBox3);
            this.filters.Controls.Add(this.groupBox2);
            this.filters.Controls.Add(this.groupBox1);
            this.filters.Location = new System.Drawing.Point(4, 4);
            this.filters.Name = "filters";
            this.filters.Size = new System.Drawing.Size(184, 482);
            this.filters.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.searchInEverything);
            this.groupBox4.Controls.Add(this.searchInTitles);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.searchBox);
            this.groupBox4.Location = new System.Drawing.Point(4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(174, 85);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search";
            // 
            // searchInEverything
            // 
            this.searchInEverything.AutoSize = true;
            this.searchInEverything.Checked = true;
            this.searchInEverything.Location = new System.Drawing.Point(14, 62);
            this.searchInEverything.Name = "searchInEverything";
            this.searchInEverything.Size = new System.Drawing.Size(75, 17);
            this.searchInEverything.TabIndex = 12;
            this.searchInEverything.TabStop = true;
            this.searchInEverything.Text = "Everything";
            this.searchInEverything.UseVisualStyleBackColor = true;
            this.searchInEverything.CheckedChanged += new System.EventHandler(this.searchInEverything_CheckedChanged);
            // 
            // searchInTitles
            // 
            this.searchInTitles.AutoSize = true;
            this.searchInTitles.Location = new System.Drawing.Point(100, 62);
            this.searchInTitles.Name = "searchInTitles";
            this.searchInTitles.Size = new System.Drawing.Size(50, 17);
            this.searchInTitles.TabIndex = 11;
            this.searchInTitles.Text = "Titles";
            this.searchInTitles.UseVisualStyleBackColor = true;
            this.searchInTitles.CheckedChanged += new System.EventHandler(this.searchInTitles_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Search In:";
            // 
            // searchBox
            // 
            this.searchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.searchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchBox.Location = new System.Drawing.Point(6, 19);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(159, 20);
            this.searchBox.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.showMovies);
            this.groupBox3.Controls.Add(this.showBooks);
            this.groupBox3.Location = new System.Drawing.Point(7, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 47);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Type";
            // 
            // showMovies
            // 
            this.showMovies.AutoSize = true;
            this.showMovies.Checked = true;
            this.showMovies.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMovies.Location = new System.Drawing.Point(87, 20);
            this.showMovies.Name = "showMovies";
            this.showMovies.Size = new System.Drawing.Size(60, 17);
            this.showMovies.TabIndex = 1;
            this.showMovies.Text = "Movies";
            this.showMovies.UseVisualStyleBackColor = true;
            // 
            // showBooks
            // 
            this.showBooks.AutoSize = true;
            this.showBooks.Checked = true;
            this.showBooks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBooks.Location = new System.Drawing.Point(11, 19);
            this.showBooks.Name = "showBooks";
            this.showBooks.Size = new System.Drawing.Size(56, 17);
            this.showBooks.TabIndex = 0;
            this.showBooks.Text = "Books";
            this.showBooks.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectAllCategories);
            this.groupBox2.Controls.Add(this.selectCategories);
            this.groupBox2.Location = new System.Drawing.Point(7, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 182);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Category";
            // 
            // selectAllCategories
            // 
            this.selectAllCategories.AutoSize = true;
            this.selectAllCategories.Checked = true;
            this.selectAllCategories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectAllCategories.Location = new System.Drawing.Point(10, 19);
            this.selectAllCategories.Name = "selectAllCategories";
            this.selectAllCategories.Size = new System.Drawing.Size(70, 17);
            this.selectAllCategories.TabIndex = 2;
            this.selectAllCategories.Text = "Select All";
            this.selectAllCategories.UseVisualStyleBackColor = true;
            this.selectAllCategories.CheckedChanged += new System.EventHandler(this.selectAllCategories_CheckedChanged);
            // 
            // selectCategories
            // 
            this.selectCategories.CheckOnClick = true;
            this.selectCategories.FormattingEnabled = true;
            this.selectCategories.Location = new System.Drawing.Point(6, 37);
            this.selectCategories.Name = "selectCategories";
            this.selectCategories.Size = new System.Drawing.Size(165, 139);
            this.selectCategories.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.enterMaxPrice);
            this.groupBox1.Controls.Add(this.enterMinPrice);
            this.groupBox1.Location = new System.Drawing.Point(7, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 69);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Min";
            // 
            // enterMaxPrice
            // 
            this.enterMaxPrice.Location = new System.Drawing.Point(81, 38);
            this.enterMaxPrice.Name = "enterMaxPrice";
            this.enterMaxPrice.Size = new System.Drawing.Size(63, 20);
            this.enterMaxPrice.TabIndex = 3;
            this.enterMaxPrice.TextChanged += new System.EventHandler(this.enterMaxPrice_TextChanged);
            // 
            // enterMinPrice
            // 
            this.enterMinPrice.Location = new System.Drawing.Point(81, 12);
            this.enterMinPrice.Name = "enterMinPrice";
            this.enterMinPrice.Size = new System.Drawing.Size(63, 20);
            this.enterMinPrice.TabIndex = 2;
            this.enterMinPrice.TextChanged += new System.EventHandler(this.enterMinPrice_TextChanged);
            // 
            // showItems
            // 
            this.showItems.AutoScroll = true;
            this.showItems.BackColor = System.Drawing.Color.DarkGray;
            this.showItems.Location = new System.Drawing.Point(194, 4);
            this.showItems.Name = "showItems";
            this.showItems.Size = new System.Drawing.Size(662, 529);
            this.showItems.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.showPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.showPanel.ResumeLayout(false);
            this.filters.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel showPanel;
        private Controls.ListItems showItems;
        private System.Windows.Forms.CheckedListBox selectCategories;
        private System.Windows.Forms.Panel filters;
        private System.Windows.Forms.TextBox enterMaxPrice;
        private System.Windows.Forms.TextBox enterMinPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox showMovies;
        private System.Windows.Forms.CheckBox showBooks;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button applyFilters;
        private System.Windows.Forms.CheckBox selectAllCategories;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton searchInEverything;
        private System.Windows.Forms.RadioButton searchInTitles;
    }
}

