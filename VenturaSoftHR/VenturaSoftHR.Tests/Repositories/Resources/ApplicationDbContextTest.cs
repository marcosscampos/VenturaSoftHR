using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using VenturaSoftHR.Repository.Context;

namespace VenturaSoftHR.Tests.Repositories.Resources;

public class ApplicationDbContextTest : IDisposable
{
    protected readonly ApplicationDbContext _context;
    private readonly SqliteConnection _conn;
    public ApplicationDbContextTest()
    {
        _conn = new SqliteConnection("Filename=:memory:");
        _conn.Open();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(_conn).Options;

        _context = new ApplicationDbContext(options);
        _context.Database.EnsureCreated();

        InitializeRepository.Initialize(_context);
    }
    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
