using System;
using System.Linq;

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

        // If automapping breaks try manual
         var bookViewModels = this._mapper.Map<IEnumerable<BookViewModel>>(books);

        // manual mapping
        // var bookViewModels = await this._repository
        //     .AllAsNoTracking()
        //     .Include(b => b.Ratings)
        //     .Include(b => b.Comments.Take(10))
        //     .Select(b => new BookViewModel()
        //     {
        //         Id = b.Id,
        //         BookName = b.BookName,
        //         ShortSummary = b.BookSummary.ShortSummary,
        //         FullSummary = b.BookSummary.FullSummary,
        //         StarsRating = (int)b.Ratings.Average(r => r.Stars),
        //         CommentViewModels = b.Comments
        //             .Select(c => new CommentViewModel()
        //             {
        //                 Text = c.Text,
        //                 Username = c.ApplicationUser.UserName,
        //             })
        //             .ToArray(),
        //     })
        //     .ToArrayAsync();
         return bookViewModels;
    }

    public async Task AddBook(BookInputModel inputModel)
    {
        
    }
}
