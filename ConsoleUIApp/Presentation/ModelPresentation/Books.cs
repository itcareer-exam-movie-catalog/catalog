﻿using System;
using System.Collections.Generic;
using System.Linq;
using Business.Businesses;
using Data.Model;

namespace CatalogApp.ConsolePresentation.ModelPresentation
{
    public class Books
    {
        Display cDisplay = new Display();

        public void ShowBookCategories()
        {
            /// <summary>
            /// Shows you the Book menu and its categories.
            /// </summary>
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

            Console.WriteLine($"{categoryNumSelect}.Search for a book");
            categoryNumSelect++;
            Console.WriteLine($"{categoryNumSelect}.Write the publisher's name");
            categoryNumSelect++;
            Console.WriteLine($"{categoryNumSelect}.Write the author's name");
            categoryNumSelect++;
            Console.WriteLine($"{categoryNumSelect}.Go Back");
            categoryNumSelect++;
            Console.WriteLine($"{categoryNumSelect}.Exit");
            Console.WriteLine(new string('-', 80));

            InputBookCategories(categoryNumSelect);
        }

        /// <summary>
        /// Gets the input from the user and chooses whether to:
        /// show you the Book titles, based on the selected category,
        /// let you search for a book,
        /// let you search by a publisher's name,
        /// let you search by an author's name,
        /// show you the Exit menu.
        /// </summary>
        /// <param name="categoryNumSelect">The total amount of options on the Book menu</param>
        private void InputBookCategories(int categoryNumSelect)
        {
            YourChoice();
            try
            {
                int selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case int n when (n >= 1 && n <= categoryNumSelect - 5):
                        ShowBookTitles(selection);
                        break;
                    case int n when (n == categoryNumSelect - 4):
                        OriginalBookSearch();
                        break;
                    case int n when (n == categoryNumSelect - 3):
                        InputPublisherName();
                        break;
                    case int n when (n == categoryNumSelect - 2):
                        InputAuthorName();
                        break;
                    case int n when (n == categoryNumSelect - 1):
                        cDisplay.ShowMenuMovieBook();
                        break;
                    case int n when (n == categoryNumSelect):
                        cDisplay.ExitMenu();
                        break;
                    default:
                        ShowBookCategories();
                        break;
                }
            }
            catch (Exception)
            {

                ShowBookCategories();
            }

        }

        /// <summary>
        /// Searches for a book.
        /// If there is more than 1 book, then the program shows every book, that contains the chosen name.
        /// If the input is an integer, between 1-3, the program gets back to a chosen previous menu.
        /// </summary>
        private void OriginalBookSearch()
        {
            Console.Clear();
            Console.Write("Enter the title of the book you want to search: ");
            string bookTitle = Console.ReadLine();
            int numSelection = 0;
            BusinessBooks businessBook = new BusinessBooks();
            List<Book> booksWithSimilarName = businessBook.GetBooksByTitle(bookTitle);

            try
            {
                if (int.TryParse(bookTitle, out numSelection) == true)
                {
                    if (int.Parse(bookTitle) == 1)
                    {
                        ShowBookCategories();
                    }
                    else if (int.Parse(bookTitle) == 2)
                    {
                        cDisplay.ShowMenuMovieBook();
                    }
                    else if (int.Parse(bookTitle) == 3)
                    {
                        cDisplay.ExitMenu();
                    }
                }
                //checks if the book title is empty
                else if (bookTitle == null || bookTitle == "")
                {
                    Console.WriteLine("You must enter something in order to search for it.\n");
                    GoBackBookMenu();
                }
                else if (booksWithSimilarName.Count == 1)
                {
                    ShowBookInformation(booksWithSimilarName[0]);
                }
                else if (booksWithSimilarName.Count > 1)
                {
                    ShowBooksWithSimilarNames(booksWithSimilarName);
                }
                else
                {
                    Console.WriteLine("There doesn't exist such book in our catalog.\n");
                    GoBackBookMenu();
                }
            }
            catch
            {
                Console.WriteLine("There doesn't exist such book in our catalog.\n");
                GoBackBookMenu();
            }
        }

