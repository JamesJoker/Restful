using HouseWorkAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseWorkAPI.Models
{
    [Table("Work")]
    public class Work
    {
        [Column("id")]
        public Guid? Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("frequence")]
        public string Frequence { get; set; } = string.Empty;
        [Column("ownergroup")]
        public int[] OwnerGroup { get; set; } = new int[0];
    }
}
