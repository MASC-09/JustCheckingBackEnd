using JustCheckingDatabase.Entities;
using JustCheckingDatabase.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JustCheckingDatabase.Entities
{
    [Table("MacroDistributions")]
    public class MacroDistribution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        //public int MacrocardId { get; set; }

        //[ForeignKey("MacrocardId")]
        //public Macrocard Macrocard { get; set; } = null!;

        [Required]
        public MealType MealType { get; set; } // Distribution for a specific MealType

        [Required]
        public float Dairy { get; set; }

        [Required]
        public float Vegetables { get; set; }

        [Required]
        public float Fruits { get; set; }
        [Required]
        public float Carbohydrates { get; set; }
        [Required]
        public float Protein { get; set; }
        [Required]
        public float Fats { get; set; }
        [Required]
        public int Calories { get; set; }
    }
}