using System;
using System.Collections.Generic;
using TheBookSummary.Web.ViewModels;
using TheBookSummary.Web.ViewModels.Book;

namespace TheBookSummary.Web.Controllers;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheBookSummary.Services.Contracts;

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
        IEnumerable<BookViewModel> bookViewModels;

        try
        {
            bookViewModels = await this._bookService.GetAllBooksAsync();
            ViewBag.Books = bookViewModels;
        }
        catch (Exception e)
        {
            this._logger.LogError("EventController/Index", e);
            return View("Error", new ErrorViewModel());
        }

        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
}