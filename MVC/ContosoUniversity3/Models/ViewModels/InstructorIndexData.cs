using ContosoUniversity3.Models;

namespace ContosoUniversity3.Models.ViewModels
{
    public class InstructorIndexData
    {
        public IEnumerable<Instructor>Instructors { get; set; }
        public IEnumerable<Course>Courses { get; set; }
        public IEnumerable<Enrollment>Enrollments { get; set; }
    }
}
