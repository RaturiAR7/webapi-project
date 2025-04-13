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
        [Required]
        [Key][Column("id",TypeName ="INT")]
        public int Id { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="Reg Number should be less than 10 characters")]
        [Column("reg_num", TypeName = "VARCHAR(50)")]
        public string RegNumber { get; set; }= string.Empty;
        [Column("tag_serial", TypeName = "INT")]
        [Required]
        public int FastTagSerial  { get; set; }
        [Column("balance", TypeName = "INT")]
        
        public int Balance { get; set; }= 0;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}