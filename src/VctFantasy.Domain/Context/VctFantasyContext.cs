using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VctFantasy.Domain.Models;

namespace VctFantasy.Domain.Context
{
    public class VctFantasyContext : DbContext
    {
        public VctFantasyContext(DbContextOptions<VctFantasyContext> options) : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ConfigureUserEntity(modelBuilder);

            ConfigureTeamEntity(modelBuilder);

            ConfigureOrganizationEntity(modelBuilder);

            ConfigurePlayerEntity(modelBuilder);

            ConfigureRoleEntity(modelBuilder);

        }

        private void ConfigureUserEntity(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasOne(u => u.Team)
                .WithOne(t => t.User)
                .HasForeignKey<Team>(t => t.Id).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .Property(p => p.Email).HasColumnType("varchar(150)");

            modelBuilder.Entity<User>()
                .Property(p => p.PasswordHash).HasColumnType("varchar(200)");

            modelBuilder.Entity<User>()
                .Property(p => p.PasswordSalt).HasColumnType("varchar(200)");

            modelBuilder.Entity<User>()
                .Property(p => p.Nickname).HasColumnType("varchar(100)");

            modelBuilder.Entity<User>()
                .Property(p => p.RoleID).HasDefaultValue(2);
        }

        private void ConfigureRoleEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .Property(p => p.Name).HasColumnType("varchar(30)");
        }

        private void ConfigureTeamEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .Property(p => p.Name).HasColumnType("varchar(100)");

            modelBuilder.Entity<Team>()
                .Property(p => p.PathLogoTeam).HasColumnType("varchar(300)");

            modelBuilder.Entity<Team>().HasOne(t => t.User)
                .WithOne(u => u.Team)
                .HasForeignKey<Team>(t => t.UserID);

            modelBuilder.Entity<Team>().HasMany(t => t.Players)
                .WithMany(p => p.Teams).UsingEntity<PlayerTeam>();
        }

        private void ConfigureOrganizationEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                 .Property(p => p.Name).HasColumnType("varchar(100)");

            modelBuilder.Entity<Organization>()
                .Property(p => p.Abbreviation).HasColumnType("varchar(10)");

            modelBuilder.Entity<Organization>()
                .Property(p => p.PathLogoOrg).HasColumnType("varchar(300)");
        }

        private void ConfigurePlayerEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .Property(p => p.Nickname).HasColumnType("varchar(50)");

            modelBuilder.Entity<Player>()
                .Property(p => p.Rating).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Player>()
                .Property(p => p.Score).HasColumnType("decimal(18,2)");
        }



    }
}
