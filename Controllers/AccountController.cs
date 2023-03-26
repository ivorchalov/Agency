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
    public class AccountController : Controller
    {
        private readonly ApplicationContext _context;

        public AccountController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult LoginPage()
        {
            return View("Login");
        }
        [HttpGet]
        public IActionResult RegisterPage()
        {
            return View("Register");
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            user.Discriminator = "Policyholder";
            _context.Users.Add(user);
            _context.SaveChanges();
            return Redirect("/Account/LoginPage");
        }
        [HttpPost]
        public IActionResult Login([Bind("Login,Password")] User user)
        {
            if (_context.Policyholders.Any(a => a.Password == user.Password && a.Login == user.Login))
            {
                long id = _context.Policyholders.Where(a => a.Password == user.Password && a.Login == user.Login).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());

                return RedirectToAction("TarifList", "Policyholder");
            }
            else if (_context.Agents.Any(a => a.Password == user.Password && a.Login == user.Login))
            {
                long id = _context.Agents.Where(a => a.Password == user.Password && a.Login == user.Login).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());

                return RedirectToAction("DogovorList", "Agent");
            }
            else if (_context.Admins.Any(a => a.Password == user.Password && a.Login == user.Login))
            {
                long id = _context.Admins.Where(a => a.Password == user.Password && a.Login == user.Login).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());

                return RedirectToAction("UsersList", "Admin");
            }
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("userId");
            return LoginPage();
        }
    }
}
