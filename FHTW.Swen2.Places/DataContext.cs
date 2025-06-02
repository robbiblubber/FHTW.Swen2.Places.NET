using System;
using System.Data;

using FHTW.Swen2.Places.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;



namespace FHTW.Swen2.Places
{
    /// <summary>This class implements the Entity Framework context for the data model.</summary>
    public class DataContext: DbContext
    {
        private static bool _RebuildRequired = true;



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets or sets the places in the application.</summary>
        public virtual DbSet<Place> Places 
        {
            get; set; 
        }


        /// <summary>Rebuilds the FTS index.</summary>
        public void RebuildFtsIndex()
        {
            IDbContextTransaction t = Database.BeginTransaction();

            Database.ExecuteSql($"DELETE FROM PLACES_FTX");
            Database.ExecuteSql($"INSERT INTO PLACES_FTX (PLACE_ID, TEXT) SELECT ID, NAME FROM PLACES");
            Database.ExecuteSql($"INSERT INTO PLACES_FTX (PLACE_ID, TEXT) SELECT ID, DESCRIPTION FROM PLACES");
            Database.ExecuteSql($"INSERT INTO PLACES_FTX (PLACE_ID, TEXT) SELECT PLACE_ID, TEXT FROM STORIES");
            t.Commit();
            _RebuildRequired = false;
        }


        /// <summary>Performs a full text search for a search pattern in places.</summary>
        /// <param name="searchPattern">Search pattern.</param>
        /// <returns>Returns a set of places that match the given pattern.</returns>
        public IEnumerable<Place> SearchPlaces(string searchPattern)
        {
            if(_RebuildRequired) { RebuildFtsIndex(); }

            return Places.FromSql($"SELECT * FROM PLACES P WHERE EXISTS (SELECT 1 FROM PLACES_FTX F WHERE F.PLACE_ID = P.ID AND F.TEXT MATCH {searchPattern})");
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


        /// <summary>Saves changes made to this context in the database.</summary>
        /// <returns>Returns the number of state entries written to the database.</returns>
        public override int SaveChanges()
        {
            _RebuildRequired = true;
            return base.SaveChanges();
        }
    }
}
