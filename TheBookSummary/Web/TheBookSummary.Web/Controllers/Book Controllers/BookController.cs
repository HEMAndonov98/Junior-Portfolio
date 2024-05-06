namespace TheBookSummary.Web.Controllers.Book_Controllers;

using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TheBookSummary.Common;
using TheBookSummary.Services.Contracts;
using TheBookSummary.Web.Controllers.Base_Controller;
using TheBookSummary.Web.ViewModels;
using TheBookSummary.Web.ViewModels.Book;

public class BookController : BaseController
{
    private readonly IBookService bookService;
    private readonly ILogger logger;

    public BookController(IBookService bookService, ILogger<BookController> logger)
    {
        this.bookService = bookService;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var bookViewModels = await this.bookService.GetAllBooksAsync();

            if (!this.ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }

            this.logger.LogInformation("Displaying summaries");
            return this.View(bookViewModels);
        }
        catch (Exception e)
        {
            this.logger.LogError("BookController/Index", e);
            return this.View("Error", new ErrorViewModel());
        }
    }

    [HttpGet]
    [Authorize(Roles = $"{GlobalConstants.AdministratorRoleName},{GlobalConstants.ModeratorRoleName}")]
    public IActionResult Create()
    {
        return this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = $"{GlobalConstants.AdministratorRoleName},{GlobalConstants.ModeratorRoleName}")]
    public async Task<IActionResult> Create(BookInputModel inputModel)
    {
        try
        {
            if (!this.ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }

            await this.bookService.AddBookAsync(inputModel);

            this.logger.LogInformation("New book added to database!");
        }
        catch (Exception e)
        {
            this.logger.LogError("EventController/Create/[HttpPost]", e);
            return this.View("Error", new ErrorViewModel());
        }

        return this.RedirectToAction(nameof(this.Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        try
        {
            BookViewModel viewModel = await this.bookService.RetrieveSingleBookAsync(id);

            if (!this.ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }

            // Get average rating
            double averageStars = 0;

            if (viewModel.StarsRating.Any())
            {
                averageStars = viewModel.StarsRating.Average(r => r.Stars) / 2;
            }

            this.ViewBag.averageRating = averageStars;

            this.logger.LogInformation("Displaying book details");
            return this.View(viewModel);
        }
        catch (Exception e)
        {
            this.logger.LogError("BookController/Details/[HttpGet]", e);
            return this.View("Error", new ErrorViewModel());
        }
    }
}
