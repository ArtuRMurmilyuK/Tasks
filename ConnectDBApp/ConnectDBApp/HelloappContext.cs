using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConnectDBApp;

//Example: Scaffold-DbContext "Data Source=D:\\helloapp.db" Microsoft.EntityFrameworkCore.Sqlite

public partial class HelloappContext : DbContext
{
    public HelloappContext()
    {
    }

    public HelloappContext(DbContextOptions<HelloappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=D:\\GitHub\\helloapp.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
