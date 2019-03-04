using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Bussiness
{
    public class BusinessPublisher
    {
        private cDbContext cDbContext;
        
        public void addNewPublisher(Publisher publisher)
        {
            using (cDbContext = new cDbContext())
            {
                cDbContext.publishers.Add(publisher);
                cDbContext.SaveChanges();
            }
        }
        
        public Publisher getPublisher(int id)
        {
            using (cDbContext = new cDbContext())
            {
                foreach(Publisher publisher in cDbContext.publishers)
                {
                    if(id == publisher.id)
                    {
                        return publisher;
                    }
                }
            }

            throw new InvalidOperationException("Author with this id does not exist!");
        }
        
        public List<Publisher> getAllPublishers()
        {
            using (cDbContext = new cDbContext())
            {
                return cDbContext.publishers.ToList();
            }
        }
    }
}
