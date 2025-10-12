using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity3.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; } //Заголовок
        public int Credits { get; set; } //Баллы
                                        
        //Navigation property:
        public ICollection<Enrollment> Enrollments { get; set; }//зачисление
    }
}
