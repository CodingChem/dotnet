using Microsoft.EntityFrameworkCore;
using Movies.Application.Models;

namespace Movies.Application.Database;

public class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
    {
    }

}
