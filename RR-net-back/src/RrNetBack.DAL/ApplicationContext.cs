using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RrNetBack.Domain.Models.Users;

namespace RrNetBack.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            ILogger<ApplicationDbContext> logger)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, new []
            {
                DbLoggerCategory.Migrations.Name,
                DbLoggerCategory.Database.Transaction.Name,
                DbLoggerCategory.Database.Command.Name,
                DbLoggerCategory.Update.Name,
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(item =>
            {
                item.HasKey(c => c.Id);
                item.Property(c => c.RegistrationDate);
                item.Property(c => c.LastActivityDate);
            });
        }
    }
}