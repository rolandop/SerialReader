using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialReader.DAL.Entities
{
    public class BalanceWork
    {
        public BalanceWork()
        {
            Datas = new HashSet<BalanceData>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public BalanceStatus Status { get; set; }

        public virtual ICollection<BalanceData> Datas { get; set; }
    }
}
