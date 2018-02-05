using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLineWebsite.Models;

namespace MaerskLineWebsite.Controllers
{
    public class ContainersController : Controller
    {
        private ApplicationDbContext _context;

        public ContainersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }

        // GET: Containers
        public ActionResult Index()
        {
            var container = _context.Containers.ToList();

            return View(container);
        }

        public ActionResult Details(int containerId)
        {
            var container = _context.Containers.SingleOrDefault(c => c.ContainerId == containerId);

            if (container == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        //Create new Customer
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Container model) //it will straight create and save into the database. Then, a partial view will shown stating the schedules are created successfully.
        {
            _context.Containers.Add(model);
            _context.SaveChanges();

            return View("New");
        }
    }
}