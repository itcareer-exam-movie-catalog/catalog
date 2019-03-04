using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Bussiness
{
    public class BusinessCategory
    {
        private cDbContext cDbContext;
        
        public void addNewGenre(Category category)
        {
            using (cDbContext = new cDbContext())
            {
                cDbContext.categories.Add(category);
                cDbContext.SaveChanges();
            }
        }
        
        public Category getCategory(int id)
        {
            using (cDbContext = new cDbContext())
            {
                foreach (Category category in cDbContext.categories)
                {
                    if (id == category.id)
                    {
                        return category;
                    }
                }
            }

            throw new InvalidOperationException("Category with this id does not exist!");
        }
        
        public List<Category> getAllGenres()
        {
            using (cDbContext = new cDbContext())
            {
                return cDbContext.categories.ToList();
            }
        }
    }
}
