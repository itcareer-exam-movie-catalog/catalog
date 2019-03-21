using Business.Businesses;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public static BusinessBooks businessBooks = new BusinessBooks();
        public static BusinessAuthors businessAuthors = new BusinessAuthors();
        public static BusinessCategories businessCategories = new BusinessCategories();
        public static BusinessPublishers businessPublishers = new BusinessPublishers();
        public static BusinessDirectors businessDirectors = new BusinessDirectors();
        public static BusinessMovies businessMovies = new BusinessMovies();
        public static BusinessActors businessActors = new BusinessActors();

        private float minPrice;
        private float maxPrice;

        public Form1()
        {
            InitializeComponent();

            enterMinPrice.Text = GetMinPrice().ToString();
            enterMaxPrice.Text = GetMaxPrice().ToString();

            foreach (string name in businessCategories.GetAllCategories().Select(i => i.Name).ToArray())
            {
                selectCategories.Items.Add(name);
            }

            for (int a = 0; a < selectCategories.Items.Count; a++)
            {
                selectCategories.SetItemChecked(a, true);
            }

            SearchAutoComplete();

            UpdateItems();
            
            applyFilters.Top = filters.Location.Y + filters.Height + 4;
        }

        private void UpdateItems()
        {
            showItems.Clear();

            if (showBooks.Checked)
            {
                List<Book> books = businessBooks.GetAllBooks();
                books.Sort((i, j) => string.Compare(i.Title, j.Title));

                foreach (Book book in books)
                {
                    Author author = businessAuthors.GetAuthor(book.AuthorId);
                    Publisher publisher = businessPublishers.GetPublisher(book.PublisherId);
                    Category[] categories = book.CategoryIds.Split(',').Select(i => businessCategories.GetCategory(int.Parse(i))).ToArray();

                    List<string> texts = new List<string>();

                    if (searchInEverything.Checked)
                    {
                        texts.AddRange(categories.Select(i => i.Name).ToList());
                        texts.Add(author.FirstName + " " + author.LastName);
                        texts.Add(publisher.Name);
                    }

                    texts.Add(book.Title);

                    if (!CheckFilters((float)book.Price, categories.Select(i => i.Id).ToArray(), texts.ToArray()))
                    {
                        continue;
                    }

                    showItems.AddItem(book, author, publisher, categories);
                }
            }

            if (showMovies.Checked)
            {
                List<Movie> movies = businessMovies.GetAllMovies();
                movies.Sort((i, j) => string.Compare(i.Title, j.Title));

                foreach (Movie movie in movies)
                {
                    Director director = businessDirectors.GetDirector(movie.DirectorId);
                    Actor[] actors = movie.ActorIds.Split(',').Select(i => businessActors.GetActor(int.Parse(i))).ToArray();
                    Category[] categories = movie.CategoryIds.Split(',').Select(i => businessCategories.GetCategory(int.Parse(i))).ToArray();

                    List<string> texts = new List<string>();

                    if (searchInEverything.Checked)
                    {
                        texts.AddRange(categories.Select(i => i.Name).ToList());
                        texts.AddRange(actors.Select(i => i.FirstName + " " + i.LastName).ToArray());
                        texts.Add(director.FirstName + " " + director.LastName);
                    }
                    texts.Add(movie.Title);

                    if (!CheckFilters((float)movie.Price, categories.Select(i => i.Id).ToArray(), texts.ToArray()))
                    {
                        continue;
                    }

                    showItems.AddItem(movie, director, actors, categories);
                }
            }
        }

        private bool CheckFilters(float price, int[] categories, string[] texts)
        {
            if (price < minPrice || price > maxPrice)
            {
                return false;
            }

            bool contain = false;
            foreach (object checkedId in selectCategories.CheckedIndices)
            {
                if (categories.Contains(int.Parse(checkedId.ToString()) + 1))
                {
                    contain = true;
                    break;
                }
            }
            if (!contain)
            {
                return false;
            }

            if (texts != null)
            {
                bool containText = false;
                foreach (string text in texts)
                {
                    if (text.ToLower().Contains(searchBox.Text.ToLower()))
                    {
                        containText = true;
                        //break;
                    }
                }
                if (!containText)
                {
                    return false;
                }
            }

            return true;
        }

        private float GetMaxPrice()
        {
            float price = 0.0f;

            foreach (Book book in businessBooks.GetAllBooks())
            {
                price = Math.Max(price, (float)book.Price);
            }

            foreach (Movie movie in businessMovies.GetAllMovies())
            {
                price = Math.Max(price, (float)movie.Price);
            }

            return price;
        }
        private float GetMinPrice()
        {
            float price = GetMaxPrice();

            foreach (Book book in businessBooks.GetAllBooks())
            {
                price = Math.Min(price, (float)book.Price);
            }

            foreach (Movie movie in businessMovies.GetAllMovies())
            {
                price = Math.Min(price, (float)movie.Price);
            }

            return price;
        }
        private void enterMinPrice_TextChanged(object sender, EventArgs e)
        {
            if ((!float.TryParse(enterMinPrice.Text, out minPrice) || minPrice < GetMinPrice()) && enterMinPrice.Text.Length > 0)
            {
                enterMinPrice.Text = GetMinPrice().ToString();
            }
        } //Need update
        private void enterMaxPrice_TextChanged(object sender, EventArgs e)
        {
            if ((!float.TryParse(enterMaxPrice.Text, out maxPrice) || maxPrice > GetMaxPrice()) && enterMaxPrice.Text.Length > 0)
            {
                enterMaxPrice.Text = GetMaxPrice().ToString();
            }
        } //Need update
        private void selectAllCategories_CheckedChanged(object sender, EventArgs e)
        {
            for (int a = 0; a < selectCategories.Items.Count; a++)
            {
                selectCategories.SetItemChecked(a, selectAllCategories.Checked);
            }
        }
        private void applyFilters_Click(object sender, EventArgs e) => UpdateItems();
        private void searchInEverything_CheckedChanged(object sender, EventArgs e) => SearchAutoComplete();
        private void searchInTitles_CheckedChanged(object sender, EventArgs e) => SearchAutoComplete();
        private void Form1_Resize(object sender, EventArgs e) => showPanel.Size = new Size(this.Width - showPanel.Location.X * 2 - 16, this.Height - showPanel.Location.Y * 2 - 38);
        private void showPanel_Resize(object sender, EventArgs e)
        {
            filters.Height = showPanel.Height - filters.Location.Y * 2 - 46;
            applyFilters.Top = filters.Location.Y + filters.Height + 4;
            showItems.Height = filters.Height + 44;
        } //Update height resize - showItems
        private void SearchAutoComplete()
        {
            searchBox.AutoCompleteCustomSource.Clear();

            foreach (string title in businessBooks.GetAllBooks().Select(i => i.Title).ToArray())
            {
                searchBox.AutoCompleteCustomSource.Add(title);
            }

            foreach (string title in businessMovies.GetAllMovies().Select(i => i.Title).ToArray())
            {
                searchBox.AutoCompleteCustomSource.Add(title);
            }

            if (searchInEverything.Checked)
            {
                foreach (string name in businessDirectors.GetAllDirectors().Select(i => (i.FirstName + " " + i.LastName)).ToArray())
                {
                    searchBox.AutoCompleteCustomSource.Add(name);
                }

                foreach (string name in businessAuthors.GetAllAuthors().Select(i => (i.FirstName + " " + i.LastName)).ToArray())
                {
                    searchBox.AutoCompleteCustomSource.Add(name);
                }

                foreach (string name in businessActors.GetAllActors().Select(i => (i.FirstName + " " + i.LastName)).ToArray())
                {
                    searchBox.AutoCompleteCustomSource.Add(name);
                }

                foreach (string name in businessPublishers.GetAllPublishers().Select(i => i.Name).ToArray())
                {
                    searchBox.AutoCompleteCustomSource.Add(name);
                }
            }
        }

        //Add
        private void OrderBy()
        {

        }
    }
}
