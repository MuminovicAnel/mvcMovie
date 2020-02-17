using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcMovie.Areas.Identity.Data;
using mvcMovie.Models;
using System.Linq;
using System.Threading.Tasks;

namespace mvcMovie.Controllers
{
    public class FilmUsersController : Controller
    {
        private readonly mvcMovieContext _context;

        public FilmUsersController(mvcMovieContext context)
        {
            _context = context;
        }

        // GET: FilmUsers
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.FilmUser.Include(f => f.Film).Include(f => f.Status).Include(f => f.User);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: FilmUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmUser = await _context.FilmUser
                .Include(f => f.Film)
                .Include(f => f.Status)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Film_id == id);
            if (filmUser == null)
            {
                return NotFound();
            }

            return View(filmUser);
        }

        // GET: FilmUsers/Create
        public IActionResult Create()
        {
            ViewData["Film_id"] = new SelectList(_context.Films, "ID", "ID");
            ViewData["Status_id"] = new SelectList(_context.Statuses, "ID", "ID");
            ViewData["User_id"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: FilmUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rating,User_id,Film_id,Status_id,ID")] FilmUser filmUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Film_id"] = new SelectList(_context.Films, "ID", "ID", filmUser.Film_id);
            ViewData["Status_id"] = new SelectList(_context.Statuses, "ID", "ID", filmUser.Status_id);
            ViewData["User_id"] = new SelectList(_context.Users, "ID", "ID", filmUser.User_id);
            return View(filmUser);
        }

        // GET: FilmUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmUser = await _context.FilmUser.FindAsync(id);
            if (filmUser == null)
            {
                return NotFound();
            }
            ViewData["Film_id"] = new SelectList(_context.Films, "ID", "ID", filmUser.Film_id);
            ViewData["Status_id"] = new SelectList(_context.Statuses, "ID", "ID", filmUser.Status_id);
            ViewData["User_id"] = new SelectList(_context.Users, "ID", "ID", filmUser.User_id);
            return View(filmUser);
        }

        // POST: FilmUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rating,User_id,Film_id,Status_id,ID")] FilmUser filmUser)
        {
            if (id != filmUser.Film_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmUserExists(filmUser.Film_id))
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
            ViewData["Film_id"] = new SelectList(_context.Films, "ID", "ID", filmUser.Film_id);
            ViewData["Status_id"] = new SelectList(_context.Statuses, "ID", "ID", filmUser.Status_id);
            ViewData["User_id"] = new SelectList(_context.Users, "ID", "ID", filmUser.User_id);
            return View(filmUser);
        }

        // GET: FilmUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmUser = await _context.FilmUser
                .Include(f => f.Film)
                .Include(f => f.Status)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Film_id == id);
            if (filmUser == null)
            {
                return NotFound();
            }

            return View(filmUser);
        }

        // POST: FilmUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmUser = await _context.FilmUser.FindAsync(id);
            _context.FilmUser.Remove(filmUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmUserExists(int id)
        {
            return _context.FilmUser.Any(e => e.Film_id == id);
        }
    }
}
