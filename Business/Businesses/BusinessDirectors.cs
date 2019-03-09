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

        public void add(Director director)
        {
            using (database = new CatalogDbContext())
            {
                database.directors.Add(director);
            }
        }

        public Director getDirector(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Director director in database.directors)
                {
                    return director;
                }
            }

            throw new Exception("Director with this id does not exist!");
        }

        public List<Director> getAllDirectors()
        {
            using (database = new CatalogDbContext())
            {
                return database.directors.ToList();
            }
        }
    }
}
