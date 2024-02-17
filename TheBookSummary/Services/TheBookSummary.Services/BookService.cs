namespace TheBookSummary.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

using TheBookSummary.Data.Common.Repositories;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Contracts;
using TheBookSummary.Web.ViewModels.Book;

/// <summary>
/// Service implementation for managing books.
/// </summary>
public class BookService : IBookService
{
    private readonly IDeletableEntityRepository<Book> _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookService"/> class.
    /// </summary>
    /// <param name="repository">Repository for accessing book data.</param>
    /// <param name="mapper">Automapper instance for object mapping.</param>
    public BookService(IDeletableEntityRepository<Book> repository, IMapper mapper)
    {
        this._repository = repository;
        this._mapper = mapper;
    }
    
    /// <summary>
    /// Retrieves all books asynchronously.
    /// </summary>
    /// <returns>A collection of <see cref="BookViewModel"/> representing all books.</returns>
    public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
    {
        var books = await this._repository
            .AllAsNoTracking()
            .ToArrayAsync();

        var bookViewModels = this._mapper.Map<IEnumerable<BookViewModel>>(books);

        return bookViewModels;
    }
}