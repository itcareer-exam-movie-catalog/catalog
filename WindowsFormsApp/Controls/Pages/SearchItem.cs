using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Business.Businesses;
using Data.Model;
using WindowsFormsApp.Controls.Display;

namespace WindowsFormsApp.Controls.Pages
{
    public partial class SearchItem : UserControl
    {
        private BusinessBooks businessBooks;
        private BusinessAuthors businessAuthors;
        private BusinessCategories businessCategories;
        private BusinessPublishers businessPublishers;
        private BusinessDirectors businessDirectors;
        private BusinessMovies businessMovies;
        private BusinessActors businessActors;

        private float minPrice;
        private float maxPrice;

        public SearchItem()
        {
            InitializeComponent();
        }
        
        private bool CheckFilters(float price, int[] categories, string[] texts)
        {
            if (useOtherFillters.Checked)
            {
                //Check for price
                if (price < minPrice || price > maxPrice)
                {
                    return false;
                }

                //Check for categories
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
            }

            //Check for title and texts
            if (texts != null)
            {
                bool containText = false;
                foreach (string text in texts)
                {
                    if (text.ToLower().Contains(searchBox.Text.ToLower()))
                    {
                        containText = true;
                        break;
                    }
                }
                if (!containText)
                {
                    return false;
                }
            }

            return true;
        }

        private void UpdateItems()
        {
            displayItems.Clear();

            if (showBooks.Checked)
            {
                List<Book> books = businessBooks.GetAllBooks();

                if (orderByAsc.Checked)
                {
                    books.Sort((i, j) => string.Compare(i.Title, j.Title));
                }
                else if(orderByDesc.Checked)
                {
                    books.Sort((i, j) => string.Compare(j.Title, i.Title));
                }

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

                    if (CheckFilters((float)book.Price, categories.Select(i => i.Id).ToArray(), texts.ToArray()))
                    {
                        displayItems.AddItem(book, author, publisher, categories);
                    }
                }
            }

            if (showMovies.Checked)
            {
                List<Movie> movies = businessMovies.GetAllMovies();

                if (orderByAsc.Checked)
                {
                    movies.Sort((i, j) => string.Compare(i.Title, j.Title));
                }
                else if (orderByDesc.Checked)
                {
                    movies.Sort((i, j) => string.Compare(j.Title, i.Title));
                }

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

                    if (CheckFilters((float)movie.Price, categories.Select(i => i.Id).ToArray(), texts.ToArray()))
                    {
                        displayItems.AddItem(movie, director, actors, categories);
                    }
                }
            }
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
        
        private void clearFilters_Click(object sender, EventArgs e) => resetFilters();
        private void applyFilters_Click(object sender, EventArgs e) => UpdateItems();

        private void searchInEverything_CheckedChanged(object sender, EventArgs e) => SearchAutoComplete();
        private void searchInTitles_CheckedChanged(object sender, EventArgs e) => SearchAutoComplete();

        private void SearchItem_Resize(object sender, EventArgs e) => OnResize();

        private void selectAllCategories_CheckedChanged(object sender, EventArgs e)
        {
            for (int a = 0; a < selectCategories.Items.Count; a++)
            {
                selectCategories.SetItemChecked(a, selectAllCategories.Checked);
            }
        }

        private void useOtherFillters_CheckedChanged(object sender, EventArgs e)
        {
            priceGroup.Enabled = useOtherFillters.Checked;
            typeGroup.Enabled = useOtherFillters.Checked;
            categoryGroup.Enabled = useOtherFillters.Checked;
        }

        private void resetFilters()
        {
            clearFilters.Enabled = false;

            searchBox.Text = "";
            searchInEverything.Checked = true;
            searchInTitles.Checked = false;
            useOtherFillters.Checked = true;
            enterMinPrice.Text = GetMinPrice().ToString();
            enterMaxPrice.Text = GetMaxPrice().ToString();

            orderByAsc.Checked = true;
            orderByDesc.Checked = false;

            SearchAutoComplete();

            clearFilters.Enabled = true;
        }
        
        private void OnResize()
        {
            displayItems.Height = this.Height - displayItems.Location.Y * 2;
            displayItems.Width = this.Width - displayItems.Location.X;

            applyFilters.Top = displayItems.Height - applyFilters.Height;
            clearFilters.Top = displayItems.Height - clearFilters.Height;
            filters.Height = applyFilters.Top - filters.Location.Y * 2;
        }

        public void SetBusinesses(BusinessActors actors, BusinessAuthors authors, BusinessBooks books, BusinessCategories categories, BusinessDirectors directors, BusinessMovies movies, BusinessPublishers publishers)
        {
            this.businessActors = actors;
            this.businessAuthors = authors;
            this.businessBooks = books;
            this.businessCategories = categories;
            this.businessDirectors = directors;
            this.businessMovies = movies;
            this.businessPublishers = publishers;
        }

        public void Init()
        {
            foreach (string name in businessCategories.GetAllCategories().Select(i => i.Name).ToArray())
            {
                selectCategories.Items.Add(name);
            }

            for (int a = 0; a < selectCategories.Items.Count; a++)
            {
                selectCategories.SetItemChecked(a, true);
            }

            resetFilters();
            UpdateItems();
            OnResize();
        }

        public int DisplayItemsX { get => displayItems.Location.X; }
    }
}
