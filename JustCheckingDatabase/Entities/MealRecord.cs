using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JustCheckingDatabase.Enums;

namespace JustCheckingDatabase.Entities
{
    [Table("MealRecords")]
    public class MealRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime RecordedAt { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public MacroDistribution MealMacroDistributions { get; set; } = new MacroDistribution();

    }
}
