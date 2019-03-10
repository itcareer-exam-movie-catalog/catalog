using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessBooks
    {
        private CatalogDbContext database;

        /// <summary>
        ///     Add new book to database
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            using (database = new CatalogDbContext())
            {
                database.books.Add(book);
                database.SaveChanges();
            }
        }

        /// <summary>
        ///     Get book from database by id
        /// </summary>
        /// <param name="id"></param>
        public Book GetBook(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Book book in database.books)
                {
                    if (id == book.id)
                    {
                        return book;
                    }
                }
            }

            throw new Exception("Book with this id does not exist!");
        }

        /// <summary>
        ///     Delete book from database by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBook(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Book book in database.books)
                {
                    if (id == book.id)
                    {
                        database.books.Remove(book);
                        database.SaveChanges();
                        return;
                    }
                }
            }

            throw new Exception("Book with this id does not exist!");
        }

        /// <summary>
        ///     Get list of books from database by id
        /// </summary>
        public List<Book> GetAllBooks()
        {
            using (database = new CatalogDbContext())
            {
                return database.books.ToList();
            }
        }
    }
}
