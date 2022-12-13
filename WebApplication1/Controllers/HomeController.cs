using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.tblCustomers.Include(x=>x.tblCities).ToList());
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int Id)
        {

                tblCustomers s = new tblCustomers();
                if (Id > 0)
                {
                    s = _context.tblCustomers.Find(Id);
                }

            //City List for Dropdown
            var listItem = new SelectList(_context.tblCities.ToList(), "CityId", "CityName");
            ViewBag.CityId = listItem;

            return View(s);
           
        }

        [HttpPost]
        public IActionResult CreateOrEdit(tblCustomers model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.CustomerId > 0)
                    {
                        _context.tblCustomers.Update(model);
                        _context.SaveChanges();
                    }
                    else
                    {
                        _context.tblCustomers.Add(model);
                        _context.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else { 
            var userId = _context.tblCustomers.Find(Id);
            _context.tblCustomers.Remove(userId);
            _context.SaveChanges();
             return RedirectToAction(nameof(Index));

            }
        }


        public IActionResult Detail(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                var userId = _context.tblCustomers.Find(Id);                              
                return View(userId);
            }
        }
    }
}
