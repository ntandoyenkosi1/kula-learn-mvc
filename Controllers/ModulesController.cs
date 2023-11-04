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
    public class ModulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modules
        [Authorize(Roles="Admin, Instructor, Student")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Module.ToListAsync());
        }
        [Authorize(Roles="Admin, Instructor, Student")]
        public async Task<IActionResult> Preview(string CollectionID, string moduleID){
            var modules=await _context.Module.Where(r=>r.CollectionID==CollectionID).ToListAsync();
            if(moduleID==null){
                try{
                    var modelItem =await _context.Module.Where(r=>r.CollectionID==CollectionID).FirstOrDefaultAsync();
                    ViewData["Title"]=modelItem.Title;
                    ViewData["ShortDescription"]=modelItem.ShortDescription;
                    ViewData["LongDescription"]=modelItem.LongDescription;
                    ViewData["Video"]=modelItem.Video;
                }
                catch{
                    //
                }
                return View(modules);
            }
            var model =await _context.Module.Where(r=>r.ID==moduleID).FirstOrDefaultAsync();
            ViewData["Title"]=model.Title;
            ViewData["ShortDescription"]=model.ShortDescription;
            ViewData["LongDescription"]=model.LongDescription;
            ViewData["Video"]=model.Video;
            return View(modules);
        }
        // GET: Modules/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.Module
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // GET: Modules/Create
        [Authorize(Roles="Admin, Instructor")]
        public IActionResult Create(string CollectionID)
        {
            ViewData["CollectionID"]=CollectionID;
            return View();
        }

        // POST: Modules/Create
        [Authorize(Roles="Admin, Instructor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CollectionID,language,Title,ShortDescription,LongDescription,Video,Uploader,Iat")] Module @module)
        {
            @module.ID=Guid.NewGuid().ToString();
            @module.Iat=(int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            if (ModelState.IsValid)
            {
                _context.Add(@module);
                await _context.SaveChangesAsync();
                return Redirect($"/Modules/Preview?CollectionID={@module.CollectionID}");
                //return RedirectToAction(nameof(Index));
            }
            return View(@module);
        }

        // GET: Modules/Edit/5
        [Authorize(Roles="Admin, Instructor")]
        public async Task<IActionResult> Edit(string id, string moduleID)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @module = await _context.Module.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }
            return View(@module);
        }

        // POST: Modules/Edit/5
        [Authorize(Roles="Admin, Instructor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,CollectionID,language,Title,ShortDescription,LongDescription,Video,Uploader,Iat")] Module @module)
        {
            if (id != @module.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                 @module.Iat=(int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                try
                {
                    _context.Update(@module);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(@module.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect($"/Courses/Details/{@module.CollectionID}");
                //return View(@module);
            }
            return View(@module);
        }

        // GET: Modules/Delete/5
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.Module
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // POST: Modules/Delete/5
        [Authorize(Roles="Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var @module = await _context.Module.FindAsync(id);
            _context.Module.Remove(@module);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ModuleExists(string id)
        {
            return _context.Module.Any(e => e.ID == id);
        }
    }
}
