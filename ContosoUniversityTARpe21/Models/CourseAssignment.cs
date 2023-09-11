namespace ContosoUniversityTARpe21.Models
{
    public class CourseAssignment
    {
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        public Instructor Instructor { get; set; }
        public Instructor Course { get; set; }
    }
}
