using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity3.Models
{
    public enum Grade {A, B, C, D, F}
    public class Enrollment//зачисление
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }//оценка

        //Navigation property:
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
