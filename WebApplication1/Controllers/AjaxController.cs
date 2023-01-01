using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AjaxController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        
        [HttpGet]
        public JsonResult DepartmentList()
        {
            var data = _context.Departments.ToList();
            return Json(data);
        }
        [HttpGet]
        public JsonResult EmployeList()
        {
            var data = _context.Employees.ToList();
            return Json(data);
        }

        [HttpPost]
        public JsonResult addEmployee(Employee objData)
        {
            var data = new Employee()
            {                
                EmployeeName = objData.EmployeeName,
                EmployeeEmail = objData.EmployeeEmail,
                EmployeeContact = objData.EmployeeContact,
                EmployeeAddress = objData.EmployeeAddress,
                DepartmentId = objData.DepartmentId,
            };
            _context.Employees.Add(data);
            _context.SaveChanges();
            return Json("Data Insert Successfully!");
        }

        public JsonResult Delete(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).SingleOrDefault();
            _context.Employees.Remove(data);
            _context.SaveChanges();
            return Json("Data is Deleted");
        }
        [HttpGet]
        public JsonResult GetbyId(int Id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == Id).SingleOrDefault();           
            return Json(data);
        }

        [HttpPost]
        public JsonResult Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Json("Update Data");
        }

    }
}
