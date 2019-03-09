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

        public void add(Book book)
        {
            using (database = new CatalogDbContext())
            {
                database.books.Add(book);
            }
        }

        public Book getBook(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Book book in database.books)
                {
                    return book;
                }
            }

            throw new Exception("Book with this id does not exist!");
        }

        public List<Book> getAllBooks()
        {
            using (database = new CatalogDbContext())
            {
                return database.books.ToList();
            }
        }
    }
}
