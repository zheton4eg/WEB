using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required]
        public string Title { get; set; }

        public int Credits { get; set; }
    }
}