using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JustCheckingDatabase.Enums;

namespace JustCheckingDatabase.Entities
{
    [Table("Macrocards")]
    public class Macrocard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required MacrocardType Type { get; set; }

        // Collection for distributing macros across MealTypes
        public ICollection<MacroDistribution> MacroDistributions { get; set; } = new List<MacroDistribution>();
    }
}