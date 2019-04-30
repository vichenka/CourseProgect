namespace BD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyModels : DbContext
    {
        public MyModels()
            : base("name=MyModels")
        {
        }

        public virtual DbSet<HISTORY> HISTORY { get; set; }
        public virtual DbSet<POINT> POINT { get; set; }
        public virtual DbSet<QUESTION> QUESTION { get; set; }
        public virtual DbSet<RESULT> RESULT { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TEST> TEST { get; set; }
        public virtual DbSet<TYPE> TYPE { get; set; }
        public virtual DbSet<USER> USER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QUESTION>()
                .HasMany(e => e.POINT)
                .WithOptional(e => e.QUESTION)
                .HasForeignKey(e => e.ID_Quest);

            modelBuilder.Entity<TEST>()
                .HasMany(e => e.QUESTION)
                .WithOptional(e => e.TEST)
                .HasForeignKey(e => e.ID_TEST);

            modelBuilder.Entity<TEST>()
                .HasMany(e => e.RESULT)
                .WithOptional(e => e.TEST)
                .HasForeignKey(e => e.ID_Test);

            modelBuilder.Entity<TYPE>()
                .HasMany(e => e.HISTORY)
                .WithOptional(e => e.TYPE)
                .HasForeignKey(e => e.ID_TYPE);

            modelBuilder.Entity<TYPE>()
                .HasMany(e => e.TEST)
                .WithOptional(e => e.TYPE)
                .HasForeignKey(e => e.ID_TYPE);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.HISTORY)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.ID_USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.TEST)
                .WithOptional(e => e.USER)
                .HasForeignKey(e => e.AUTHOR);
        }
    }
}
