using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        // GET: Movies
        public MoviesController()
        {
                _context = new ApplicationDbContext();
        }

        public ActionResult Index()   
        {
           
            var movies = _context.Movies.Include(g => g.Genre).ToList();
            

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.Include(g => g.Genre).ToList().Where(m=>m.Id == id).FirstOrDefault();
            return View(movie);
        }


        public ActionResult New()
        {
            IEnumerable<Genre> genres = _context.Genres.ToList();

            var movieViewModel = new MovieViewModel
            {
                Genres = genres
            };

            return View(movieViewModel);

        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }

            return View();
        }


        public ActionResult Edit(int id)
        {
            var movieViewModel = new MovieViewModel
            {
                Genres = _context.Genres.ToList(),
                Movie = _context.Movies.SingleOrDefault(m => m.Id == id)
            };

            return View(movieViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (movie == null)
            {

                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                var movieInDb = _context.Movies.Find(movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.StockCount = movie.StockCount;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;

                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View();

        }

        public ActionResult Delete(int id)
        {
            var moviedb = _context.Movies.Find(id);
            var genres = _context.Genres.ToList();

            var movieVM = new MovieViewModel
            {
                Movie = moviedb,
                Genres = genres
            };

            return View(movieVM);
        }


        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }

            var moviedb = _context.Movies.Find(id);
            if (moviedb != null)
            {
                _context.Movies.Remove(moviedb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }


            var movieVM = new MovieViewModel
            {
                Movie = _context.Movies.Find(id),
                Genres = _context.Genres.ToList()
            };
            return View(movieVM);

        }
    }
}