using System.Collections.Generic;
using System.Drawing;
using Business.Businesses;
using Data.Model;

namespace WindowsFormsApp.Resouces
{
    public class ImageLoader
    {
        private string ImageDir = @"\Resources\";

        private BusinessBooks businessBooks;
        private Image[] bookImages;

        public ImageLoader()
        {
            businessBooks = new BusinessBooks();
            bookImages = new Image[businessBooks.GetAllBooks().Count];
        }

        public void LoadImages()
        {
            BusinessBooks businessBooks = new BusinessBooks();
            for (int a = 0; a < businessBooks.GetAllBooks().Count; a++)
            {
                Image image = null;
                try
                {
                    image = Image.FromFile(ImageDir + @"books\" + a + ".jpg");
                }
                catch
                {
                    image = Image.FromFile(ImageDir + "null.jpg");
                }

                bookImages[a] = image;
            }
        }

        public Image GetBookImage(int id) => bookImages[id - 1];
    }
}
