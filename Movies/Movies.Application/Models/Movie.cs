using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace Movies.Application.Models;

public partial class Movie
{
    public Movie(string title, int yearOfRelease, List<string> genres)
    {
        Id = Guid.NewGuid();
        Title = title;
        YearOfRelease = yearOfRelease;
        Genres = genres;
        Slug = GenerateSlug();
    }
    public Movie(Guid id, string title, int yearOfRelease, List<string> genres){
        Id = id;
        Title = title;
        YearOfRelease = yearOfRelease;
        Genres = genres;
        Slug = GenerateSlug();
    }

    [Key]
    public Guid Id { get; init; }
    public string Title { get; set; }
    public int YearOfRelease { get; set; }
    public List<string> Genres { get; set; }
    public string Slug { get; set; }
    private string GenerateSlug() =>
        MyRegex().Replace(Title, string.Empty)
            .ToLower()
            .Replace(" ", "-")
            + $"-{YearOfRelease}";

    [GeneratedRegex("[^0-9A-Za-z _-]", RegexOptions.NonBacktracking, 5)]
    private static partial Regex MyRegex();
}
