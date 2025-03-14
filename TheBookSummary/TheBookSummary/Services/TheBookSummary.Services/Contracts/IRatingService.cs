using TheBookSummary.Web.ViewModels.Rating;

namespace TheBookSummary.Services.Contracts;

using System.Threading.Tasks;

using TheBookSummary.Web.ViewModels.Book;

public interface IRatingService
{
    Task AddBookRating(RatingInputModel ratingInputModel);

    Task EditBookRating(RatingInputModel ratingInputModel);
}
