using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialReader.DAL.Entities
{
    [Table("BALANCEWORKS")]
    public class BalanceWork
    {        
        public BalanceWork()
        {
            Datas = new HashSet<BalanceData>();
        }

       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]

        [Column("WORKSID")]
        public int WorkId { get; set; }

        [Column("CODE")]
        [MaxLength(50)]
        public string Code { get; set; }

        [Column("STARTDATE")]
        public DateTime StartDate { get; set; }

        [Column("ENDDATE")]
        public DateTime? EndDate { get; set; }

        [Column("STATUS")]
        public BalanceStatus Status { get; set; }

        public virtual ICollection<BalanceData> Datas { get; set; }
    }
}
