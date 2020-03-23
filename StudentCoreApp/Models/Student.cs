using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(100)")]
        public string StudentName { get; set; }
        [Required]
        public int StudentAge { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string StudentAddress { get; set; }
    }
}
