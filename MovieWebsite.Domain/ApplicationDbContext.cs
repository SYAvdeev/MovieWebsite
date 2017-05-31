using MovieWebsite.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace MovieWebsite.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public ApplicationDbContext(string connectionString) : base(connectionString) { }

        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasMany(m => m.Actors).WithMany().Map(t => t.MapLeftKey("MovieID").MapRightKey("ActorID").ToTable("MovieActor"));
            modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany().Map(t => t.MapLeftKey("MovieID").MapRightKey("GenreID").ToTable("MovieGenre"));
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            db.Genres.Add(new Genre { Name = "Drama" });
            db.Genres.Add(new Genre { Name = "Crime" });
            db.Genres.Add(new Genre { Name = "Horror" });
            db.Genres.Add(new Genre { Name = "Sci-Fi" });
            db.Genres.Add(new Genre { Name = "Comedy" });

            db.Actors.Add(new Actor { FirstName = "Billy Bob", LastName = "Thornton" });
            db.Actors.Add(new Actor { FirstName = "Tony", LastName = "Cox" });
            db.Actors.Add(new Actor { FirstName = "Tim", LastName = "Robbins" });
            db.Actors.Add(new Actor { FirstName = "Morgan", LastName = "Freeman" });
            db.Actors.Add(new Actor { FirstName = "Sigourney", LastName = "Weaver" });
            
            db.Movies.Add(new Movie
            {
                Title = "The Shawshank Redemption",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Actors = new List<Actor>(db.Actors.Where(a => (a.LastName == "Robbins" || a.LastName == "Freeman"))),
                Genres = new List<Genre>(db.Genres.Where(g => (g.Name == "Drama" || g.Name == "Crime")))
            });
            db.Movies.Add(new Movie
            {
                Title = "Bad Santa",
                Description = "A miserable conman and his partner pose as Santa and his Little Helper to rob department stores on Christmas Eve. But they run into problems when the conman befriends a troubled kid, and the security boss discovers the plot.",
                Actors = new List<Actor>(db.Actors.Where(a => (a.LastName == "Thornton" || a.LastName == "Cox"))),
                Genres = new List<Genre>(db.Genres.Where(g => (g.Name == "Comedy" || g.Name == "Crime")))
            });
            db.Movies.Add(new Movie
            {
                Title = "Alien",
                Description = "After a space merchant vessel perceives an unknown transmission as a distress call, its landing on the source moon finds one of the crew attacked by a mysterious life-form, and they soon realize that its life cycle has merely begun.",
                Actors = new List<Actor>(db.Actors.Where(a => a.LastName == "Weaver")),
                Genres = new List<Genre>(db.Genres.Where(g => (g.Name == "Sci-Fi" || g.Name == "Horror")))
            });
            db.SaveChanges();
        }
    }
}
