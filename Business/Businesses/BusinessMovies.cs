using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessMovies
    {
        private CatalogDbContext database;

        public void add(Movie movie)
        {
            using (database = new CatalogDbContext())
            {
                database.movies.Add(movie);
            }
        }

        public Movie getMovie(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Movie movie in database.movies)
                {
                    return movie;
                }
            }

            throw new Exception("Movie with this id does not exist!");
        }

        public List<Movie> getAllMovies()
        {
            using (database = new CatalogDbContext())
            {
                return database.movies.ToList();
            }
        }
    }
}
