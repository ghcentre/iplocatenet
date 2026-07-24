using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IPLocateNet.Inf.Data;

public sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        string basePath = Directory.GetCurrentDirectory();
        string? connectionString = ReadSqliteConnectionString(basePath);
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("No SQLite connection string provided.");
        }

        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.EnableDetailedErrors(true);
        builder.EnableSensitiveDataLogging(true);
        builder.UseSqlite(connectionString);

        var instance = new AppDbContext(builder.Options);
        return instance;
    }

    public static string? ReadSqliteConnectionString(string basePath)
    {
        string filePath = Path.Combine(basePath, "sqlite.options");
        if (!File.Exists(filePath))
        {
            return null;
        }
        return File.ReadAllText(filePath);
    }
}
