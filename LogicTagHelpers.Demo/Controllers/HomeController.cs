using Microsoft.AspNetCore.Mvc;

namespace LogicTagHelpers.Demo.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult TestIf()
		{
			return View();
		}
	}
}