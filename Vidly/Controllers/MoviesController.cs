using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

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
    }
}