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

        public BusinessPublishers()
        {
        }
        
        /// <summary>
        /// Constructor that reupdates the database context.
        /// </summary>
        public BusinessPublishers(CatalogDbContext cDbContext)
        {
         database = cDbContext;   
        }
        
        /// <summary>
        /// Returns the database context.
        /// </summary>
        public CatalogDbContext GetCatalogDbContext()
        {
         return database;   
        }
        
        /// <summary>
        /// Adds a new publisher to the database.
        /// </summary>
        /// <param name="publisher">The publisher</param>
        public void AddPublisher(Publisher publisher)
        {
            using (database = new CatalogDbContext())
            {
                database.Publishers.Add(publisher);
                database.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the publisher from the database by their id.
        /// </summary>
        /// <param name="id">The publisher's id</param>
        public Publisher GetPublisher(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Publisher publisher in database.Publishers)
                {
                    if (id == publisher.Id)
                    {
                        return publisher;
                    }
                }
            }

            throw new Exception("Publisher with this id does not exist!");
        }

        /// <summary>
        /// Deletes the publisher from the database by their id.
        /// </summary>
        /// <param name="id">The publisher's id</param>
        public void DeletePublisher(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Publisher publisher in database.Publishers)
                {
                    if (id == publisher.Id)
                    {
                        database.Publishers.Remove(publisher);
                        database.SaveChanges();
                        return;
                    }
                }
            }

            throw new Exception("Publisher with this id does not exist!");
        }

        /// <summary>
        /// Gets a list of all publishers from the database.
        /// </summary>
        public List<Publisher> GetAllPublishers()
        {
            using (database = new CatalogDbContext())
            {
                return database.Publishers.ToList();
            }
        }
    }
}
