using Microsoft.EntityFrameworkCore;
using Movies.Application.Database;
using Movies.Application.Models;

namespace Movies.Application.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly MoviesDbContext _dbContext;
    public MovieRepository(MoviesDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> CreateAsync(Movie movie)
    {
        _dbContext.Movies.Add(movie);
        var added = await _dbContext.SaveChangesAsync();
        return added > 0;
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
        if (movie == null)
        {
            return Task.FromResult(false);
        }
        _dbContext.Movies.Remove(movie);
        var deleted = _dbContext.SaveChanges();
        return Task.FromResult(deleted > 0);
    }

    public Task<IEnumerable<Movie>> GetAllAsync()
    {
        return Task.FromResult(_dbContext.Movies.AsEnumerable());
    }

    public Task<Movie?> GetByIdAsync(Guid id)
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(movie);
    }

    public Task<Movie?> GetBySlugAsync(string slug)
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.Slug == slug);
        return Task.FromResult(movie);
    }

    public Task<bool> UpdateAsync(Movie movie)
    {
        _dbContext.Movies.Update(movie);
        var updated = _dbContext.SaveChanges();
        return Task.FromResult(updated > 0);   
    }
}
