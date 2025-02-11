using HouseWorkAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseWorkAPI.Models
{
    [Table("work")]
    public class Work
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("frequency")]
        public string Frequency { get; set; } = string.Empty;
        [Column("ownergroup")]
        public int[] OwnerGroup { get; set; } = new int[0];
    }
}
