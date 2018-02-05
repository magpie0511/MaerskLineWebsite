using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLineWebsite.Models;

namespace MaerskLineWebsite.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        //Create new Customer
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer model) //it will straight create and save into the database. Then, a partial view will shown stating the schedules are created successfully.
        {
            _context.Customers.Add(model);
            _context.SaveChanges();

            return View("New");
        }

        public ActionResult Details(int cid)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CId == cid);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult Edit(int cid)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.CId == cid);

            if (customer == null)
            {
                return HttpNotFound();
            }

            Customer customerModelSchedule = new Customer();
            customerModelSchedule.CId = customer.CId;
            customerModelSchedule.FName = customer.FName;
            customerModelSchedule.LName = customer.LName;
            customerModelSchedule.Email = customer.Email;
            customerModelSchedule.ContactNo = customer.ContactNo;

            return View(customerModelSchedule);
        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            var custDB = _context.Customers.SingleOrDefault(c => c.CId == customer.CId);

            custDB.CId = customer.CId;
            custDB.FName = customer.FName;
            custDB.LName = customer.LName;
            custDB.Email = customer.Email;
            custDB.ContactNo = customer.ContactNo;

            _context.SaveChanges();

            var custList = _context.Customers.ToList();

            return View("Index",custList);
        }
    }
}