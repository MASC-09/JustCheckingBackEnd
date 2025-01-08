using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustCheckingDatabase.Entities
{
    [Table("User_History")]
    public class UserHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required User User{ get; set; }

        [Required]
        public required DateTime DateTime { get; set; }
        [Required]
        public required bool Success {  get; set; }

    }
}
