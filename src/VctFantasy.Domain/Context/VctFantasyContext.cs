using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.Context
{
    public class VctFantasyContext: DbContext
    {
        public VctFantasyContext(DbContextOptions<VctFantasyContext> options) : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity(j => j.ToTable("UserRoles"));

            modelBuilder.Entity<User>().HasOne(u => u.Team)
                .WithOne(t => t.User)
                .HasForeignKey<Team>(t => t.Id).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>()
                .Property(p => p.Name).HasColumnType("nvarchar(100)");

        }

    }
}
