using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialReader.DAL.Entities
{
    public class BalanceData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string OriginalData { get; set; }
        public float Weight { get; set; }
        //public string Unit { get; set; }
        public int WorkId { get; set; }
        public virtual BalanceWork Work { get; set; }
    }
}
