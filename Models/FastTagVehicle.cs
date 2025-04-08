using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    [Table("vehicle")]
    public class FastTagVehicle
    {
        [Key][Column("id",TypeName ="INT")]
        public int Id { get; set; }
        [Column("reg_num", TypeName = "VARCHAR(50)")]
        public string RegNumber { get; set; }= string.Empty;
        [Column("tag_serial", TypeName = "INT")]
        public int FastTagSerial  { get; set; }
        [Column("balance", TypeName = "INT")]
        public int Balance { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}