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
        ///     Add new categoty to database
        /// </summary>
        /// <param name="category"></param>
        public void AddCategoty(Category category)
        {
            using (database = new CatalogDbContext())
            {
                database.categories.Add(category);
                database.SaveChanges();
            }
        }

        /// <summary>
        ///     Get category from database by id
        /// </summary>
        /// <param name="id"></param>
        public Category GetCategory(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Category category in database.categories)
                {
                    if (id == category.id)
                    {
                        return category;
                    }
                }
            }

            throw new Exception("Category with this id does not exist!");
        }

        /// <summary>
        ///     Delete category from database by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCateory(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Category category in database.categories)
                {
                    if (id == category.id)
                    {
                        database.categories.Remove(category);
                        database.SaveChanges();
                        return;
                    }
                }
            }

            throw new Exception("Category with this id does not exist!");
        }

        /// <summary>
        ///     Get list of categories from database by id
        /// </summary>
        public List<Category> getAllCategories()
        {
            using (database = new CatalogDbContext())
            {
                return database.categories.ToList();
            }
        }
    }
}
