using JustCheckingDatabase.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustCheckingDatabase.Entities
{
    [Table("DayRecords")]
    public class DayRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [Required]
        public DateOnly Date { get; set; }

        //[Required]
        //public  Macrocard { get; set; } = new Macrocard
        //{
        //    Type = MacrocardType.Unset // Default value is Unset, must be updated when Macrocard is created.
        //};

        [Required]
        public ICollection<MealRecord> MealsOfTheDay { get; set; } = new List<MealRecord>();

        [Required]
        public bool Success { get; set; }
    }
}
