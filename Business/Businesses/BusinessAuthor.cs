using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Bussiness
{
    public class BusinessAuthor
    {
        private cDbContext cDbContext;

        public void addNewAuthor(Author author)
        {
            using (cDbContext = new cDbContext())
            {
                cDbContext.authors.Add(author);
                cDbContext.SaveChanges();
            }
        }
        
        public Author getAuhor(int id)
        {
            using (cDbContext = new cDbContext())
            {
                foreach(Author author in cDbContext.authors)
                {
                    if(id == author.id)
                    {
                        return author;
                    }
                }
            }

            throw new InvalidOperationException("Author with this id does not exist!");
        }
        
        public List<Author> getAllAuthors()
        {
            using (cDbContext = new cDbContext())
            {
                return cDbContext.authors.ToList();
            }
        }
    }
}
