using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialReader.DAL.Entities
{
    [Table("BALANCEDATAS")]
    public class BalanceData
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Column("DATASID")]
        public int DataId { get; set; }

        [Column("CREATEDDATE")]
        public DateTime CreatedDate { get; set; }

        [Column("UPDATEDATE")]
        public DateTime? UpdateDate { get; set; }

        [Column("ORIGINALDATA")]
        [MaxLength(50)]
        public string OriginalData { get; set; }

        [Column("WEIGHT")]
        public float Weight { get; set; }

        [ForeignKey("Work")]
        [Column("WORKID")]        
        public int WorkId { get; set; }

        [Column("REMARKS")]
        [MaxLength(150)]
        public string Remarks { get; set; }

        public virtual BalanceWork Work { get; set; }
    }
}
