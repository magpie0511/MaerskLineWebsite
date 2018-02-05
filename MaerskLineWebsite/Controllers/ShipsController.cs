using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLineWebsite.Models;

namespace MaerskLineWebsite.Controllers
{
    public class ShipsController : Controller
    {
        private ApplicationDbContext _context;

        public ShipsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }



        //Create new ship
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ship model) //it will straight create and save into the database. Then, a partial view will shown stating the schedules are created successfully.
        {
            _context.Ships.Add(model);
            _context.SaveChanges();

            var ships = _context.Ships.ToList();

            return View("Index",ships);
        }

        // GET: Ship
        public ActionResult Index()
        {
            var ships = _context.Ships.ToList();

            return View(ships);
        }

        public ActionResult Details(int Id)
        {
            var ship = _context.Ships.SingleOrDefault(s => s.ShipId == Id);

            if (ship == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        public ActionResult Edit(int Id)
        {
            var ship = _context.Ships.SingleOrDefault(s => s.ShipId == Id);

            if (ship == null)
            {
                return HttpNotFound();
            }

            Ship shipModelShip = new Ship();
            shipModelShip.ShipId = ship.ShipId;
            shipModelShip.Name = ship.Name;
            shipModelShip.ContainerNo = ship.ContainerNo;
            
            return View(shipModelShip);
        }

        [HttpPost]
        public ActionResult Update(Ship ship)
        {
            var shipDB = _context.Ships.SingleOrDefault(s => s.ShipId == ship.ShipId);

            shipDB.ShipId = ship.ShipId;
            shipDB.Name = ship.Name;
            shipDB.ContainerNo = ship.ContainerNo;
            
            _context.SaveChanges();

            var shipList = _context.Ships.ToList();

            return View("Index", shipList);
        }
    }
}