using HouseWorkAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseWorkAPI.Models
{
    [Table("work")]
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

    public class VueWork : Work
    {
        public string UUId
        {
            get
            {
                return Id?.ToString("D") ?? string.Empty;
            }
            set
            {
                Id = Guid.Parse(value);
            }
        }

        public VueWork() { }
        public VueWork(Work work)
        {
            Id = work.Id;
            Name = work.Name;
            Frequence = work.Frequence;
            OwnerGroup = work.OwnerGroup;
        }
    }
}
