using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContosoUniversity3.Models;

namespace ContosoUniversity3.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        [StringLength(24)]
        [RegularExpression(@"^[A-Z]+[a-z]*$")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Имя")]
        [StringLength(24)]
        [RegularExpression(@"^[A-Z]+[a-z]*$")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Работает с")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Препод")]
        public string FullName { get => $"{LastName} {FirstName}"; }

        //Navigation properties:
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}