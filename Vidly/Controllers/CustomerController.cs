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
            var viewModel = new NewCustomerviewModel
            {
                MembershipType = membershipType
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer) {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}