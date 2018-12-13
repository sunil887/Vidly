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
        public ActionResult Random()
        {
            _context.Dispose();
            return View();
        }

        [Route("movies/movieslist")]
        public ActionResult MovieList() {
            var movies = _context.movie.Include(c => c.Genre).ToList();
            return View(movies);
        }
        [Route("movies/details/{id}")]
        public ActionResult Details(int id) {
            var movies = _context.movie.Include(c => c.Genre).SingleOrDefault(c => c.Id == id); ;
            return View(movies);
        }
        public ActionResult index(int? pageIndex, String sortBy) { //? is for makeing int nullable ,string is nullable by default
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month) {
            return Content(year + "/" + month);
        }
        [Route("Movie/New")]
        public ActionResult New()
        {
            var MovieForm = new MovieFormViewModel
            {
                Genre = _context.Genres.ToList()
            };
            return View("MovieForm", MovieForm);
        }
        [HttpPost]
        [Route("Movie/Save")]
        public ActionResult Save(Movie Movie)
        {
            if (Movie.Id == 0)
            {
                _context.movie.Add(Movie);
            }
            else {
                var movie = _context.movie.Single(c => c.Id == Movie.Id);

                movie.Name = Movie.Name;
                movie.ReleasedDate = Movie.ReleasedDate;
                movie.DateAdded = Movie.DateAdded;
                movie.GenreId = Movie.GenreId;
                _context.SaveChanges();
            }
          
            
            return RedirectToAction("MovieList");
        }
        [Route("Movie/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var movie = _context.movie.Single(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            var MovieForm = new MovieFormViewModel
            {
                Genre = _context.Genres.ToList(),
                Movie = movie 
            };

            return View("MovieForm", MovieForm);
        }

    }  
    

}