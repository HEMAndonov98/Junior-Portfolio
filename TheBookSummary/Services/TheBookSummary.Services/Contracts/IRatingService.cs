namespace TheBookSummary.Services.Contracts;

using System.Threading.Tasks;

using TheBookSummary.Web.ViewModels.Book;

public interface IRatingService
{
    Task AddBookRating(string bookId, RatingInputModel ratingInputModel);

    Task EditBookRating(string bookId, RatingInputModel ratingInputModel);
}
