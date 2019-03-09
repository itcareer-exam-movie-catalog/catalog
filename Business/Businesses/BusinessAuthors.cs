using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessAuthors
    {
        private CatalogDbContext database;

        public void add(Author author)
        {
            using (database = new CatalogDbContext())
            {
                database.authors.Add(author);
            }
        }

        public Author getAuthor(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Author author in database.authors)
                {
                    return author;
                }
            }

            throw new Exception("Author with this id does not exist!");
        }

        public List<Author> getAllAuthors()
        {
            using (database = new CatalogDbContext())
            {
                return database.authors.ToList();
            }
        }
    }
}
