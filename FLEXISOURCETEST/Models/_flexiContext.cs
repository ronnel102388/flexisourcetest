using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;

namespace FLEXISOURCETEST.Models
{
    public class _flexiContext: DbContext
    {
        public _flexiContext(DbContextOptions<_flexiContext> options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RunningActivity> RunningActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasKey(u => u.Id);
            modelBuilder.Entity<RunningActivity>().HasKey(u => u.Id);
        }
    }
}
