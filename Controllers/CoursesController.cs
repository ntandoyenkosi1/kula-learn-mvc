#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KulaMVC.Models;
using KulaMVC.Data;
using Microsoft.AspNetCore.Authorization;
namespace KulaMVC.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        [Authorize(Roles="Admin, Instructor, Student")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Course.ToListAsync());
        }
        [Authorize(Roles="Admin, Instructor, Student")]
        // GET: Courses/Details/5
        public async Task<IActionResult> Details(string id)
        {
            ViewData["collection"]=id;
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Module.Where(m => m.collectionID == id).ToListAsync();
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles="Admin, Instructor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,collectionID,title,shortDescription,imageUrl,createdAt,uploader,published,visibility")] Course course)
        {
            course.ID=Guid.NewGuid().ToString();
            course.collectionID=Guid.NewGuid().ToString();
            course.createdAt=(int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return Redirect($"/Courses/Details/{course.ID}");
                //return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles="Admin, Instructor")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin, Instructor")]
        public async Task<IActionResult> Edit(string id, [Bind("ID,collectionID,title,shortDescription,imageUrl,createdAt,uploader,published,visibility")] Course course)
        {
            if (id != course.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.ID))
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
            return View(course);
        }

        // GET: Courses/Delete/5
        [Authorize(Roles="Admin, Instructor")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(string id)
        {
            return _context.Course.Any(e => e.ID == id);
        }
    }
}
