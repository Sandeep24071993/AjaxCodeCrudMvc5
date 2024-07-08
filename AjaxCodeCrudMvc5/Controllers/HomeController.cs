using AjaxCodeCrudMvc5.Models;
using System.Linq;
using System.Web.Mvc;

namespace AjaxCodeCrudMvc5.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDbContext db = new EmployeeDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEmployee()
        {
            var data = db.Employees.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return Json(employee);
        }

        public JsonResult Edit(int id)
        {
            var data = db.Employees.Where(x => x.Id == id).SingleOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateEmployee(Employee employee)
        {
            var existingEmployee = db.Employees.Find(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.City = employee.City;
                existingEmployee.State = employee.State;
                existingEmployee.Salary = employee.Salary;
                db.SaveChanges();
            }
            return Json(employee);
        }

        [HttpPost]
        public JsonResult DeleteEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            return Json(employee);
        }
    }
}
