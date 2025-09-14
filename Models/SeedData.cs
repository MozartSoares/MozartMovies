using Microsoft.EntityFrameworkCore;
using MozartMovies.Models;
using MvcMovie.Data;

namespace MozartMovies.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>());

        // Ensure database created
        context.Database.EnsureCreated();
        context.Database.ExecuteSql($"UPDATE Movie SET Rating='NR' WHERE Rating IS NULL");

        // If any movies, DB has been seeded
        if (context.Movie.Any())
        {
            return;
        }

        context.Movie.AddRange(
            new Movie
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-02-12"),
                Genre = "Romantic Comedy",
                Price = 7.99M,
                Rating = "PG"
            },
            new Movie
            {
                Title = "Ghostbusters",
                ReleaseDate = DateTime.Parse("1984-03-13"),
                Genre = "Comedy",
                Price = 8.99M,
                Rating = "PG"
            },
            new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-02-23"),
                Genre = "Comedy",
                Price = 9.99M,
                Rating = "PG"
            },
            new Movie
            {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-04-15"),
                Genre = "Western",
                Price = 3.99M,
                Rating = "G"
            },
            new Movie
            {
                Title = "The Matrix",
                ReleaseDate = DateTime.Parse("1999-03-31"),
                Genre = "Science Fiction",
                Price = 10.99M,
                Rating = "R"
            },
            new Movie
            {
                Title = "Inception",
                ReleaseDate = DateTime.Parse("2010-07-16"),
                Genre = "Action",
                Price = 12.99M,
                Rating = "PG-13"
            },
            new Movie
            {
                Title = "The Godfather",
                ReleaseDate = DateTime.Parse("1972-03-24"),
                Genre = "Crime",
                Price = 11.99M,
                Rating = "R"
            }
        );

        context.SaveChanges();
    }
}