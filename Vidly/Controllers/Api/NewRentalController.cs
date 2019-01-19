using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalsDto)
        {
            
            MyDbContext _Context = new MyDbContext();
            Customer customerInDb = _Context.Customers.Single(c => c.Id == newRentalsDto.CustomerId);
            if (customerInDb == null)
                return BadRequest("Customer id is not Valid.");

            if (newRentalsDto.MovieId.Count == 0)
                return BadRequest("no Movie Ids have been given");

            var  MoviesInDb = _Context.movie.Where(m => newRentalsDto.MovieId.Contains(m.Id)).ToList();

            if (MoviesInDb.Count != newRentalsDto.MovieId.Count)
                return BadRequest("one or movie is not invalid");

            foreach(Movie movie in MoviesInDb) {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;
                
                Rental newRental = new Rental {
                                    Customer = customerInDb,
                                    Movie = movie,
                                    DateRented = DateTime.Now   
                                };
                _Context.Rental.Add(newRental);
            }
            _Context.SaveChanges();
            throw new NotImplementedException();


        }
    }
}
