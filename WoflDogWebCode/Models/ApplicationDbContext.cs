using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WoflDogWebCode.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<ResourceClass> ResourceClasses { get; set; }

    public virtual DbSet<ResourceNetworkInfo> ResourceNetworkInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlite(connectionString);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ResourceClass>(entity =>
        {
            entity.ToTable("Resource_Class");
        });

        modelBuilder.Entity<ResourceNetworkInfo>(entity =>
        {
            entity.ToTable("Resource_Network_Info");

            entity.HasOne(d => d.Class).WithMany(p => p.ResourceNetworkInfos).HasForeignKey(d => d.ClassId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
