using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Businesses
{
    public class BusinessPublishers
    {
        private cDbContext database;

        public void add(Publisher publisher)
        {
            using (database = new cDbContext())
            {
                database.publishers.Add(publisher);
            }
        }

        public Publisher getPublisher(int id)
        {
            using (database = new cDbContext())
            {
                foreach (Publisher publisher in database.publishers)
                {
                    return publisher;
                }
            }

            throw new Exception("Publisher with this id does not exist!");
        }

        public List<Publisher> getAllPublishers()
        {
            using (database = new cDbContext())
            {
                return database.publishers.ToList();
            }
        }
    }
}
