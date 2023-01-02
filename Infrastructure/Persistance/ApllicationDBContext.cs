using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace TodoApi.Infrastructure.Persistence;

public class AplicationDBContext : DbContext
{
    public DbSet<Bote> Botes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
    }
}