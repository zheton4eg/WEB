
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity3.Models
{
    public enum Grade {A, B, C, D, F}
    public class Enrollment//зачисление
    {
        
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "Оценка не выставлена")]
        public Grade? Grade { get; set; }//оценка

        //Navigation property:
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
