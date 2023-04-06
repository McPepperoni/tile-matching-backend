using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using backend.Models;

namespace backend.Contexts;
public class dbContext : DbContext
{
    public DbSet<UserModel> User { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "./Database/Game.db" };
        var connectionString = connectionStringBuilder.ToString();
        var connection = new SqliteConnection(connectionString);

        optionsBuilder.UseSqlite(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<UserModel>().ToTable("User").HasIndex(u => u.name).IsUnique();
    }

}