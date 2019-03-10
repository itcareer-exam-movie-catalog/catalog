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
        ///     Add new director to database
        /// </summary>
        /// <param name="director"></param>
        public void add(Director director)
        {
            using (database = new CatalogDbContext())
            {
                database.directors.Add(director);
                database.SaveChanges();
            }
        }

        /// <summary>
        ///     Get director from database by id
        /// </summary>
        /// <param name="id"></param>
        public Director getDirector(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Director director in database.directors)
                {
                    if (director.id == id)
                    {
                        return director;
                    }
                }
            }

            throw new Exception("Director with this id does not exist!");
        }

        /// <summary>
        ///     Delete director from database by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDirector(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Director director in database.directors)
                {
                    if (director.id == id)
                    {
                        database.directors.Remove(director);
                        database.SaveChanges();
                        return; ;
                    }
                }
            }

            throw new Exception("Director with this id does not exist!");
        }

        /// <summary>
        ///     Get list of directors from database by id
        /// </summary>
        public List<Director> GetAllDirectors()
        {
            using (database = new CatalogDbContext())
            {
                return database.directors.ToList();
            }
        }
    }
}
