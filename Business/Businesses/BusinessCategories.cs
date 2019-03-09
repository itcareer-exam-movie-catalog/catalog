using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessCategories
    {
        private cDbContext database;

        public void add(Category category)
        {
            using (database = new cDbContext())
            {
                database.categories.Add(category);
            }
        }

        public Category getCategory(int id)
        {
            using (database = new cDbContext())
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
            using (database = new cDbContext())
            {
                return database.categories.ToList();
            }
        }
    }
}
