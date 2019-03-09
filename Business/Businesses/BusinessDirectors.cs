using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessDirectors
    {
        private cDbContext database;

        public void add(Director director)
        {
            using (database = new cDbContext())
            {
                database.directors.Add(director);
            }
        }

        public Director getDirector(int id)
        {
            using (database = new cDbContext())
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
            using (database = new cDbContext())
            {
                return database.directors.ToList();
            }
        }
    }
}
