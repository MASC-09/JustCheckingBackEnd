using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JustCheckingDatabase.Entities
{
    [Table("UserPlans")]
    public class UserPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [Required]
        public required DateOnly StartDate { get; set; }
        [Required]
        public required DateOnly EndDate { get; set; }
        
        [Required]
        public required string Description { get; set; }

        [Required]
        public int MacroCardId { get; set; }

        [ForeignKey("MacroCardId")]
        public Macrocard Macrocard { get; set; } = null!;

        public bool IsActive { get; set; } = true;


    }
}
