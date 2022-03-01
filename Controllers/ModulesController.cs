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

namespace KulaMVC.Controllers
{
    public class ModulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modules
        public async Task<IActionResult> Index()
        {
            return View(await _context.Module.ToListAsync());
        }
        public async Task<IActionResult> Preview(string collectionID, string moduleID){
            var modules=await _context.Module.Where(r=>r.collectionID==collectionID).ToListAsync();
            if(moduleID==null){
                try{
                    var modelItem =await _context.Module.Where(r=>r.collectionID==collectionID).FirstOrDefaultAsync();
                    ViewData["title"]=modelItem.title;
                    ViewData["shortDescription"]=modelItem.shortDescription;
                    ViewData["longDescription"]=modelItem.longDescription;
                    ViewData["video"]=modelItem.video;
                }
                catch{
                    //
                }
                return View(modules);
            }
            var model =await _context.Module.Where(r=>r.ID==moduleID).FirstOrDefaultAsync();
            ViewData["title"]=model.title;
            ViewData["shortDescription"]=model.shortDescription;
            ViewData["longDescription"]=model.longDescription;
            ViewData["video"]=model.video;
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
        public IActionResult Create(string collectionID)
        {
            ViewData["collectionID"]=collectionID;
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,collectionID,language,title,shortDescription,longDescription,video,uploader,iat")] Module @module)
        {
            @module.ID=Guid.NewGuid().ToString();
            @module.iat=(int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            if (ModelState.IsValid)
            {
                _context.Add(@module);
                await _context.SaveChangesAsync();
                return Redirect($"/Modules/Preview?collectionID={@module.collectionID}");
                //return RedirectToAction(nameof(Index));
            }
            return View(@module);
        }

        // GET: Modules/Edit/5
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,collectionID,language,title,shortDescription,longDescription,video,uploader,iat")] Module @module)
        {
            if (id != @module.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                 @module.iat=(int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
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
                return Redirect($"/Courses/Details/{@module.collectionID}");
                //return View(@module);
            }
            return View(@module);
        }

        // GET: Modules/Delete/5
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
