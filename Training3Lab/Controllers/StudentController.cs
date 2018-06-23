using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Training3Lab.Models;

namespace Training3Lab.Controllers
{
    [Authorize(Roles ="Admin")]
    public class StudentController : Controller
    {
        private readonly Training3LabContext _context;

        public StudentController(Training3LabContext context)
        {
            _context = context;
        }

        public IActionResult StudentCourseInfo()
        {
            //StudentCourse sc = new StudentCourse();
           
            var sc = (from s in _context.Student
                      
                      join c in _context.Course
                        on s.CourseId equals c.Id
                      select new StudentCourse
                      {
                          StudentName = s.Name,
                          CourseName = c.Name,
                          Marks = 40/3
                      }).ToList();  

            return View(sc);
        }

        // GET: Student
        [Authorize]
        public async Task<IActionResult> Index(int? courseId)
        {
            //ViewBag.CourseId = new SelectList(_context.Course.ToList(),"Id","Name");
            if (courseId != null)
            {
                //ViewBag.CourseId = new SelectList(_context.Course.ToList(), "Id", "Name", courseId);
                var ss = _context.Student.Where(s => s.CourseId == courseId).ToList();
                var students = (from s in _context.Student.ToList() where s.CourseId == courseId select s).ToList();
                return View( ss);
                    }
            else
                return View(await _context.Student.Include(s=>s.Course).ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .SingleOrDefaultAsync(m => m.Id == id);
            ViewData["PhotoLocation"] = student.PhotoLocation;
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewBag.CourseId = new SelectList(_context.Course.ToList(), "Id", "Name");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,CourseId")] Student student,IFormFile PhotoLocation)
        {
            if (ModelState.IsValid)
            {
                if(PhotoLocation != null)
                {
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot","UploadFiles",
                        PhotoLocation.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await PhotoLocation.CopyToAsync(stream);
                    }
                    student.PhotoLocation = Path.Combine("\\", "UploadFiles", PhotoLocation.FileName);
                    ViewData["PhotoLocation"] = "/" + Path.GetFileName(PhotoLocation.FileName);
                }
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,CourseId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.SingleOrDefaultAsync(m => m.Id == id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
