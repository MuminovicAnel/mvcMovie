using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcMovie;

namespace mvcMovie.Controllers
{
    public class UserLikeMoviesController : Controller
    {
        private readonly moviesContext _context;

        public UserLikeMoviesController(moviesContext context)
        {
            _context = context;
        }

        // GET: UserLikeMovies
        public async Task<IActionResult> Index()
        {
            var moviesContext = _context.UserLikeMovie.Include(u => u.Movie).Include(u => u.User);
            return View(await moviesContext.ToListAsync());
        }

        // GET: UserLikeMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLikeMovie = await _context.UserLikeMovie
                .Include(u => u.Movie)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLikeMovie == null)
            {
                return NotFound();
            }

            return View(userLikeMovie);
        }

        // GET: UserLikeMovies/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Firstname");
            return View();
        }

        // POST: UserLikeMovies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,MovieId,Comment,Stars,HasSeen")] UserLikeMovie userLikeMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userLikeMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", userLikeMovie.MovieId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Firstname", userLikeMovie.UserId);
            return View(userLikeMovie);
        }

        // GET: UserLikeMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLikeMovie = await _context.UserLikeMovie.FindAsync(id);
            if (userLikeMovie == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", userLikeMovie.MovieId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Firstname", userLikeMovie.UserId);
            return View(userLikeMovie);
        }

        // POST: UserLikeMovies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,MovieId,Comment,Stars,HasSeen")] UserLikeMovie userLikeMovie)
        {
            if (id != userLikeMovie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLikeMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLikeMovieExists(userLikeMovie.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", userLikeMovie.MovieId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Firstname", userLikeMovie.UserId);
            return View(userLikeMovie);
        }

        // GET: UserLikeMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLikeMovie = await _context.UserLikeMovie
                .Include(u => u.Movie)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLikeMovie == null)
            {
                return NotFound();
            }

            return View(userLikeMovie);
        }

        // POST: UserLikeMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userLikeMovie = await _context.UserLikeMovie.FindAsync(id);
            _context.UserLikeMovie.Remove(userLikeMovie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLikeMovieExists(int id)
        {
            return _context.UserLikeMovie.Any(e => e.Id == id);
        }
    }
}
