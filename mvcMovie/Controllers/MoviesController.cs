using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace mvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly moviesContext _context;

        public MoviesController(moviesContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(int categoryId)
        {
            var moviesContext = _context.Movies.Include(m => m.Category).Include(m => m.Rating).Include(m => m.UserLikeMovie).ThenInclude(m => m.User).Select(t => t);
            ViewData["Users"] = new SelectList(_context.Movies, "Id", "Firstname", moviesContext);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", categoryId);

            if (categoryId != 0)
            {
                moviesContext = moviesContext.Where(s => s.Category.Id == categoryId);
            }

            return View(await moviesContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Rating)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movies == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", movies.CategoryId);
            ViewData["RatingId"] = new SelectList(_context.Ratings, "Id", "Name", movies.RatingId);
            return View(movies);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["RatingId"] = new SelectList(_context.Ratings, "Id", "Name");
            return View();
        }

        [TempData]
        public string Message { get; set; }
        [BindProperty]
        public Movies Movie { get; set; }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Release,Picture,Synopsis,CategoryId,RatingId")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movies);
                await _context.SaveChangesAsync();
                Message = $"Movie {Movie.Title} added";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", movies.CategoryId);
            ViewData["RatingId"] = new SelectList(_context.Ratings, "Id", "Name", movies.RatingId);
            return View(movies);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", movies.CategoryId);
            ViewData["RatingId"] = new SelectList(_context.Ratings, "Id", "Name", movies.RatingId);
            return View(movies);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Release,Picture,Synopsis,CategoryId,RatingId")] Movies movies)
        {
            if (id != movies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesExists(movies.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", movies.CategoryId);
            ViewData["RatingId"] = new SelectList(_context.Ratings, "Id", "Name", movies.RatingId);
            return View(movies);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Rating)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movies = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
