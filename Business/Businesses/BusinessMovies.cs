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
        /// Constructor that reupdates the database context.
        /// </summary>
        public BusinessMovies(CatalogDbContext cDbContext)
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
        /// Adds a new movie to the database.
        /// </summary>
        /// <param name="movie">The movie</param>
        public void AddMovie(Movie movie)
        {
            using (database = new CatalogDbContext())
            {
                database.Movies.Add(movie);
                database.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the movie from the database by its id.
        /// </summary>
        /// <param name="id">The movie's id</param>
        public Movie GetMovie(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Movie movie in database.Movies)
                {
                    if (movie.Id == id)
                    {
                        return movie;
                    }
                }
            }

            throw new Exception("Movie with this id does not exist!");
        }

        /// <summary>
        /// Deletes the movie from the database by its id.
        /// </summary>
        /// <param name="id">The movie's id</param>
        public void DeleteMovie(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Movie movie in database.Movies)
                {
                    if (movie.Id == id)
                    {
                        database.Movies.Remove(movie);
                        database.SaveChanges();
                        return; 
                    }
                }
            }

            throw new Exception("Movie with this id does not exist!");
        }

        /// <summary>
        /// Gets a list of all movies from the database.
        /// </summary>
        public List<Movie> GetAllMovies()
        {
            using (database = new CatalogDbContext())
            {
                return database.Movies.ToList();
            }
        }

        /// <summary>
        /// Gets all the movies based on the chosen category id.
        /// </summary>
        /// <param name="categoryId">The category's id</param>
        public List<Movie> GetMoviesByCategory(int categoryId)
        {
            List<Movie> movies = new List<Movie>();
            using (database = new CatalogDbContext())
            {
                foreach (Movie movie in database.Movies)
                {
                    List<int> moviesCategory = movie.CategoryIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    if (moviesCategory.Contains(categoryId))
                    {
                        movies.Add(movie);
                    }
                }
            }

            return movies;
        }

        /// <summary>
        /// Gets all the movies that contain the same key name/title.
        /// </summary>
        /// <param name="movieTitle">The movie's entered name</param>
        public List<Movie> GetMoviesByTitle(string movieTitle)
        {
            List<Movie> moviesWithSameName = new List<Movie>();
            using (database = new CatalogDbContext())
            {
                foreach (Movie movie in database.Movies)
                {
                    if (movie.Title.ToLower().Contains(movieTitle.ToLower()))
                    {
                        moviesWithSameName.Add(movie);
                    }
                }

                if (moviesWithSameName.Count != 0)
                {
                    return moviesWithSameName;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets all the movies that have been produced by the entered director.
        /// </summary>
        /// <param name="directorName">The director's name</param>
        public List<Movie> GetMoviesByDirector(string directorName)
        {

            List<Movie> directorMovies = new List<Movie>();

            List<int> directorIds = FindDirectorId(directorName);

            using (database = new CatalogDbContext())
            {
                if (directorIds.Count == 1)
                {
                    int directorId = directorIds[0];

                    foreach (Movie movie in database.Movies)
                    {
                        if (movie.DirectorId == directorId)
                        {
                            directorMovies.Add(movie);
                        }
                    }
                }
                else if (directorIds.Count > 1)
                {
                    for (int i = 0; i < directorIds.Count; i++)
                    {
                        int directorId = directorIds[i];

                        foreach (Movie movie in database.Movies)
                        {
                            if (movie.DirectorId == directorId)
                            {
                                directorMovies.Add(movie);
                            }
                        }
                    }
                }
                else
                {
                    return new List<Movie>();
                }
            }

            return directorMovies;

        }

        /// <summary>
        /// Finds the director's id based on his name.
        /// </summary>
        /// <param name="directorName">The director's name</param>
        private List<int> FindDirectorId(string directorName)
        {
            BusinessDirectors businessDirector = new BusinessDirectors();
            string[] directorFullName = directorName.Split().ToArray();
            List<int> directorIds = new List<int>();

            using (database = new CatalogDbContext())
            {
                if (directorFullName.Length > 1)
                {
                    string directorFirstName = directorFullName[0];
                    string directorLastName = directorFullName[1];

                    foreach (Director director in database.Directors)
                    {
                        if (director.FirstName.ToLower().Equals(directorFirstName.ToLower()) && director.LastName.ToLower().Equals(directorLastName.ToLower()))
                        {
                            directorIds.Add(director.Id);
                        }
                    }
                }
                else if (directorFullName.Length == 1)
                {
                    string directorKnownName = directorFullName[0];


                    foreach (Director director in database.Directors)
                    {
                        if (director.FirstName.ToLower().Equals(directorKnownName.ToLower()) || director.LastName.ToLower().Equals(directorKnownName.ToLower()))
                        {
                            directorIds.Add(director.Id);
                        }
                    }
                }
                else
                {
                    return new List<int>();
                }
            }

            return directorIds;
        }

        /// <summary>
        /// Gets all the movies based on their actor's id
        /// </summary>
        /// <param name="actorId">The actor's id</param>
        public List<Movie> GetMoviesByActorId(int actorId)
        {
            if (actorId <= 0)
            {
                return new List<Movie>();
            }

            List<Movie> movies = new List<Movie>();

            using (database = new CatalogDbContext())
            {
                foreach (Movie movie in database.Movies)
                {
                    List<int> actorIds = movie.ActorIds
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).ToList();

                    if (actorIds.Contains(actorId))
                    {
                        movies.Add(movie);
                    }
                }
            }

            return movies;
        }
    }
}
