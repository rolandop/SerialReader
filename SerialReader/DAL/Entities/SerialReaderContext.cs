using System.Data.Entity;

namespace SerialReader.DAL.Entities
{
    public class SerialReaderContext: DbContext
    {
        public SerialReaderContext() : base("DefaultConnection")
        {
            Database.SetInitializer<SerialReaderContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("");
        }

        public DbSet<BalanceWork> BalanceWorks { get; set; }
        public DbSet<BalanceData> BalanceDatas { get; set; }
    }
}