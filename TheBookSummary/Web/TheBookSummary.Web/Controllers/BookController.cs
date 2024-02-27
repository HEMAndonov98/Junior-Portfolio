namespace TheBookSummary.Web.Controllers;

using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TheBookSummary.Services.Contracts;
using TheBookSummary.Web.ViewModels;
using TheBookSummary.Web.ViewModels.Book;

public class BookController : BaseController
{
    private readonly IBookService _bookService;
    private readonly ILogger _logger;

    public BookController(IBookService bookService, ILogger<BookController> logger)
    {
        this._bookService = bookService;
        this._logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var bookViewModels = await this._bookService.GetAllBooksAsync();

            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }

            this._logger.LogInformation("Displaying summaries");
            return View(bookViewModels);
        }
        catch (Exception e)
        {
            this._logger.LogError("EventController/Index", e);
            return View("Error", new ErrorViewModel());
        }
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookInputModel inputModel)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }

            await this._bookService.AddBookAsync(inputModel);

            this._logger.LogInformation("New book added to database!");
        }
        catch (Exception e)
        {
            this._logger.LogError("EventController/Create/[HttpPost]", e);
            return View("Error", new ErrorViewModel());
        }

        return Ok();
    }
}