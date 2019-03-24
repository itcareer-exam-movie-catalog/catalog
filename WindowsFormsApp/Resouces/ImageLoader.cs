using System.Collections.Generic;
using System.Drawing;
using Business.Businesses;
using Data.Model;

namespace WindowsFormsApp.Resouces
{
    public class ImageLoader
    {
        static private string ImageDir = @"C:\Users\HP_15\Documents\GitHub\catalog\WindowsFormsApp\Resouces\";

        private BusinessBooks businessBooks;
        private Dictionary<int, Image> bookImages;

        public ImageLoader()
        {
            businessBooks = new BusinessBooks();
            bookImages = new Dictionary<int, Image>();
        }

        public void LoadImages()
        {
            BusinessBooks businessBooks = new BusinessBooks();
            foreach (Book book in businessBooks.GetAllBooks())
            {
                Image image = null;
                try
                {
                    image = Image.FromFile(ImageDir + @"books\" + book.Id + ".jpg");
                }
                catch { }

                bookImages.Add(book.Id, image);
            }
        }

        public Image GetBookImage(int id)
        {
            Image image;
            bookImages.TryGetValue(id, out image);

            return image;
        }
    }
}
