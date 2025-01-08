using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JustCheckingDatabase.Enums;

namespace JustCheckingDatabase.Entities
{
    [Table("Measurements")]
    public class Measurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required int UserId{ get; set; }

        [Required]
        public required DateTime Date { get; set; }

        [Required]
        public required MeasurementType Type { get; set; }

        [Required]
        public required float Weight { get; set; }

        [Required]
        public required float MuscleMass{ get; set; }

        [Required]
        public required float BodyFat { get; set; }

        [Required]
        public required float BMI { get; set; }

    }
}
