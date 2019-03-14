using System;
using System.Collections.Generic;
using System.Linq;
using Business.Businesses;
using Data.Model;

namespace CatalogApp.ConsolePresentation.ModelPresentation
{
    public class Movies
    {
        private Display cDisplay = new Display();

        /// <summary>
        /// Shows you the Movie menu and its categories.
        /// </summary>
        public void ShowMovieCategories()
        {
            int categoryNumSelect = 1;
            BusinessCategories businessCategory = new BusinessCategories();

            Console.Clear();
            Console.WriteLine("Choose a category!");
            foreach (Category category in businessCategory.GetAllCategories())
            {
                string currCategoryName = category.name.ToLower();
                currCategoryName = currCategoryName.First().ToString().ToUpper() + "" + currCategoryName.Substring(1);

                Console.WriteLine($"{categoryNumSelect}.{currCategoryName}");
                categoryNumSelect++;
            }

            Console.WriteLine($"{categoryNumSelect}.Search for a movie");
            categoryNumSelect++;
            Console.WriteLine($"{categoryNumSelect}.Write the producer's name");
            categoryNumSelect++;
            Console.WriteLine($"{categoryNumSelect}.Write the actor's name");
            categoryNumSelect++;
            Console.WriteLine($"{categoryNumSelect}.Go Back");
            categoryNumSelect++;
            Console.WriteLine($"{categoryNumSelect}.Exit");
            Console.WriteLine(new string('-', 80));

            InputMovieCategories(categoryNumSelect);
        }

        /// <summary>
        /// Gets the input from the user and chooses whether to:
        /// show you the Movie titles, based on the selected category,
        /// let you search for a movie,
        /// let you search by a director's name,
        /// let you search by an actor's name,
        /// show you the Exit menu.
        /// </summary>
        /// <param name="categoryNumSelect">The total amount of options on the Movie menu</param>
        private void InputMovieCategories(int categoryNumSelect)
        {
            YourChoice();

            try
            {
                int selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case int n when (n >= 1 && n <= categoryNumSelect - 5):
                        ShowMovieTitles(selection);
                        break;
                    case int n when (n == categoryNumSelect - 4):
                        OriginalMovieSearch();
                        break;
                    case int n when (n == categoryNumSelect - 3):
                        InputDirectorName();
                        break;
                    case int n when (n == categoryNumSelect - 2):
                        InputActorName();
                        break;
                    case int n when (n == categoryNumSelect - 1):
                        cDisplay.ShowMenuMovieBook();
                        break;
                    case int n when (n == categoryNumSelect):
                        cDisplay.ExitMenu();
                        break;
                    default:
                        ShowMovieCategories();
                        break;
                }
            }
            catch
            {
                ShowMovieCategories();
            }

        }

        /// <summary>
        /// Searches for a movie.
        /// If there are more than 1 movie, then the program shows every movie, that contains the chosen name.
        /// If the input is an integer, between 1-3, the program gets back to a chosen previous menu.
        /// </summary>
        private void OriginalMovieSearch()
        {
            Console.Clear();
            Console.Write("Enter the title of the movie you want to search: ");
            string movieTitle = Console.ReadLine();
            int numSelection = 0;
            BusinessMovies businessMovie = new BusinessMovies();
            List<Movie> moviesWithSimilarName = businessMovie.GetMoviesByTitle(movieTitle);

            try
            {
                //Checks if the input is an integer
                if (int.TryParse(movieTitle, out numSelection) == true)
                {
                    if (int.Parse(movieTitle) == 1)
                    {
                        ShowMovieCategories();
                    }
                    else if (int.Parse(movieTitle) == 2)
                    {
                        cDisplay.ShowMenuMovieBook();
                    }
                    else if (int.Parse(movieTitle) == 3)
                    {
                        cDisplay.ExitMenu();
                    }
                    else
                    {
                        Console.Clear();
                        MovieSearch();
                    }
                }
                //checks if the movie title is empty
                else if (movieTitle == null || movieTitle == "")
                {
                    Console.WriteLine("You must enter something in order to search for it.\n");
                    GoBackMovieMenu();
                }
                //Checks how many movies with the key name exist.
                else if (moviesWithSimilarName.Count == 1)
                {
                    ShowMovieInformation(moviesWithSimilarName[0]);
                }
                else if (moviesWithSimilarName.Count > 1)
                {
                    ShowMoviesWithSimilarNames(moviesWithSimilarName);
                }
                else
                {
                    Console.WriteLine("There doesn't exist such movie in our catalog.\n");
                    GoBackMovieMenu();
                }
            }
            catch
            {

                Console.WriteLine("There doesn't exist such movie in our catalog.\n");
                GoBackMovieMenu();
            }

        }

