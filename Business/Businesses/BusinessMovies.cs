using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessMovies
    {
        private cDbContext database;

        public void add(Movie movie)
        {
            using (database = new cDbContext())
            {
                database.movies.Add(movie);
            }
        }

        public Movie getMovie(int id)
        {
            using (database = new cDbContext())
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
            using (database = new cDbContext())
            {
                return database.movies.ToList();
            }
        }
    }
}
