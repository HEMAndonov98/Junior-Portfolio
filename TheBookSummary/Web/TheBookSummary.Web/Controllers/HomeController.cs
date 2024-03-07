namespace TheBookSummary.Web.Controllers
{
    using System.Diagnostics;

    using TheBookSummary.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

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
