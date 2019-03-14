﻿using System;
using CatalogApp.ConsolePresentation.ModelPresentation;

namespace CatalogApp.ConsolePresentation
{
    public class Display
    {
        private static Book cBook = new Book();
        private static Movie cMovie = new Movie();

        public Display() {}

        /// <summary>
        /// Main method of the program.
        /// </summary>
        public void Main()
        {
            InitializeWindow();
            ShowMenuMovieBook();
        }

        /// <summary>
        /// Initialises the window.
        /// </summary>
        private static void InitializeWindow()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();

            Console.Title = "CatalogApp";
        }

        /// <summary>
        /// Shows you the Movie/Book selection menu.
        /// </summary>
        public void ShowMenuMovieBook()
        {
            Console.Clear();
            Console.WriteLine("What're you looking for?");
            Console.WriteLine("1.Movie");
            Console.WriteLine("2.Book");
            Console.WriteLine("3.Exit");
            Console.WriteLine(new string('-', 80));

            InputMenuMovieBook();
        }

        /// <summary>
        /// Chooses whether to show you the Movie or the Book menu.
        /// </summary>
        private void InputMenuMovieBook()
        {
            YourChoice();
            string selectionFromMenuMovieBook = Console.ReadLine();
            Console.WriteLine();

            switch (selectionFromMenuMovieBook.ToLower())
            {
                case ("1"):
                    cMovie.ShowMovieCategories();
                    break;
                case ("2"):
                    cBook.ShowBookCategories();
                    break;
                case ("3"):
                    ExitMenu();
                    break;
                case ("movie"):
                    cMovie.ShowMovieCategories();
                    break;
                case ("book"):
                    cBook.ShowBookCategories();
                    break;
                default:
                    Console.WriteLine(new string('-', 80));
                    ShowMenuMovieBook();
                    break;
            }
        }

        /// <summary>
        /// Gives you a last chance to keep the program open.
        /// </summary>
        public void ExitMenu()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to leave?");
            Console.WriteLine("[Yes/No]");
            Console.WriteLine(new string('-', 80));
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "yes":
                    Console.WriteLine("\nGoodbye! :(\n");
                    break;
                case "no":
                    Console.WriteLine("\n");
                    ShowMenuMovieBook();
                    break;
                case "maybe":
                    Console.WriteLine("\n:(\n");
                    break;
                case "maybe not":
                    Console.WriteLine("\n;)\n");
                    ShowMenuMovieBook();
                    break;
                default:
                    ErrorExitMenu();
                    break;
            }
        }

        /// <summary>
        /// In case that the user entered a different value other than "yes"/"no" (Excluding "maybe" and "maybe not")
        /// during the <see cref="ExitMenu"/> method it prints out an extra line of text.
        /// </summary>
        private void ErrorExitMenu()
        {
            Console.Clear();
            Console.WriteLine("It has to be either 'yes' or 'no'.\n");
            Console.WriteLine("Are you sure you want to leave?");
            Console.WriteLine("[Yes/No]");
            Console.WriteLine(new string('-', 80));
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "yes":
                    Console.WriteLine("\nGoodbye! :(\n");
                    break;
                case "no":
                    Console.WriteLine("\n");
                    ShowMenuMovieBook();
                    break;
                case "maybe":
                    Console.WriteLine("\n:(\n");
                    break;
                case "maybe not":
                    Console.WriteLine("\n;)\n");
                    ShowMenuMovieBook();
                    break;
                default:
                    Console.WriteLine("\nIt has to be either 'yes' or 'no'.\n");
                    ErrorExitMenu();
                    break;
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