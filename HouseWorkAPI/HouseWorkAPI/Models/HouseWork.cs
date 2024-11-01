using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseWorkAPI.Models
{
    [Table("housework")]
    public class HouseWork
    {
        [Key]
        [Column("id")]
        public Guid? Id { get; set; }
        [Column("ownerId")]
        public int Owner { get; set; }
        [Column("workId")]
        public Guid Work { get; set; }
        public DateTimeOffset date { get; set; }
    }

    public class WorkInfo
    {
        public Member Owner { get; set; } = new Member();
        public Work Work { get; set; } = new Work();
    }

    public class DailyWork
    {
        public List<WorkInfo> Works { get; set; } = new List<WorkInfo>();
        public DateTimeOffset date { get; set; }
    }

    public class WeeklyWork
    {
        public List<WorkInfo> Works { get; set; } = new List<WorkInfo>();
        public DateTimeOffset date { get; set; }
    }

    public class MonthlyWork
    {
        public List<WorkInfo> Works { get; set; } = new List<WorkInfo>();
        public DateTimeOffset date { get; set; }
    }

    public class WorkCard
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public DateTimeOffset date { get; set; }
    }
}
