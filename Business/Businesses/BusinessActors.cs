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

        public void add(Actor actor)
        {
            using (database = new CatalogDbContext())
            {
                database.actors.Add(actor);
            }
        }

        public Actor getActor(int id)
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

        public List<Actor> getAllActors()
        {
            using (database = new CatalogDbContext())
            {
                return database.actors.ToList();
            }
        }
    }
}
