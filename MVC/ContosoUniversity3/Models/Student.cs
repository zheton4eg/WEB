using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity3.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }    
        public string FirstName { get; set; }    
        public  DateTime EnrollmentDate { get; set; } //ДатаРегистрации

        //Navigation property:
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
