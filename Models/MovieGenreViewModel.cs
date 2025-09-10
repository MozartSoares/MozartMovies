using Microsoft.AspNetCore.Mvc.Rendering;

namespace MozartMovies.Models;

public class MovieGenreViewModel
{
    public List<Movie> Movies { get; set; } = new();
    public SelectList? Genres { get; set; }
    public SelectList? Years { get; set; }
    public string? MovieGenre { get; set; }
    public string? SearchString { get; set; }
    public int? MovieYear { get; set; }
}