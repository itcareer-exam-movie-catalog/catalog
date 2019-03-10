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

        /// <summary>
        ///     Add new author to database
        /// </summary>
        /// <param name="author"></param>
        public void AddAuthor(Author author)
        {
            using (database = new CatalogDbContext())
            {
                database.authors.Add(author);
                database.SaveChanges();
            }
        }

        /// <summary>
        ///     Get author from database by id
        /// </summary>
        /// <param name="id"></param>
        public Author GetAuthor(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Author author in database.authors)
                {
                    if (author.id == id)
                    {
                        return author;
                    }
                }
            }

            throw new Exception("Author with this id does not exist!");
        }

        /// <summary>
        ///     Delete author from database by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteActor(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Author author in database.authors)
                {
                    if(id == author.id)
                    {
                        database.authors.Remove(author);
                        database.SaveChanges();
                        return;
                    }
                }
            }

            throw new Exception("Author with this id does not exist!");
        }

        /// <summary>
        ///     Get list of all authors from database by id
        /// </summary>
        public List<Author> getAllAuthors()
        {
            using (database = new CatalogDbContext())
            {
                return database.authors.ToList();
            }
        }
    }
}
