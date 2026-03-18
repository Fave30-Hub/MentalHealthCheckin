using MentalHealthCheckin.Domain.Entities;
using MentalHealthCheckin.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MentalHealthCheckin.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<CheckIn> CheckIns => Set<CheckIn>();
        public DbSet<User> Users => Set<User>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CheckIn>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Mood).IsRequired();

                entity.Property(x => x.Score)
                  .HasConversion(
                      v => v.Score,
                      v => new MoodScore(v)
                  )
                  .IsRequired();

                entity.Property(x => x.Comment)
                    .HasConversion(
                        v => v != null ? v.Value : null,
                        v => v != null ? new Comment(v) : null
                    );
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.FullName).IsRequired();
                entity.Property(x => x.Email).IsRequired();
            });
        }
    }
}
