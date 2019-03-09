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

        public void add(Category category)
        {
            using (database = new CatalogDbContext())
            {
                database.categories.Add(category);
            }
        }

        public Category getCategory(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Category category in database.categories)
                {
                    return category;
                }
            }

            throw new Exception("Category with this id does not exist!");
        }

        public List<Category> getAllCategories()
        {
            using (database = new CatalogDbContext())
            {
                return database.categories.ToList();
            }
        }
    }
}
