using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity3.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; } //Заголовок
        public int Credits { get; set; } //Баллы

        public int DepartmentID { get; set; }

        //Navigation property:
        public Department Department { get; set; }  
        public ICollection<Enrollment> Enrollments { get; set; }//зачисление
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
