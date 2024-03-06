namespace TheBookSummary.Web;

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

    public async Task<IActionResult> Rate(RatingInputModel ratingInputModel)
    {
        await this._ratingService.AddBookRating("1", ratingInputModel);

        return this.Ok();
    }
}
