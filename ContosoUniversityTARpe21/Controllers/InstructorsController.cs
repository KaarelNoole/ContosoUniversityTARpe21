using Microsoft.AspNetCore.Mvc;
using ContosoUniversityTARpe21.Models;
using ContosoUniversityTARpe21.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityTARpe21.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;

        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var vm = new InstructorIndexData();
            vm.Instructors = await _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                .ThenInclude(i => i.Course)
                .ThenInclude(i => i.Enrollments)
                .ThenInclude(i => i.Student)
                .Include(i => i.CourseAssignments)
                .ThenInclude(i => i.Course)
                .ThenInclude(i => i.Department)
                .AsNoTracking()
                .OrderBy(i => i.LastName)
                .ToListAsync();
            if (id != null)
            {
                ViewData["InstructorID"] = id.Value;
                Instructor instructor = vm.Instructors
                    .Where(i => i.ID == id.Value).Single();
                vm.Courses = instructor.CourseAssignments
                    .Select(i => i.Course);
            }
            if (courseId != null)
            {
                ViewData["CourseID"] = courseId.Value;
                vm.Enrollments = vm.Courses
                    .Where(x => x.CourseID == courseId)
                    .Single()
                    .Enrollments;
            }
            return View(vm);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(m => m.ID == id);

            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HiredDate,FirstMidName,LastName")] Instructor instructor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instructor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ) 
            {
                ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the proble, persist" + "see your system administrator");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instructorToUpdate = await _context.Instructors.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Instructor>(instructorToUpdate,"",s=>s.FirstMidName,
                s=>s.LastName, s=>s.HireDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {

                    ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persist" + "see your system administrator");
                }
            }
            return View(instructorToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangerError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = _context.Instructors
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ID == id);

            if (instructor == null)
            {
                return NotFound();
            }

            if (saveChangerError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Deletion has failed, Please try again, and if problem persists " +
                    "see your system administrator.";
            }
            return View(instructor);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Instructors.Remove(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {

                return RedirectToAction(nameof(Delete), new
                {
                    id = id,
                    saveChangesError = true
                });
                        
            }
        }

    }
}
