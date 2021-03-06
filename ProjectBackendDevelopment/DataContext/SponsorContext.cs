using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectBackendDevelopment.Config;
using ProjectBackendDevelopment.Models;

namespace ProjectBackendDevelopment.DataContext
{
    public interface ISponsorContext
    {
        DbSet<Player> Players { get; set; }
        DbSet<Sponsor> Sponsors { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<SponsorPlayer> SponsorPlayers { get; set; }
        DbSet<RugNummer> RugNummers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class SponsorContext : DbContext, ISponsorContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<SponsorPlayer> SponsorPlayers { get; set; }
        public DbSet<RugNummer> RugNummers { get; set; }
        private ConnectionStrings _connectionStrings;
        public SponsorContext(DbContextOptions<SponsorContext> options, IOptions<ConnectionStrings> connectionStrings): base(options)
        {
            _connectionStrings = connectionStrings.Value;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            options.UseSqlServer(_connectionStrings.SQL);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SponsorPlayer>()
                .HasKey(cs => new { cs.SponsorId, cs.PlayerId });
            

            modelBuilder.Entity<Team>().HasData(new Team()
            {
                TeamId = 1,
                Name = "Manchester City",
                Country = "England",
                City = "Manchester"
            });
            modelBuilder.Entity<Team>().HasData(new Team()
            {
                TeamId = 2,
                Name = "Barcelona",
                Country = "Spain",
                City = "Barcelona"
            });
            modelBuilder.Entity<Team>().HasData(new Team()
            {
                TeamId = 3,
                Name = "Bayern",
                Country = "Germany",
                City = "Munchen"
            });
            modelBuilder.Entity<Team>().HasData(new Team()
            {
                TeamId = 4,
                Name = "Mater",
                Country = "Belgium",
                City = "Oudenaarde"
            });
            modelBuilder.Entity<Player>().HasData(new Player()
            {
                PlayerId = 1,
                FirstName = "Ewoud",
                LastName = "De Preester",
                Age = 19,
                RugNummerId = 1
            });
            modelBuilder.Entity<Player>().HasData(new Player()
            {
                PlayerId = 2,
                FirstName = "Robbe",
                LastName = "Raevens",
                Age = 19,
                RugNummerId = 2
            });
            modelBuilder.Entity<Player>().HasData(new Player()
            {
                PlayerId = 3,
                FirstName = "Jarno",
                LastName = "Vanden Haesevelde",
                Age = 13,
                RugNummerId = 3
            });
            modelBuilder.Entity<Player>().HasData(new Player()
            {
                PlayerId = 4,
                FirstName = "Lara",
                LastName = "Desmet",
                Age = 19,
                RugNummerId = 4
            });
            modelBuilder.Entity<RugNummer>().HasData(new RugNummer()
            {
                RugId = 1,
                RugNummerCijfer = 4
            });
            modelBuilder.Entity<RugNummer>().HasData(new RugNummer()
            {
                RugId = 2,
                RugNummerCijfer = 9
            });
            modelBuilder.Entity<RugNummer>().HasData(new RugNummer()
            {
                RugId = 3,
                RugNummerCijfer = 2
            });
            modelBuilder.Entity<RugNummer>().HasData(new RugNummer()
            {
                RugId = 4,
                RugNummerCijfer = 3
            });
            modelBuilder.Entity<RugNummer>().HasData(new RugNummer()
            {
                RugId = 5,
                RugNummerCijfer = 5
            });
            modelBuilder.Entity<RugNummer>().HasData(new RugNummer()
            {
                RugId = 6,
                RugNummerCijfer = 6
            });
        }
    }
}
