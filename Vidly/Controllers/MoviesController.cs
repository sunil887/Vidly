﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random  
        public ActionResult Random ()
        {
            var movie = new Movie() { Name = "shrek!" };
            var customers = new List<Customer>
            {   
                new Customer { Name = "Customer1"},
                new Customer { Name = "Customer2"}
            };

            var viewModel = new RandomMovieViewModel {
                 Movie = movie,
                 Customers = customers
            };
            return View(viewModel)  ;
        }

        [Route("movies/movieslist")]
        public ActionResult MovieList(){
            var movies = new List<Movie>
            {
                new Movie{ Name = "MI1"  },
                new Movie{ Name  = "MI2" }
            };

            return View(movies);
        }
        public ActionResult Edit(int id) {
            return Content("id = " + id);
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