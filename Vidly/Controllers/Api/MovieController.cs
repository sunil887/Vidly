using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;


namespace Vidly.Controllers.Api
{
    public class MovieController : ApiController
    {
        private MyDbContext _context;
        public MovieController()
        {
             _context = new MyDbContext();
        }
        [System.Web.Http.HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            var movies = _context.movie.ToList();
            return movies;
        }

    }
}
