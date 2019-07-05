using System.Data.Entity;

namespace SerialReader.DAL.Entities
{
    public class SerialReaderContext: DbContext
    {
        public SerialReaderContext() : base("DefaultConnection")
        {
            Database.SetInitializer<SerialReaderContext>(null);
        }

        public DbSet<BalanceWork> BalanceWorks { get; set; }
        public DbSet<BalanceData> BalanceDatas { get; set; }
    }
}