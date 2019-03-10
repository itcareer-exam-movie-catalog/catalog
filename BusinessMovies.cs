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

        /// <summary>
        ///     Add new movie to database
        /// </summary>
        /// <param name="movie"></param>
        public void AddMovie(Movie movie)
        {
            using (database = new CatalogDbContext())
            {
                database.movies.Add(movie);
                database.SaveChanges();
            }
        }

        /// <summary>
        ///     Get movie from database by id
        /// </summary>
        /// <param name="id"></param>
        public Movie GetMovie(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Movie movie in database.movies)
                {
                    if (movie.id == id)
                    {
                        return movie;
                    }
                }
            }

            throw new Exception("Movie with this id does not exist!");
        }

        /// <summary>
        ///     Delete movie from database by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMovie(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Movie movie in database.movies)
                {
                    if (movie.id == id)
                    {
                        database.movies.Remove(movie);
                        database.SaveChanges();
                        return; 
                    }
                }
            }

            throw new Exception("Movie with this id does not exist!");
        }

        /// <summary>
        ///     Get list of movies from database by id
        /// </summary>
        public List<Movie> GetAllMovies()
        {
            using (database = new CatalogDbContext())
            {
                return database.movies.ToList();
            }
        }
    }
}
