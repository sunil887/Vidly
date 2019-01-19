using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using AutoMapper;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private MyDbContext _context;
        public CustomersController()
        {
            _context = new MyDbContext();
        }
        public IEnumerable<CustomerDto> GetCustomers() {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }
        public IHttpActionResult GetCustomer(int id) {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customerInDb));
        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) {
            if (!ModelState.IsValid)
                BadRequest();

            Customer customer = Mapper.Map<CustomerDto,Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created( new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
        }

        private IHttpActionResult Created(Uri uri)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto CustomerDto) {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.Single(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(CustomerDto, customerInDb);
            _context.SaveChanges();
         
        }
        public void DeleteCustomer(int id) {
            var customerInDb = _context.Customers.Single(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
        
    }
}
