using System;

using FHTW.Swen2.Places.Model;

using Microsoft.EntityFrameworkCore;



namespace FHTW.Swen2.Places
{
    /// <summary>This class implements the Entity Framework context for the data model.</summary>
    public class DataContext: DbContext
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets or sets the places in the application.</summary>
        public DbSet<Place> Places 
        {
            get; set; 
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [override] DbContext                                                                                     //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Configures the context.</summary>
        /// <param name="optionsBuilder">Options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {Configuration.Instance.DatabaseFile}");
            base.OnConfiguring(optionsBuilder);
        }


        /// <summary>Configures the model.</summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>().Property(m => m._Location);
            modelBuilder.Entity<Place>().Navigation(m => m.Stories).AutoInclude();
            modelBuilder.Entity<Story>().Property(m => m.Pictures)
                        .HasConversion(m => string.Join(',', m),
                                       m => m.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            base.OnModelCreating(modelBuilder);
        }
    }
}
