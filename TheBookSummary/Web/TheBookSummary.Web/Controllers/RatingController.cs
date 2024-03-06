namespace TheBookSummary.Web;

using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TheBookSummary.Services.Contracts;
using TheBookSummary.Web.Controllers;
using TheBookSummary.Web.ViewModels.Book;

public class RatingController : BaseController
{
    private readonly IRatingService _ratingService;

    private readonly ILogger _logger;

    public RatingController(IRatingService ratingService, ILogger<RatingController> logger)
    {
        this._ratingService = ratingService;
        this._logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Rate(RatingInputModel ratingInputModel)
    {

        try
        {
            if (!this.ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }
            await this._ratingService.AddBookRating(ratingInputModel);
            this._logger.LogInformation("Rating successfuly added!");

            return this.RedirectToAction(nameof(BookController.Details), nameof(BookController));
        }
        catch (Exception e)
        {
            this._logger.LogError("RatingController/Rate/[HttpPost]", e);
            return this.RedirectToAction(nameof(BookController.Details), nameof(BookController), ratingInputModel.BookId);
        }
    }
}
