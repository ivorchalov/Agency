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
    public class AgentController : Controller
    {
        private readonly ApplicationContext _context;

        public AgentController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateTarif(Tarif tarif)
        {
            _context.Tarifs.Add(tarif);
            _context.SaveChanges();
            return Redirect("/Agent/TarifList");
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
            return Redirect("/Agent/TarifList");
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
            return Redirect("/Agent/TarifList");
        }

        public IActionResult DogovorList()
        {
            var model = _context.Dogovors.ToList();
            foreach (var item in model)
            {
                item.Klient = _context.Users.First(x => x.Id == item.IDKl);
                item.Tarif = _context.Tarifs.First(x => x.Id == item.IDTr);
                if (item.Status != "Waiting")
                    item.Agent = _context.Agents.First(x => x.Id == item.IDAg);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DogovorDetails(int id)
        {
            var model = _context.Dogovors.First(x => x.Id == id);
            model.Klient = _context.Users.First(x => x.Id == model.IDKl);
            model.Tarif = _context.Tarifs.First(x => x.Id == model.IDTr);
            if (model.Status != "Waiting")
                model.Agent = _context.Agents.First(x => x.Id == model.IDAg);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditDogovor(Dogovor dogovor)
        {
            dogovor.IDAg = Int32.Parse(Request.Cookies["userId"]);
            _context.Dogovors.Update(dogovor);
            _context.SaveChanges();
            return Redirect("/Agent/DogovorList");
        }

        [HttpGet]
        public IActionResult EditDogovor(int id)
        {
            var tarifs = _context.Tarifs.ToList();
            ViewBag.Tarifs = new SelectList(tarifs);
            var statuses = new List<String>() { "Waiting", "Accepted", "Denied" };
            ViewBag.Statuses = new SelectList(statuses);
            var model = _context.Dogovors.First(x => x.Id == id);
            model.Klient = _context.Users.First(x => x.Id == model.IDKl);
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteDogovor(int id)
        {
            var dogovor = _context.Dogovors.First(d => d.Id == id);
            _context.Dogovors.Remove(dogovor);
            _context.SaveChanges();
            return Redirect("/Agent/DogovorList");
        }

        public IActionResult StrSlList()
        {
            var model = _context.StrSls.ToList();
            foreach (var item in model)
            {
                item.Klient = _context.Users.First(x => x.Id == item.IDKl);
                if (item.Status != "Waiting")
                    item.Agent = _context.Agents.First(x => x.Id == item.IDAg);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult StrSlDetails(int id)
        {
            var model = _context.StrSls.First(x => x.Id == id);
            model.Klient = _context.Users.First(x => x.Id == model.IDKl);
            if (model.Status != "Waiting")
                model.Agent = _context.Agents.First(x => x.Id == model.IDAg);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditStrSl(StrSl strsl)
        {
            strsl.IDAg = Int32.Parse(Request.Cookies["userId"]);
            _context.StrSls.Update(strsl);
            _context.SaveChanges();
            return Redirect("/Agent/StrSlList");
        }

        [HttpGet]
        public IActionResult EditStrSl(int id)
        {
            var statuses = new List<String>() { "Waiting", "Accepted", "Denied" };
            ViewBag.Statuses = new SelectList(statuses);
            var model = _context.StrSls.First(x => x.Id == id);
            model.Klient = _context.Users.First(x => x.Id == model.IDKl);
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteStrSl(int id)
        {
            var strsl = _context.StrSls.First(d => d.Id == id);
            _context.StrSls.Remove(strsl);
            _context.SaveChanges();
            return Redirect("/Agent/StrSlList");
        }
    }
}