        /// <summary>
        /// Shows all the movie titles, that are in the chosen category.
        /// User has the option to go back to a selected previous menu.
        /// </summary>
        /// <param name="selection">The chosen category's number/id</param>
        private void ShowMovieTitles(int selection)
        {
            Console.Clear();
            Console.WriteLine(new string('-', 80));

            BusinessCategories businessCategory = new BusinessCategories();
            string category = businessCategory.GetCategory(selection).name;

            Console.WriteLine("Here are some of the names: ");

            BusinessMovies businessMovies = new BusinessMovies();

            List<Movie> movies = businessMovies.GetMoviesByCategory(selection);
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie.title);
            }
            Console.WriteLine("1.Go back to categories");
            Console.WriteLine("2.Go back to movie/book menu");
            Console.WriteLine("3.Exit");
            MovieSearch();
        }

        /// <summary>
        /// Searches for a movie.
        /// Works exactly like the <see cref="OriginalMovieSearch"/> method, but prints out extra text.
        /// </summary>
        private void MovieSearch()
        {
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("If you want to select any of the other options, select a number from [1-3]");
            Console.Write("Otherwise - Enter the title of the movie you want to search: ");
            string movieTitle = Console.ReadLine();
            int numSelection = 0;
            BusinessMovies businessMovie = new BusinessMovies();
            List<Movie> moviesWithSimilarName = businessMovie.GetMoviesByTitle(movieTitle);

            try
            {
                //Checks if the input is an integer
                if (int.TryParse(movieTitle, out numSelection) == true)
                {
                    if (int.Parse(movieTitle) == 1)
                    {
                        ShowMovieCategories();
                    }
                    else if (int.Parse(movieTitle) == 2)
                    {
                        cDisplay.ShowMenuMovieBook();
                    }
                    else if (int.Parse(movieTitle) == 3)
                    {
                        cDisplay.ExitMenu();
                    }
                    else
                    {
                        Console.Clear();
                        MovieSearch();
                    }
                }
                //Checks if the movie title is empty
                else if (movieTitle == null || movieTitle == "")
                {
                    Console.WriteLine("You must enter something in order to search for it.\n");
                    GoBackMovieMenu();
                }
                //Checks how many movies with the key name exist.
                else if (moviesWithSimilarName.Count == 1)
                {
                    ShowMovieInformation(moviesWithSimilarName[0]);
                }
                else if (moviesWithSimilarName.Count > 1)
                {
                    ShowMoviesWithSimilarNames(moviesWithSimilarName);
                }
                else
                {
                    Console.WriteLine("There doesn't exist such movie in our catalog.\n");
                    GoBackMovieMenu();
                }
            }
            catch
            {

                Console.WriteLine("There doesn't exist such movie in our catalog.\n");
                GoBackMovieMenu();
            }
        }

        /// <summary>
        /// Shows information about the chosen movie.
        /// </summary>
        /// <param name="movie">The selected movie</param>
        private void ShowMovieInformation(Movie movie)
        {
            Console.Clear();
            BusinessCategories businessCategory = new BusinessCategories();

            BusinessDirectors directorBusiness = new BusinessDirectors();
            string director = directorBusiness.GetDirector(movie.directorId).firstName + " " + directorBusiness.GetDirector(movie.directorId).lastName;

            List<string> categories = new List<string>();
            List<int> categoryIds = movie.categoryIds
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            foreach (int categoryId in categoryIds)
            {
                categories.Add(businessCategory.GetCategory(categoryId).name);
            }

            BusinessActors businessActor = new BusinessActors();
            List<string> actors = new List<string>();
            List<int> actorIds = movie.actorIds
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            foreach (int actorId in actorIds)
            {
                actors.Add(businessActor.GetActor(actorId).firstName + " " + businessActor.GetActor(actorId).lastName);
            }

            Console.WriteLine("Here is some information about the movie of your choice:");
            Console.WriteLine($"Title: {movie.title}");
            Console.WriteLine($"Year released: {movie.publicationYear}");
            Console.WriteLine($"Director: {director}");
            Console.WriteLine($"Categories: {String.Join(", ", categories)}");
            Console.WriteLine($"Actors: {String.Join(", ", actors)}");

            GoBackMovieMenu();
        }

        /// <summary>
        /// Shows every movie that contains the same key name.
        /// </summary>
        /// <param name="moviesWithSimilarName">All of the movies with the same key name</param>
        private void ShowMoviesWithSimilarNames(List<Movie> moviesWithSimilarName)
        {
            Console.Clear();
            Console.WriteLine("Here are some of the movies, that have similar names.");
            int currentMovieNumber = 1;
            foreach (Movie movie in moviesWithSimilarName)
            {
                Console.WriteLine($"{currentMovieNumber}. {movie.title}");
                currentMovieNumber++;
            }
            Console.WriteLine($"{currentMovieNumber}. Go Back");
            currentMovieNumber++;
            Console.WriteLine($"{currentMovieNumber}. Exit");

            Console.WriteLine("Enter the number for the movie that you want to see more information about:");
            Console.Write("--> ");

            try
            {
                int movieNumberChoice = int.Parse(Console.ReadLine());
                if (movieNumberChoice > currentMovieNumber || movieNumberChoice <= 0)
                {
                    Console.WriteLine("Your number choice must be bigger than 0 and less than the total amount of movies shown.");
                    ShowMoviesWithSimilarNames(moviesWithSimilarName);
                }
                else if (movieNumberChoice == currentMovieNumber - 1)
                {
                    MovieSearch();
                }
                else if (movieNumberChoice == currentMovieNumber)
                {
                    cDisplay.ExitMenu();
                }
                else
                {
                    ShowMovieInformation(moviesWithSimilarName[movieNumberChoice]);
                }
            }
            catch
            {
                ShowMoviesWithSimilarNames(moviesWithSimilarName);
            }
        }

        /// <summary>
        /// Inputs the director's name.
        /// </summary>
        private void InputDirectorName()
        {
            Console.Clear();
            Console.WriteLine("Enter the director's name");
            Console.WriteLine("In case that you don't know his/her's full name, enter any of their known names");
            Console.WriteLine("and you will see every producer's, that has that name, movie");
            YourChoice();

            string directorName = Console.ReadLine();

            ShowDirectorMovies(directorName);
        }

        /// <summary>
        /// Shows all of the movies, which the chosen director has produced.
        /// </summary>
        /// <param name="directorName">The selected director's name</param>
        private void ShowDirectorMovies(string directorName)
        {
            Console.Clear();

            BusinessMovies businessMovie = new BusinessMovies();
            List<Movie> directorMovies = businessMovie.GetMoviesByDirector(directorName);
            if (directorMovies.Count == 0)
            {
                Console.WriteLine("The name that you entered is either invalid or the person hasn't produced any movies\n");
                GoBackMovieMenu();
            }
            else
            {
                Console.WriteLine("Here are some of the director's movies;");

                foreach (Movie directorMovie in directorMovies)
                {
                    Console.WriteLine(directorMovie.title);
                }
                Console.WriteLine("1.Go back to categories");
                Console.WriteLine("2.Go back to movie/book menu");
                Console.WriteLine("3.Exit");

                MovieSearch();
            }
        }

        /// <summary>
        /// Inputs the actor's name
        /// </summary>
        private void InputActorName()
        {
            Console.Clear();
            Console.WriteLine("Enter the actor's name");
            Console.WriteLine("In case that you don't know his/her's full name, enter any of their known names");
            Console.WriteLine("If you enter both names, the program will try to find an actor with those names");
            Console.WriteLine("If you enter only one name, it will print out every actor,");
            Console.WriteLine("that has the following name");
            YourChoice();

            string actorName = Console.ReadLine();

            ShowActorNames(actorName);
        }

        /// <summary>
        /// Chooses whether to show all actors, that share the same chosen name, if you entered only one name,
        /// or to show the chosen actor's movies, if you entered his first and last name.
        /// </summary>
        /// <param name="actorName">The selected actor's name</param>
        private void ShowActorNames(string actorName)
        {
            Console.Clear();

            string[] actorFullName = actorName.Split().ToArray();
            if (actorFullName.Length == 1)
            {
                List<Actor> actorsWithSameName = new List<Actor>();
                BusinessActors businessActor = new BusinessActors();

                foreach (Actor actor in businessActor.GetAllActors())
                {
                    if (actor.firstName.ToLower() == actorName.ToLower() || actor.lastName.ToLower() == actorName.ToLower())
                    {
                        actorsWithSameName.Add(actor);
                        Console.WriteLine(actor.firstName + " " + actor.lastName);
                    }
                }
                Console.WriteLine("1.Go back to categories");
                Console.WriteLine("2.Go back to movie/book menu");
                Console.WriteLine("3.Exit\n");

                InputActorWithSimilarNames();
            }
            else if (actorFullName.Length > 1)
            {
                string actorFirstName = actorFullName[0];
                string actorLastName = actorFullName[1];

                BusinessActors businessActor = new BusinessActors();
                int actorId = businessActor.FindActorId(actorFirstName, actorLastName);

                ShowActorMovies(actorId);
            }
        }

        /// <summary>
        /// Inputs the chosen actor's first and last name from a list with every actor,
        /// that has the same key name.
        /// </summary>
        private void InputActorWithSimilarNames()
        {
            Console.WriteLine("If you want to select any of the other options, select a number from [1-3]");
            Console.WriteLine("Otherwise - Enter the actor's name, ");
            Console.WriteLine("so you can see all the movies that he acted in: ");
            Console.WriteLine(new string('-', 80));
            YourChoice();

            string[] actorName = Console.ReadLine().Split().ToArray();
            string numCheckActor = actorName[0].ToString();
            int numSelection = 0;

            if (int.TryParse(numCheckActor, out numSelection) == true)
            {
                if (int.Parse(numCheckActor) == 1)
                {
                    ShowMovieCategories();
                }
                else if (int.Parse(numCheckActor) == 2)
                {
                    cDisplay.ShowMenuMovieBook();
                }
                else if (int.Parse(numCheckActor) == 3)
                {
                    cDisplay.ExitMenu();
                }
                else
                {
                    Console.Clear();
                    InputActorWithSimilarNames();
                }
            }
            else if (actorName.Length == 1)
            {
                ShowActorNames(actorName[0]);
            }
            else if (actorName.Length > 1)
            {
                string actorFirstName = actorName[0];
                string actorLastName = actorName[1];

                BusinessActors businessActor = new BusinessActors();
                int actorId = businessActor.FindActorId(actorFirstName, actorLastName);

                ShowActorMovies(actorId);
            }
            else
            {
                Console.Clear();
                InputActorWithSimilarNames();
            }
        }

        /// <summary>
        /// Shows the actor's movies and lets you input 
        /// the movie's name through the <see cref="MovieSearch"/> method.
        /// </summary>
        /// <param name="actorId">The chosen actor's id</param>
        private void ShowActorMovies(int actorId)
        {
            Console.Clear();
            Console.WriteLine("Here are some of the movies, where the selected actor has played");

            BusinessMovies businessMovie = new BusinessMovies();

            foreach (Movie movie in businessMovie.GetMoviesByActorId(actorId))
            {
                Console.WriteLine(movie.title);
            }

            Console.WriteLine("1.Go back to categories");
            Console.WriteLine("2.Go back to movie/book menu");
            Console.WriteLine("3.Exit");
            MovieSearch();
        }

        /// <summary>
        /// Gives you the option to go back to a selected movie menu.
        /// </summary>
        public void GoBackMovieMenu()
        {
            Console.WriteLine("1.Go back to categories");
            Console.WriteLine("2.Go back to movie/book selection");
            Console.WriteLine("3.Exit");
            Console.WriteLine(new string('-', 80));
            YourChoice();

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowMovieCategories();
                        break;
                    case 2:
                        cDisplay.ShowMenuMovieBook();
                        break;
                    case 3:
                        cDisplay.ExitMenu();
                        break;
                    default:
                        GoBackErrorMovieMenu();
                        break;
                }
            }
            catch (Exception)
            {

                GoBackErrorMovieMenu();
            }

        }

        /// <summary>
        /// In case that the user has entered an invalid value during the <see cref="GoBackMovieMenu"/> method
        /// it prints out an extra line of text.
        /// </summary>
        public void GoBackErrorMovieMenu()
        {
            Console.Clear();
            Console.WriteLine("You must choose a number between [1-3]");
            Console.WriteLine("1.Go back to categories");
            Console.WriteLine("2.Go back to movie/book selection");
            Console.WriteLine("3.Exit");
            Console.WriteLine(new string('-', 80));
            YourChoice();

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowMovieCategories();
                        break;
                    case 2:
                        cDisplay.ShowMenuMovieBook();
                        break;
                    case 3:
                        cDisplay.ExitMenu();
                        break;
                    default:
                        GoBackErrorMovieMenu();
                        break;
                }
            }
            catch
            {

                GoBackErrorMovieMenu();
            }
        }

        /// <summary>
        /// Prints "Your choice:"
        /// </summary>
        private void YourChoice()
        {
            Console.Write("Your choice: ");
        }
    }
}
