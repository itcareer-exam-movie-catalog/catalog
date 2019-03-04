using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Bussiness
{
    public class BusinessGenre
    {
        private cDbContext cDbContext;
        
        public void addNewGenre(Genre genre)
        {
            using (cDbContext = new cDbContext())
            {
                cDbContext.genres.Add(genre);
                cDbContext.SaveChanges();
            }
        }
        
        public Genre getGenre(int id)
        {
            using (cDbContext = new cDbContext())
            {
                foreach (Genre genre in cDbContext.genres)
                {
                    if (id == genre.id)
                    {
                        return genre;
                    }
                }
            }

            throw new InvalidOperationException("Genre with this id does not exist!");
        }
        
        public List<Genre> getAllGenres()
        {
            using (cDbContext = new cDbContext())
            {
                return cDbContext.genres.ToList();
            }
        }
    }
}
