namespace MovieWebsite.Domain.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieWebsite.Domain.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieWebsite.Domain.ApplicationDbContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            db.Genres.AddOrUpdate(p => p.Name,
                new Genre { Name = "Drama" },
                new Genre { Name = "Crime" },
                new Genre { Name = "Horror" },
                new Genre { Name = "Sci-Fi" },
                new Genre { Name = "Comedy" });

            db.SaveChanges();

            db.Actors.AddOrUpdate(p => p.LastName,
                new Actor { FirstName = "Billy Bob", LastName = "Thornton" },
                new Actor { FirstName = "Tony", LastName = "Cox" },
                new Actor { FirstName = "Tim", LastName = "Robbins" },
                new Actor { FirstName = "Morgan", LastName = "Freeman" },
                new Actor { FirstName = "Sigourney", LastName = "Weaver" });

            db.SaveChanges();

            db.Movies.AddOrUpdate(p => p.Title,
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Actors = new List<Actor>(db.Actors.Where(a => (a.LastName == "Robbins" || a.LastName == "Freeman"))),
                    Genres = new List<Genre>(db.Genres.Where(g => (g.Name == "Drama" || g.Name == "Crime")))
                },
                new Movie
                {
                    Title = "Bad Santa",
                    Description = "A miserable conman and his partner pose as Santa and his Little Helper to rob department stores on Christmas Eve. But they run into problems when the conman befriends a troubled kid, and the security boss discovers the plot.",
                    Actors = new List<Actor>(db.Actors.Where(a => (a.LastName == "Thornton" || a.LastName == "Cox"))),
                    Genres = new List<Genre>(db.Genres.Where(g => (g.Name == "Comedy" || g.Name == "Crime")))
                },
                new Movie
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
