using Microsoft.EntityFrameworkCore;



namespace FHTW.Swen2.Places.Model
{
    public class DataContext: DbContext
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [override] DbContext                                                                                     //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Configures the database.</summary>
        /// <param name="optionsBuilder">Option builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {App.Config.DatabaseFile}");
        }


        /// <summary>Configures the model.</summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>().Property(m => m._Location);
            modelBuilder.Entity<Story>().Property(m => m.Pictures)
                        .HasConversion(m => string.Join(',', m),
                                       m => m.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Gets the places from the database.</summary>
        public DbSet<Place> Places { get; set; }
    }
}
