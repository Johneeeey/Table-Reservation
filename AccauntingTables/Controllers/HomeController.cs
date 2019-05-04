using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccauntingTables.Models;

namespace AccauntingTables.Controllers
{
    public class HomeController : Controller
    {
        TableContext db;

        public HomeController(TableContext tableContext)
        {
            db = tableContext;
        }

        public IActionResult Index()
        {
            return View(db.Table.ToList());
        }
        [HttpGet]
        public IActionResult MakeAReservation(int TableNumber)
        {
            ViewBag.TableNumber = TableNumber;
            ViewBag.OwnerID = db.Owner.ToList()[db.Owner.ToList().Count - 1].IDOwner + 1;
            return View();
        }
        [HttpPost]
        public IActionResult Reservation(int TableNumber, Owner owner)
        {
            db.Owner.Add(owner);
            foreach(var table in db.Table)
            {
                if (table.TableNumber == TableNumber)
                {
                    table.Status = "Занят";
                    table.OwnerId = owner.IDOwner;
                }
            }
            db.SaveChanges();

            ViewBag.TableNumber = TableNumber;
            ViewBag.OwnerID = owner.IDOwner;
            ViewBag.OwnerName = owner.Name;
            ViewBag.OwnerSurname = owner.Surname;
            ViewBag.OwnerPatronymiv = owner.Patronymic;
            return View();
        }
        [HttpGet]
        public IActionResult RemoveAReservation(int TableNumber)
        {
            var table = db.Table.SingleOrDefault(t => t.TableNumber == TableNumber);
            if (table != null)
            {
                RemoveOwner(table.OwnerId);
                table.Status = "Свободен";
                table.OwnerId = 0;
                db.SaveChanges();
            }
            return View();
        }

        private void RemoveOwner(int? OwnerId)
        {
            Owner owner = db.Owner
                .Where(o => o.IDOwner == OwnerId)
                .FirstOrDefault();
            db.Owner.Remove(owner);
            db.SaveChanges();
        }
    }
}