using Data.Model;
using System.Data.Entity;

namespace Data
{
    public class cDbContext : DbContext
    {
        public cDbContext() : base("server=localhost;port=3306;database=catalog;user=root;password=12357895") { }

        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Publisher> publishers { get; set; }
    }
}
