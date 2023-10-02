using ContosoUniversityTARpe21.Models;

namespace ContosoUniversityTARpe21.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student() {FirstMidName="Kaarel-Martin",LastName="Noole",EnrollmentDate=DateTime.Now},
                new Student() {FirstMidName="Marcus",LastName="Toman",EnrollmentDate=DateTime.Parse("2021-09-01")},
                new Student() {FirstMidName="Rasmus",LastName="Jalakas",EnrollmentDate=DateTime.Now},
                new Student() {FirstMidName="Karl Umberto",LastName="Kats",EnrollmentDate=DateTime.Now},
                new Student() {FirstMidName="Risto",LastName="Koort",EnrollmentDate=DateTime.Now},
            };
            context.Students.AddRange(students);
            //foreach (Student s in students)
            //{ 
            //    context.Students.Add(s);
            //}
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor {FirstMidName = "Jõulu", LastName = 
                    "Vana", HireDate = DateTime.Parse("1995-03-11")},
                new Instructor {FirstMidName = "Rootsi", LastName =
                    "Kuningas", HireDate = DateTime.Parse("1992-05-12")},
                new Instructor {FirstMidName = "Balta", LastName =
                    "Pars", HireDate = DateTime.Parse("1995-03-01")},
                new Instructor {FirstMidName = "Kinder", LastName =
                    "Suprise", HireDate = DateTime.Parse("1995-06-08")},

            };
            context.Instructors.AddRange(instructors);
            //foreach (Instructor i in instructors)
            //{
            //    context.Instructors.Add(i);
            //}
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department
                {
                    Name = "Infotechnology",
                    Budget = 0,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName
                    == "Parm").ID 
                },
                new Department
                {
                    Name = "Joomarlus",
                    Budget = 0,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName
                    == "Parm").ID
                },
                new Department
                {
                    Name = "Internet Trolling & Tiktok 101",
                    Budget = 0,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName
                    == "Kuningas").ID
                },
                new Department
                {
                    Name = "Kokandus",
                    Budget = 0,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName
                    == "Suprise").ID
                },

            };
            context.Departments.AddRange(departments);
            //foreach (Department d in departments)
            //{
            //    context.Departments.Add(d);
            //}
            context.SaveChanges();

            var course = new Course[]
            {
                new Course() {CourseID=1050,Title="Programmeerimine",Credits=160, DepartmentID = departments.Single(s => s.Name == "Infotechnology").DepartmentID},
                new Course() {CourseID=6900,Title="Keemia",Credits=160, DepartmentID = departments.Single(s => s.Name == "Kokandus").DepartmentID},
                new Course() {CourseID=1420,Title="Matemaatika",Credits=160, DepartmentID = departments.Single(s => s.Name == "Joomarlus").DepartmentID},
                new Course() {CourseID=6666,Title="Testimine",Credits=160, DepartmentID = departments.Single(s => s.Name == "Infotechnology").DepartmentID},
                new Course() {CourseID=1234,Title="Riigikaitse",Credits=160, DepartmentID = departments.Single(s => s.Name == "Internet trolling && Tiktik 101").DepartmentID},
            };
            //context.Courses.AddRange(course);

            foreach (Course c in course)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment()
                {
                    InstructorID = instructors.Single(i => i.LastName == "Vana").ID ,
                    Location = "A236",
                },

                new OfficeAssignment()
                {
                    InstructorID = instructors.Single(i => i.LastName == "Parm").ID ,
                    Location = "Balta turu värav",
                },
                new OfficeAssignment()
                {
                    InstructorID = instructors.Single(i => i.LastName == "Suprise").ID,
                    Location = "Kaubik kooli ees",
                },
            };
            context.OfficeAssignments.AddRange(officeAssignments);
            //foreach (OfficeAssignment o in officeAssignments)
            //{
            //    context.OfficeAssignments.Add(o);
            //}
            context.SaveChanges();

            var courseInstructor = new CourseAssignment[]
            {
                new CourseAssignment 
                {
                    CourseID = course.Single(c => c.Title == "Keemia").CourseID,
                    InstructorID=instructors.Single(i => i.LastName == "Parm").ID
                },
                new CourseAssignment
                {
                    CourseID = course.Single(c => c.Title == "Riigikaitse").CourseID,
                    InstructorID=instructors.Single(i => i.LastName == "Parm").ID
                },
                new CourseAssignment
                {
                    CourseID = course.Single(c => c.Title == "Matemaatika").CourseID,
                    InstructorID=instructors.Single(i => i.LastName == "Parm").ID
                },
                new CourseAssignment
                {
                    CourseID = course.Single(c => c.Title == "Keemia").CourseID,
                    InstructorID=instructors.Single(i => i.LastName == "Vana").ID
                },
                new CourseAssignment
                {
                    CourseID = course.Single(c => c.Title == "Programmeerimine").CourseID,
                    InstructorID=instructors.Single(i => i.LastName == "Vana").ID
                },
                new CourseAssignment
                {
                    CourseID = course.Single(c => c.Title == "Keemia").CourseID,
                    InstructorID=instructors.Single(i => i.LastName == "Vana").ID
                },
                new CourseAssignment
                {
                    CourseID = course.Single(c => c.Title == "Matemaatika").CourseID,
                    InstructorID=instructors.Single(i => i.LastName == "Suprise").ID
                },
                new CourseAssignment
                {
                    CourseID = course.Single(c => c.Title == "Riigikaitse").CourseID,
                    InstructorID=instructors.Single(i => i.LastName == "Suprise").ID
                },
            };
            context.CourseAssignments.AddRange(courseInstructor);
            //foreach (CourseAssignment ci in courseInstructor)
            //{
            //    context.CourseAssignments.Add(ci);
            //}
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=6900,Grade=Grade.B},
                new Enrollment{StudentID=1,CourseID=1420,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=6666,Grade=Grade.A},
                new Enrollment{StudentID=2,CourseID=6666,Grade=Grade.C},
                new Enrollment{StudentID=2,CourseID=6666,Grade=Grade.A},
                new Enrollment{StudentID=2,CourseID=6666,Grade=Grade.B},
                new Enrollment{StudentID=3,CourseID=6666,Grade=Grade.B},
                new Enrollment{StudentID=3,CourseID=6666,Grade=Grade.A},
                new Enrollment{StudentID=3,CourseID=6666,Grade=Grade.F},
                new Enrollment{StudentID=4,CourseID=6666,Grade=Grade.A},
                new Enrollment{StudentID=4,CourseID=6666,Grade=Grade.C},
                new Enrollment{StudentID=5,CourseID=6666,Grade=Grade.D},
                new Enrollment{StudentID=5,CourseID=6666,Grade=Grade.B},
                new Enrollment{StudentID=6,CourseID=6666,Grade=Grade.A},
                new Enrollment{StudentID=7,CourseID=6666,Grade=Grade.B},
                new Enrollment{StudentID=7,CourseID=6666,Grade=Grade.C},
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDatabase = context.Enrollments.Where(
                    s => s.StudentID == e.StudentID &&
                    s.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDatabase != null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();

        }
    }
}
