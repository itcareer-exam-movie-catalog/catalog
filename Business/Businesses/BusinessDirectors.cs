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

        /// <summary>
        /// Adds a new director to the database.
        /// </summary>
        /// <param name="director">The director</param>
        public void Add(Director director)
        {
            using (database = new CatalogDbContext())
            {
                database.Directors.Add(director);
                database.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the director from the database by his id.
        /// </summary>
        /// <param name="id">The director's id</param>
        public Director GetDirector(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Director director in database.Directors)
                {
                    if (director.Id == id)
                    {
                        return director;
                    }
                }
            }

            throw new Exception("Director with this id does not exist!");
        }

        /// <summary>
        /// Deletes the director from the database by his id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDirector(int id)
        {
            using (database = new CatalogDbContext())
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

            throw new Exception("Director with this id does not exist!");
        }

        /// <summary>
        /// Gets a list of all directors from the database.
        /// </summary>
        public List<Director> GetAllDirectors()
        {
            using (database = new CatalogDbContext())
            {
                return database.Directors.ToList();
            }
        }
    }
}
