using System.Collections.Generic;
using System.Drawing;
using Business.Businesses;
using Data.Model;

namespace WindowsFormsApp.Resouces
{
    public class ImageLoader
    {
        static private string ImageDir = @"D:\Projects\github\catalog\WindowsFormsApp\Resouces\";

        private Dictionary<int, Image> bookImages;
        private Dictionary<int, Image> movieImages;

        public ImageLoader()
        {
            bookImages = new Dictionary<int, Image>();
            movieImages = new Dictionary<int, Image>();
        }

        /// <summary>
        /// Load all the images 
        /// </summary>
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

            BusinessMovies businessMovies = new BusinessMovies();
            foreach (Movie movie in businessMovies.GetAllMovies())
            {
                Image image = null;
                try
                {
                    image = Image.FromFile(ImageDir + @"movies\" + movie.Id + ".jpg");
                }
                catch { }

                movieImages.Add(movie.Id, image);
            }
        }

        /// <summary>
        /// Returning the image of book
        /// </summary>
        /// <param name="id">Book`s id</param>
        /// <returns></returns>
        public Image GetBookImage(int id)
        {
            Image image;
            bookImages.TryGetValue(id, out image);

            return image;
        }

        /// <summary>
        /// Returning the image of movie
        /// </summary>
        /// <param name="id">Movie`s id</param>
        /// <returns></returns>
        public Image GetMovieImage(int id)
        {
            Image image;
            movieImages.TryGetValue(id, out image);

            return image;
        }
    }
}
