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
    public class PolicyholderController : Controller
    {
        private readonly ApplicationContext _context;

        public PolicyholderController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult TarifList()
        {
            return View(_context.Tarifs.ToList());
        }

        [HttpGet]
        public IActionResult TarifDetails(int id)
        {
            return View(_context.Tarifs.First(x => x.Id == id));
        }

        [HttpGet]
        public IActionResult CreateDogovor()
        {
            var tarifs = _context.Tarifs.ToList();
            ViewBag.Tarifs = new SelectList(tarifs);
            return View();
        }

        [HttpPost]
        public IActionResult CreateDogovor(Dogovor dogovor)
        {
            dogovor.Status = "Waiting";
            dogovor.IDKl = Int32.Parse(Request.Cookies["userId"]);
            _context.Dogovors.Add(dogovor);
            _context.SaveChanges();
            return Redirect("/Policyholder/DogovorList");
        }

        public IActionResult DogovorList()
        {
            var model = _context.Dogovors.Where(x => x.IDKl == Int32.Parse(Request.Cookies["userId"])).ToList();
            foreach (var item in model)
            {
                item.Klient = _context.Users.First(x => x.Id == item.IDKl);
                item.Tarif = _context.Tarifs.First(x => x.Id == item.IDTr);
                if (item.Status != "Waiting")
                    item.Agent = _context.Agents.First(x => x.Id == item.IDAg);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult EditDogovor(Dogovor dogovor)
        {
            _context.Dogovors.Update(dogovor);
            _context.SaveChanges();
            return Redirect("/Policyholder/DogovorList");
        }

        [HttpGet]
        public IActionResult EditDogovor(int id)
        {
            var tarifs = _context.Tarifs.ToList();
            ViewBag.Tarifs = new SelectList(tarifs);
            return View(_context.Dogovors.First(x => x.Id == id));
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

        [HttpGet]
        public IActionResult DeleteDogovor(int id)
        {
            var dogovor = _context.Dogovors.First(d => d.Id == id);
            _context.Dogovors.Remove(dogovor);
            _context.SaveChanges();
            return Redirect("/Policyholder/DogovorList");
        }

        [HttpGet]
        public IActionResult CreateStrSl()
        {
            var dogovors = _context.Dogovors.Where(x => x.IDKl == Int32.Parse(Request.Cookies["userId"]) && x.Status == "Accepted").ToList();
            ViewBag.Dogovors = new SelectList(dogovors);
            return View();
        }

        [HttpPost]
        public IActionResult CreateStrSl(StrSl strsl)
        {
            strsl.IDKl = Int32.Parse(Request.Cookies["userId"]);
            strsl.Status = "Waiting";
            _context.StrSls.Add(strsl);
            _context.SaveChanges();
            return Redirect("/Policyholder/StrSlList");
        }

        public IActionResult StrSlList()
        {
            var model = _context.StrSls.Where(x => x.IDKl == Int32.Parse(Request.Cookies["userId"])).ToList();
            foreach (var item in model)
            {
                item.Klient = _context.Users.First(x => x.Id == item.IDKl);
                if (item.Status != "Waiting")
                    item.Agent = _context.Agents.First(x => x.Id == item.IDAg);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult EditStrSl(StrSl strsl)
        {
            _context.StrSls.Update(strsl);
            _context.SaveChanges();
            return Redirect("/Policyholder/StrSlList");
        }

        [HttpGet]
        public IActionResult EditStrSl(int id)
        {
            var dogovors = _context.Dogovors.Where(x => x.IDKl == Int32.Parse(Request.Cookies["userId"]) && x.Status == "Accepted").ToList();
            ViewBag.Dogovors = new SelectList(dogovors);
            return View(_context.StrSls.First(x => x.Id == id));
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

        [HttpGet]
        public IActionResult DeleteStrSl(int id)
        {
            var strsl = _context.StrSls.First(d => d.Id == id);
            _context.StrSls.Remove(strsl);
            _context.SaveChanges();
            return Redirect("/Policyholder/StrSlList");
        }
    }
}
