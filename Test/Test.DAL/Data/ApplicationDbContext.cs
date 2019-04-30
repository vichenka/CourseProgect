using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test.Models;
using Microsoft.AspNetCore.Identity;

namespace Test.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //     Database.EnsureCreated();
           // Database.Migrate();
        }
        
        public virtual DbSet<HISTORY> HISTORY { get; set; }
        public virtual DbSet<POINT> POINT { get; set; }
        public virtual DbSet<QUESTION> QUESTION { get; set; }
        public virtual DbSet<RESULT> RESULT { get; set; }
        public virtual DbSet<TEST> TEST { get; set; }
        public virtual DbSet<TYPE> TYPE { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<QUESTION>()
        //        .HasMany(e => e.POINT)
        //        .WithOne(e => e.QUESTION)
        //        .HasForeignKey(e => e.ID_Quest);

        //    modelBuilder.Entity<TEST>()
        //        .HasMany(e => e.QUESTION)
        //        .WithOne(e => e.TEST)
        //        .HasForeignKey(e => e.ID_TEST);

        //    modelBuilder.Entity<TEST>()
        //        .HasMany(e => e.RESULT)
        //        .WithOne(e => e.TEST)
        //        .HasForeignKey(e => e.ID_Test);

        //    modelBuilder.Entity<TYPE>()
        //        .HasMany(e => e.HISTORY)
        //        .WithOne(e => e.TYPE)
        //        .HasForeignKey(e => e.ID_TYPE);

        //    modelBuilder.Entity<TYPE>()
        //        .HasMany(e => e.TEST)
        //        .WithOne(e => e.TYPE)
        //        .HasForeignKey(e => e.ID_TYPE);
           
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasMany(e => e.TEST)
            //    .WithOne(e => e.USER)
            //    .HasForeignKey(e => e.AUTHOR);
        
    }

}

