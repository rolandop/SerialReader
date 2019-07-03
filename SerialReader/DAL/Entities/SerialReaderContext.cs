using System.Data.Entity;

namespace SerialReader.DAL.Entities
{
    public class SerialReaderContext: DbContext
    {
        public SerialReaderContext() : base("DefaultConnection")
        {

        }

        public DbSet<BalanceWork> BalanceWorks { get; set; }
        public DbSet<BalanceData> BalanceDatas { get; set; }
    }
}