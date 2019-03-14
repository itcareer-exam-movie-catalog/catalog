using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Business.Businesses;
using Data.Model;

namespace WindowsFromApp.Controls
{
    class DisplayItemGrid : Panel
    {
        private int cols;
        private Size itemSize;

        public DisplayItemGrid() : this(4) { }

        public DisplayItemGrid(int cols)
        {
            this.cols = cols;
            this.CalculateItemSize();
            this.BackColor = Color.LightGray;
            this.AutoScroll = true;
        }
        
        public void SetItems(List<Book> books, BusinessAuthors businessAuthors, BusinessCategories businessCategories, BusinessPublishers businessPublishers)
        {
            this.Controls.Clear();

            int count = 0;
            foreach(Book book in books)
            {
                Author author = businessAuthors.GetAuthor(book.authorId);
                Publisher publisher = businessPublishers.GetPublisher(book.publisherId);
                List<Category> categories = new List<Category>();

                foreach(string id in book.categoryIds.Split(','))
                {
                    try
                    {
                        categories.Add(businessCategories.GetCategory(int.Parse(id)));
                    }
                    catch(Exception e)
                    {
                        throw new Exception("Error on categoryIds in book with id " + book.id);
                    }
                }

                GridItemBook item = new GridItemBook(book, author, publisher, categories);
                item.Left = 5 + (itemSize.Width + 5) * (count % cols);
                item.Top = 5 + (itemSize.Height + 5) * (count / cols);
                item.Size = itemSize;

                count++;
                this.Controls.Add(item);
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);

            this.CalculateItemSize();
        }

        private void CalculateItemSize()
        {
            this.itemSize = new Size();

            this.itemSize.Width = this.Width / cols - 10;
            this.itemSize.Height = this.itemSize.Width * 4 / 3;
        }
    }
}
