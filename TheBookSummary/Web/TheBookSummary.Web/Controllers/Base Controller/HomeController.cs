namespace TheBookSummary.Web.Controllers.Base_Controller
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using TheBookSummary.Web.Controllers.Base_Controller;
    using TheBookSummary.Web.ViewModels;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.RedirectToAction("Index", "Book");
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
