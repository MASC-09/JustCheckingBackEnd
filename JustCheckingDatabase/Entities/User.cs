using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JustCheckingDatabase.Enums;

namespace JustCheckingDatabase.Entities
{ 
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }

        [Required]
        public required string Name { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; }
        [Required]
        [MinLength(6)]
        public required string Password { get; set; }

        [Required]
        public required float Height { get; set; }

        [Required]
        public required DateTime DateBirth{ get; set; }

        [Required]
        public required GenderType UserGender { get; set; }

        [Required]
        public required string HealthCondition { get; set; }


    }
}
