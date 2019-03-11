using Data.Model;
using System.Data.Entity;

namespace Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext() : base("name=CatalogDbContext") {}

        public DbSet<Author> authors { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Director> directors { get; set; }
        public DbSet<Actor> actors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Movie> movies { get; set; }
    }
}
