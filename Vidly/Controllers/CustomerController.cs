using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private MyDbContext _context;
        public CustomerController()
        {
            _context = new MyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();  //  
        }
        [Route("customer/index")]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(customers);
        }
        [Route("customer/details/{id}")]
        public ActionResult Details(int id){
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }
        [Route("customer/new")]
        public ActionResult New()
        {
            var membershipType = _context.membershiptype.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipType = membershipType
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer) {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else {
                var customerInDb  = _context.Customers.Single(c=>c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.BirthdayDate = customer.BirthdayDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        [Route("Customer/Edit")]
        public ActionResult Edit(int id) {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.membershiptype.ToList()
            };
    
            return View("CustomerForm", viewModel);
 
        }
    }
}