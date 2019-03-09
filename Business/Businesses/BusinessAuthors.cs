using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessAuthors
    {
        private cDbContext database;

        public void add(Author author)
        {
            using (database = new cDbContext())
            {
                database.authors.Add(author);
            }
        }

        public Author getAuthor(int id)
        {
            using (database = new cDbContext())
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
            using (database = new cDbContext())
            {
                return database.authors.ToList();
            }
        }
    }
}