        /// <summary>
        /// Shows all the book titles, that are in the chosen category.
        /// User has the option to go back to a selected previous menu.
        /// </summary>
        /// <param name="selection">The chosen category's number/id</param>
        private void ShowBookTitles(int selection)
        {
            Console.Clear();
            Console.WriteLine(new string('-', 80));

            BusinessCategories businessCategory = new BusinessCategories();
            string category = businessCategory.GetCategory(selection).name;

            Console.WriteLine("Here are some of the names: ");

            BusinessBooks businessBook = new BusinessBooks();

            List<Book> books = businessBook.GetBooksByCategory(selection);
            foreach (Book book in books)
            {
                Console.WriteLine(book.title);
            }
            Console.WriteLine("1.Go back to categories");
            Console.WriteLine("2.Go back to movie/book menu");
            Console.WriteLine("3.Exit");
            BookSearch();
        }

        /// <summary>
        /// Searches for a book.
        /// Works exactly like the <see cref="OriginalBookSearch"/> method, but prints out extra text.
        /// </summary>
        private void BookSearch()
        {
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("If you want to select any of the other options, select a number from [1-3]");
            Console.Write("Otherwise - Enter the title of the book you want to search: ");
            string bookTitle = Console.ReadLine();
            int numSelection = 0;
            BusinessBooks businessBook = new BusinessBooks();
            List<Book> booksWithSimilarName = businessBook.GetBooksByTitle(bookTitle);

            try
            {
                if (int.TryParse(bookTitle, out numSelection) == true)
                {
                    if (int.Parse(bookTitle) == 1)
                    {
                        ShowBookCategories();
                    }
                    else if (int.Parse(bookTitle) == 2)
                    {
                        cDisplay.ShowMenuMovieBook();
                    }
                    else if (int.Parse(bookTitle) == 3)
                    {
                        cDisplay.ExitMenu();
                    }
                }
                //checks if the book title is empty
                else if (bookTitle == null || bookTitle == "")
                {
                    Console.WriteLine("You must enter something in order to search for it.\n");
                    GoBackBookMenu();
                }
                else if (booksWithSimilarName.Count == 1)
                {
                    ShowBookInformation(booksWithSimilarName[0]);
                }
                else if (booksWithSimilarName.Count > 1)
                {
                    ShowBooksWithSimilarNames(booksWithSimilarName);
                }
                else
                {
                    Console.WriteLine("There doesn't exist such book in our catalog.\n");
                    GoBackBookMenu();
                }
            }
            catch
            {
                Console.WriteLine("There doesn't exist such book in our catalog.\n");
                GoBackBookMenu();
            }
        }

        /// <summary>
        /// Shows information about the chosen book.
        /// </summary>
        /// <param name="book">The selected book</param>
        private void ShowBookInformation(Book book)
        {
            Console.Clear();
            BusinessCategories businessCategory = new BusinessCategories();

            BusinessPublishers publisherBusiness = new BusinessPublishers();
            string publisher = publisherBusiness.GetPublisher(book.publisherId).name;

            List<string> categories = new List<string>();
            List<int> categoryIds = book.categoryIds
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            foreach (int categoryId in categoryIds)
            {
                categories.Add(businessCategory.GetCategory(categoryId).name);
            }

            BusinessAuthors businessAuthor = new BusinessAuthors();
            Author author = businessAuthor.GetAuthor(book.authorId);
            string authorName = author.firstName + " " + author.lastName;

            Console.WriteLine("Here is some information about the movie of your choice:");
            Console.WriteLine($"Title: {book.title}");
            Console.WriteLine($"Year released: {book.publicationYear}");
            Console.WriteLine($"Publisher: {publisher}");
            Console.WriteLine($"Categories: {String.Join(", ", categories)}");
            Console.WriteLine($"Author: {String.Join(", ", authorName)}");

            GoBackBookMenu();
        }

