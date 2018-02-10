using System.Data.Common;
using System.Data.Entity;
using ToMars.Model.Entities;

namespace ToMars.Model.Context
{
    // ToMars Context
    public class TMContext : DbContext
    {
        public TMContext(DbConnection dbConnection, bool contextOwnsConnection) : base(dbConnection, contextOwnsConnection)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Anketa> Anketa { get; set; }
        public DbSet<AnketaFile> AnketaFile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //System.Data.Entity.Database.SetInitializer<TMContext>(null);
            base.OnModelCreating(modelBuilder);
            // Map entity to table
            modelBuilder.Entity<Anketa>().ToTable("Anketa");
            modelBuilder.Entity<AnketaFile>().ToTable("AnketaFile");
        }
    }
}