using System;
using System.Collections.Generic;
using LoginApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginApi.Data;

public partial class PrototypeLoginContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public PrototypeLoginContext() { }

    public PrototypeLoginContext(DbContextOptions<PrototypeLoginContext> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "Server=127.0.0.1;Port=3306;Database=prototype_login;User=root;Password=root;",
                ServerVersion.Parse("11.3.0-mariadb")
            );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("latin1_swedish_ci").HasCharSet("latin1");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