        /// <summary>
        /// Shows every book that contains the same key name.
        /// </summary>
        /// <param name="booksWithSimilarName">All of the books with the same key name</param>
        private void ShowBooksWithSimilarNames(List<Book> booksWithSimilarName)
        {
            Console.Clear();
            Console.WriteLine("Here are some of the book, that have similar names.");
            int currentBookNumber = 1;
            foreach (Book book in booksWithSimilarName)
            {
                Console.WriteLine($"{currentBookNumber}. {book.title}");
                currentBookNumber++;
            }
            Console.WriteLine($"{currentBookNumber}. Go Back");
            currentBookNumber++;
            Console.WriteLine($"{currentBookNumber}. Exit");

            Console.WriteLine("Enter the number for the book that you want to see more information about:");
            Console.Write("--> ");

            try
            {
                int bookNumberChoice = int.Parse(Console.ReadLine());

                if (bookNumberChoice > currentBookNumber || bookNumberChoice <= 0)
                {
                    Console.WriteLine("Your number choice must be bigger than 0 and less than the total amount of movies shown.");
                    ShowBooksWithSimilarNames(booksWithSimilarName);
                }
                else if (bookNumberChoice == currentBookNumber - 1)
                {
                    BookSearch();
                }
                else if (bookNumberChoice == currentBookNumber)
                {
                    cDisplay.ExitMenu();
                }
                else
                {
                    ShowBookInformation(booksWithSimilarName[bookNumberChoice]);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a number");
                ShowBooksWithSimilarNames(booksWithSimilarName);
            }
        }

        /// <summary>
        /// Inputs the publisher's name.
        /// </summary>
        private void InputPublisherName()
        {
            Console.Clear();
            Console.WriteLine("Enter the publisher's name");
            YourChoice();

            string publisherName = Console.ReadLine();

            ShowPublisherBooks(publisherName);
        }

        /// <summary>
        /// Shows all of the movies, which the chosen publisher has published.
        /// </summary>
        /// <param name="publisherName">The selected publisher's name</param>
        private void ShowPublisherBooks(string publisherName)
        {
            Console.Clear();

            BusinessBooks businessBook = new BusinessBooks();
            List<Book> publisherBooks = businessBook.GetBooksByPublisher(publisherName);
            if (publisherBooks.Count == 0)
            {
                Console.WriteLine("The name that you entered is either invalid or the company hasn't published any books\n");
                GoBackBookMenu();
            }
            else
            {
                Console.WriteLine("Here are some of the publisher's books;");

                foreach (Book publisherBook in publisherBooks)
                {
                    Console.WriteLine(publisherBook.title);
                }
                Console.WriteLine("1.Go back to categories");
                Console.WriteLine("2.Go back to movie/book menu");
                Console.WriteLine("3.Exit");

                BookSearch();
            }
        }

        /// <summary>
        /// Inputs the author's name
        /// </summary>
        private void InputAuthorName()
        {
            Console.Clear();
            Console.WriteLine("Enter the author's name");
            Console.WriteLine("In case that you don't know his/her's full name, enter any of their known names");
            Console.WriteLine("If you enter both names, the program will try to find an author with those names");
            Console.WriteLine("If you enter only one name, it will print out every author,");
            Console.WriteLine("that has the entered name");
            YourChoice();

            string authorName = Console.ReadLine();

            ShowAuthorNames(authorName);
        }

        /// <summary>
        /// Chooses whether to show all authors, that share the same chosen name, if you entered only one name,
        /// or to show the chosen author's books, if you entered his first and last name.
        /// </summary>
        /// <param name="authorName">The selected author's name</param>
        private void ShowAuthorNames(string authorName)
        {
            Console.Clear();

            string[] authorFullName = authorName.Split().ToArray();
            //checks if the user has entered only one name
            if (authorFullName.Length == 1)
            {
                List<Author> authorsWithSameName = new List<Author>();
                BusinessAuthors businessAuthor = new BusinessAuthors();

                foreach (Author author in businessAuthor.GetAllAuthors())
                {
                    if (author.firstName.ToLower() == authorName.ToLower() || author.lastName.ToLower() == authorName.ToLower())
                    {
                        authorsWithSameName.Add(author);
                        Console.WriteLine(author.firstName + " " + author.lastName);
                    }
                }
                Console.WriteLine("1.Go back to categories");
                Console.WriteLine("2.Go back to movie/book menu");
                Console.WriteLine("3.Exit\n");

                InputAuthorWithSimilarNames();
            }
            else if (authorFullName.Length > 1)
            {
                string authorFirstName = authorFullName[0];
                string authorLastName = authorFullName[1];

                BusinessAuthors businessAuthor = new BusinessAuthors();
                int authorId = businessAuthor.FindAuthorId(authorFirstName, authorLastName);

                ShowAuthorBooks(authorId);
            }
        }

        /// <summary>
        /// Inputs the chosen author's first and last name from a list with every author,
        /// that has the same key name.
        /// </summary>
        private void InputAuthorWithSimilarNames()
        {
            Console.WriteLine("If you want to select any of the other options, select a number from [1-3]");
            Console.WriteLine("Otherwise - Enter the author's name, ");
            Console.WriteLine("so you can see all the books that he wrote: ");
            Console.WriteLine(new string('-', 80));
            YourChoice();

            string[] authorName = Console.ReadLine().Split().ToArray();
            string numCheckAuthor = authorName[0].ToString();
            int numSelection = 0;

            if (int.TryParse(numCheckAuthor, out numSelection) == true)
            {
                if (int.Parse(numCheckAuthor) == 1)
                {
                    ShowBookCategories();
                }
                else if (int.Parse(numCheckAuthor) == 2)
                {
                    cDisplay.ShowMenuMovieBook();
                }
                else if (int.Parse(numCheckAuthor) == 3)
                {
                    cDisplay.ExitMenu();
                }
                else
                {
                    Console.Clear();
                    InputAuthorWithSimilarNames();
                }
            }
            else if (authorName.Length == 1)
            {
                ShowAuthorNames(authorName[0]);
            }
            else if (authorName.Length > 1)
            {
                string authorFirstName = authorName[0];
                string authorLastName = authorName[1];

                BusinessAuthors businessAuthor = new BusinessAuthors();
                int authorId = businessAuthor.FindAuthorId(authorFirstName, authorLastName);

                ShowAuthorBooks(authorId);
            }
            else
            {
                Console.Clear();
                InputAuthorWithSimilarNames();
            }
        }

        /// <summary>
        /// Shows the author's books and lets you input 
        /// the book's name through the <see cref="BookSearch"/> method.
        /// </summary>
        /// <param name="authorId">The chosen author's id</param>
        private void ShowAuthorBooks(int authorId)
        {
            Console.Clear();
            Console.WriteLine("Here are some of the books, that are written by the selected author");

            BusinessBooks businessBook = new BusinessBooks();

            foreach (Book book in businessBook.GetBooksByAuthorId(authorId))
            {
                Console.WriteLine(book.title);
            }

            Console.WriteLine("1.Go back to categories");
            Console.WriteLine("2.Go back to movie/book menu");
            Console.WriteLine("3.Exit");
            BookSearch();
        }

        /// <summary>
        /// Prints "Your choice:"
        /// </summary>
        private void YourChoice()
        {
            Console.Write("Your choice: ");
        }

        /// <summary>
        /// Gives you the option to go back to a selected book menu.
        /// </summary>
        private void GoBackBookMenu()
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
                        ShowBookCategories();
                        break;
                    case 2:
                        cDisplay.ShowMenuMovieBook();
                        break;
                    case 3:
                        cDisplay.ExitMenu();
                        break;
                    default:
                        GoBackErrorBookMenu();
                        break;
                }
            }
            catch
            {
                GoBackErrorBookMenu();
            }
        }

        /// <summary>
        /// In case that the user has entered an invalid value during the <see cref="GoBackBookMenu"/> method
        /// it prints out an extra line of text.
        /// </summary>
        private void GoBackErrorBookMenu()
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
                        ShowBookCategories();
                        break;
                    case 2:
                        cDisplay.ShowMenuMovieBook();
                        break;
                    case 3:
                        cDisplay.ExitMenu();
                        break;
                    default:
                        GoBackErrorBookMenu();
                        break;
                }
            }
            catch
            {
                GoBackErrorBookMenu();
            }
        }
    }
}
