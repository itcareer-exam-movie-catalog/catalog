using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Bussiness
{
    public class BusinessBook
    {
        private cDbContext cDbContext;
        
        public void addNewBook(Book book)
        {
            using (cDbContext = new cDbContext())
            {
                cDbContext.books.Add(book);
                cDbContext.SaveChanges();
            }
        }
        
        public Book getBook(int id)
        {
            using (cDbContext = new cDbContext())
            {
                foreach (Book book in cDbContext.books)
                {
                    if (id == book.id)
                    {
                        return book;
                    }
                }
            }

            throw new InvalidOperationException("Book with this id does not exist!");
        }
        
        public List<Book> getAllBooks()
        {
            using (cDbContext = new cDbContext())
            {
                return cDbContext.books.ToList();
            }
        }
    }
}
