using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class cDbContext : DbContext
    {
        public cDbContext() : base("name=cDbContext") { }

        public DbSet<Author> authors { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Director> directors { get; set; }
        public DbSet<Actor> actors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Movie> movies { get; set; }
    }
}
