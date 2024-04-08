namespace TheBookSummary.Web.Controllers.Book_Controllers;

using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TheBookSummary.Services.Contracts;
using TheBookSummary.Web.Controllers.Base_Controller;
using TheBookSummary.Web.ViewModels.Book;
using TheBookSummary.Web.ViewModels.Rating;

public class RatingController : BaseController
{
    private readonly IRatingService ratingService;

    private readonly ILogger logger;

    public RatingController(IRatingService ratingService, ILogger<RatingController> logger)
    {
        this.ratingService = ratingService;
        this.logger = logger;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Rate(RatingInputModel ratingInputModel)
    {
        try
        {
            if (!this.ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }

            await this.ratingService.AddBookRating(ratingInputModel);
            this.logger.LogInformation("Rating successfully added!");

            return this.RedirectToAction("Details", "Book", new { Id = ratingInputModel.BookId });
        }
        catch (Exception e)
        {
            this.logger.LogError("RatingController/Rate/[HttpPost]", e);
            return this.RedirectToAction(nameof(BookController.Details), nameof(BookController), ratingInputModel.BookId);
        }
    }
}
