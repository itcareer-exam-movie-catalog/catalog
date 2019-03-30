using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessDirectors
    {
        private CatalogDbContext database;

        public BusinessDirectors()
        {
            database = new CatalogDbContext();
        }

        /// <summary>
        /// Constructor that reupdates the database context.
        /// </summary>
        public BusinessDirectors(CatalogDbContext cDbContext)
        {
            database = cDbContext;
        }

        /// <summary>
        /// Returns the database context.
        /// </summary>
        public CatalogDbContext GetCatalogDbContext()
        {
            return database;
        }

        /// <summary>
        /// Adds a new director to the database.
        /// </summary>
        /// <param name="director">The director</param>
        public void AddDirector(Director director)
        {
            using (database)
            {
                if (director != null)
                {
                    database.Directors.Add(director);
                    database.SaveChanges();
                    return;
                }

                throw new ArgumentNullException("Director mustn't be empty/null.");
            }
        }

        /// <summary>
        /// Gets the director from the database by his id.
        /// </summary>
        /// <param name="id">The director's id</param>
        public Director GetDirector(int id)
        {
            using (database)
            {
                foreach (Director director in database.Directors)
                {
                    if (director.Id == id)
                    {
                        return director;
                    }
                }
            }

            throw new IndexOutOfRangeException("Director with this id does not exist!");
        }

        /// <summary>
        /// Deletes the director from the database by his id.
        /// </summary>
        /// <param name="id">The director's id</param>
        public void DeleteDirector(int id)
        {
            using (database)
            {
                foreach (Director director in database.Directors)
                {
                    if (director.Id == id)
                    {
                        database.Directors.Remove(director);
                        database.SaveChanges();
                        return; ;
                    }
                }
            }

            throw new IndexOutOfRangeException("Director with this id does not exist!");
        }

        /// <summary>
        /// Gets a list of all directors from the database.
        /// </summary>
        public List<Director> GetAllDirectors()
        {
            using (database)
            {
                return database.Directors.ToList();
            }
        }
    }
}
