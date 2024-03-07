namespace TheBookSummary.Services.Contracts;

using System.Threading.Tasks;

using TheBookSummary.Web.ViewModels.Book;

public interface IRatingService
{
    Task AddBookRating(RatingInputModel ratingInputModel);

    // To do change this to remove the string bookId
    Task EditBookRating(string bookId, RatingInputModel ratingInputModel);
}
