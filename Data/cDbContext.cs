using Data.Model;
using System.Data.Entity;

namespace Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class cDbContext : DbContext
    {
        public cDbContext() : base("name=cDbContext") { }

        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Publisher> publishers { get; set; }
    }
}
