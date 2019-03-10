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
        private CatalogDbContext database;

        /// <summary>
        ///     Add new publisher to database
        /// </summary>
        /// <param name="publisher"></param>
        public void AddPublisher(Publisher publisher)
        {
            using (database = new CatalogDbContext())
            {
                database.publishers.Add(publisher);
                database.SaveChanges();
            }
        }

        /// <summary>
        ///     Get publisher from database by id
        /// </summary>
        /// <param name="id"></param>
        public Publisher GetPublisher(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Publisher publisher in database.publishers)
                {
                    if (id == publisher.id)
                    {
                        return publisher;
                    }
                }
            }

            throw new Exception("Publisher with this id does not exist!");
        }

        /// <summary>
        ///     Delete publisher from database by id
        /// </summary>
        /// <param name="id"></param>
        public void DeletePublisher(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Publisher publisher in database.publishers)
                {
                    if (id == publisher.id)
                    {
                        database.publishers.Remove(publisher);
                        database.SaveChanges();
                        return;
                    }
                }
            }

            throw new Exception("Publisher with this id does not exist!");
        }

        /// <summary>
        ///     Get list of publishers from database by id
        /// </summary>
        public List<Publisher> GetAllPublishers()
        {
            using (database = new CatalogDbContext())
            {
                return database.publishers.ToList();
            }
        }
    }
}
