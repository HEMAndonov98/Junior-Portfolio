namespace TheBookSummary.Services.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

using TheBookSummary.Web.ViewModels.Book;

public interface IBookService
{
    Task<IEnumerable<BookViewModel>> GetAllBooksAsync();

    Task AddBookAsync(BookInputModel inputModel);

    Task<BookViewModel> RetrieveSingleBookAsync(string id);
}
