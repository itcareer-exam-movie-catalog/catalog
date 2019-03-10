using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessActors
    {
        private CatalogDbContext database;

        /// <summary>
        ///     Add new actor to database
        /// </summary>
        /// <param name="actor"></param>
        public void AddActor(Actor actor)
        {
            using (database = new CatalogDbContext())
            {
                database.actors.Add(actor);
                database.SaveChanges();
            }
        }

        /// <summary>
        ///     Get actor from database by id
        /// </summary>
        /// <param name="id"></param>
        public Actor GetActor(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Actor actor in database.actors)
                {
                    if(id == actor.id)
                    {
                        return actor;
                    }
                }
            }

            throw new Exception("Actor with this id does not exist!");
        }

        /// <summary>
        ///     Delete actor from database by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteActor(int id)
        {
            using (database = new CatalogDbContext())
            {
                foreach (Actor actor in database.actors)
                {
                    if (id == actor.id)
                    {
                        database.actors.Remove(actor);
                        database.SaveChanges();
                        return;
                    }
                }
            }

            throw new Exception("Actor with this id does not exist!");
        }

        /// <summary>
        ///     Get list of all authors from database by id
        /// </summary>
        public List<Actor> GetAllActors()
        {
            using (database = new CatalogDbContext())
            {
                return database.actors.ToList();
            }
        }
    }
}
