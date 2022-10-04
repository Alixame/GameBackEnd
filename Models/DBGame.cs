using Microsoft.EntityFrameworkCore;

namespace GameBackend.Models;

public class DBGame : DbContext
{
    public DBGame(DbContextOptions<DBGame> options): base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
}