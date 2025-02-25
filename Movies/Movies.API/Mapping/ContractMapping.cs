using Movies.Application.Models;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.API.Mapping;

public static class ContractMapping
{
    public static Movie MapToMovie(this CreateMovieRequest request)
    {
        return new Movie(
            request.Title,
            request.YearOfRelease,
            [.. request.Genres]
        );
    }
    public static MovieResponse MapToMovieResponse(this Movie movie)
    {
        return new MovieResponse
        {
            Id = movie.Id,
            Title = movie.Title,
            YearOfRelease = movie.YearOfRelease,
            Slug = movie.Slug,
            Genres = movie.Genres
        };
    }
    public static MoviesResponse MapToMovieResponse(this IEnumerable<Movie> movies)
    {
        return new MoviesResponse
        {
            Items = movies.Select(MapToMovieResponse)
        };
    }
    public static Movie MapToMovie(this UpdateMovieRequest request, Guid id)
    {
        return new Movie(
            id,
            request.Title,
            request.YearOfRelease,
            [.. request.Genres]
        );
    }
}
