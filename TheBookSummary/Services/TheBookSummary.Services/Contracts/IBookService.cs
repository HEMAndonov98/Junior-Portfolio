using System.Collections.Generic;
using System.Threading.Tasks;
using TheBookSummary.Web.ViewModels.Book;

namespace TheBookSummary.Services.Contracts;

public interface IBookService
{
    Task<IEnumerable<BookViewModel>> GetAllBooksAsync();
}