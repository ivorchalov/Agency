using StrAgent.Models;
using StrAgent.Models.Roles;
using StrAgent.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;

namespace StrAgent.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationContext _context;

        public AdminController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            var roles = new List<String>() { "Admin", "Policyholder", "Agent" };
            ViewBag.Roles = new SelectList(roles);
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Redirect("/Admin/UsersList");
        }

        public IActionResult UsersList()
        {
            return View(_context.Users.ToList());
        }

        [HttpPost]
        public IActionResult EditUser(User user)
        {
            var userToUpdate = _context.Users.First(d => d.Id == user.Id);
            _context.Users.Remove(userToUpdate);
            _context.Users.Add(user);
            _context.SaveChanges();
            return Redirect("/Admin/UsersList");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var roles = new List<String>() { "Admin", "Policyholder", "Agent" };
            ViewBag.Roles = new SelectList(roles);
            return View(_context.Users.First(x => x.Id == id));
        }

        [HttpGet]
        public IActionResult UserDetails(int id)
        {
            return View(_context.Users.First(x => x.Id == id));
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.First(d => d.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Redirect("/Admin/UsersList");
        }

        [HttpGet]
        public IActionResult CreateTarif()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTarif(Tarif tarif)
        {
            _context.Tarifs.Add(tarif);
            _context.SaveChanges();
            return Redirect("/Admin/TarifList");
        }

        public IActionResult TarifList()
        {
            return View(_context.Tarifs.ToList());
        }

        [HttpPost]
        public IActionResult EditTarif(Tarif tarif)
        {
            _context.Tarifs.Update(tarif);
            _context.SaveChanges();
            return Redirect("/Admin/TarifList");
        }

        [HttpGet]
        public IActionResult EditTarif(int id)
        {
            return View(_context.Tarifs.First(x => x.Id == id));
        }

        [HttpGet]
        public IActionResult TarifDetails(int id)
        {
            return View(_context.Tarifs.First(x => x.Id == id));
        }

        [HttpGet]
        public IActionResult DeleteTarif(int id)
        {
            var tarif = _context.Tarifs.First(d => d.Id == id);
            _context.Tarifs.Remove(tarif);
            _context.SaveChanges();
            return Redirect("/Admin/TarifList");
        }
    }
}
