using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public string List()
        {
            return "This is list from Department controller";
        }

        public string Information()
        {
            return "This is Information from Department controller";
        }

    }
}
