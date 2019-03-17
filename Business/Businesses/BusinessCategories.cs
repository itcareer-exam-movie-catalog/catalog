using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessCategories
    {
        private CatalogDbContext database;

        /// <summary>
        /// Adds a new categoty to the database.
        /// </summary>
        /// <param name="category">The category</param>
        public void AddCategoty(Category category)
        {
            using (database = new CatalogDbContext())
            {
                database.Categories.Add(category);
                database.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the category from the database by its id.
        /// </summary>
        /// <param name="id">The category's id</param>
        public Category GetCategory(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Category category in database.Categories)
                {
                    if (id == category.Id)
                    {
                        return category;
                    }
                }
            }

            throw new Exception("Category with this id does not exist!");
        }

        /// <summary>
        /// Deletes a category from the database by its id.
        /// </summary>
        /// <param name="id">The category's id</param>
        public void DeleteCateory(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Category category in database.Categories)
                {
                    if (id == category.Id)
                    {
                        database.Categories.Remove(category);
                        database.SaveChanges();
                        return;
                    }
                }
            }

            throw new Exception("Category with this id does not exist!");
        }

        /// <summary>
        /// Gets a list of all categories from the database.
        /// </summary>
        public List<Category> GetAllCategories()
        {
            using (database = new CatalogDbContext())
            {
                return database.Categories.ToList();
            }
        }
    }
}
