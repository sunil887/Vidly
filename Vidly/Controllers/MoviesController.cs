using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random  
        private MyDbContext _context;
        public MoviesController()
        {
            _context = new MyDbContext();
        }
        public ActionResult Random ()
        {
            _context.Dispose();
            return View()  ;
        }

        [Route("movies/movieslist")]
        public ActionResult MovieList(){
            var movies = _context.movie.Include(c => c.Genre).ToList();
            return View(movies);
        }
        [Route("movies/details/{id}")]
        public ActionResult details(int id) {
            var movies = _context.movie.Include(c => c.Genre).SingleOrDefault(c => c.Id == id); ;
            return View(movies);
        }
        public ActionResult index(int? pageIndex, String sortBy){ //? is for makeing int nullable ,string is nullable by default
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
                return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex,sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month) {
            return Content(year + "/" + month);
        }
          

    }  
    

}