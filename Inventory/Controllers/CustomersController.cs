using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;


namespace Inventory.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.customers.Include("MemberShipType").ToList();
           
           return View(customers);
        }

        //[Route("Customers/Detail/{id}")]
        public ActionResult Detail(int id)
        {
            var customer = _context.customers.Include("MemberShipType").Single(c => c.Id == id);
            return View("CustomerDetail", customer);
        }
    }
}