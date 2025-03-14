namespace TheBookSummary.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    private readonly IDeletableEntityRepository<Book> repository;
    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookService"/> class.
    /// </summary>
    /// <param name="repository">Repository for accessing book data.</param>
    /// <param name="mapper">Automapper instance for object mapping.</param>
    public BookService(IDeletableEntityRepository<Book> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Retrieves all books asynchronously.
    /// </summary>
    /// <returns>A collection of <see cref="BookViewModel"/> representing all books.</returns>
    public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
    {
        var books = await this.repository
            .AllAsNoTracking()
            .ProjectTo<BookViewModel>(this.mapper.ConfigurationProvider)
            .ToArrayAsync();

        // If automapping breaks try manual

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
        return books;
    }

    /// <summary>
    /// Adds a new book to the database.
    /// </summary>
    /// <param name="inputModel">The input model containing information about the book to be added.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddBookAsync(BookInputModel inputModel)
    {
        // Automapping
        var book = this.mapper.Map<Book>(inputModel);
        await this.repository.AddAsync(book);
        await this.repository.SaveChangesAsync();

        // manual mapping
        //  var newSummary = new BookSummary()
        //  {
        //      ShortSummary = inputModel.Summary.ShortSummary,
        //      FullSummary = inputModel.Summary.FullSummary,
        //  };
        //
        //  var newBook = new Book()
        //  {
        //      BookName = inputModel.BookName,
        //      BookSummary = newSummary,
        //      Ratings = new List<Rating>(),
        //      Comments = new List<Comment>(),
        //  };
        //
        //  await this._repository.AddAsync(newBook);
        // await this._repository.SaveChangesAsync();
    }

    public async Task<BookViewModel> RetrieveSingleBookAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentNullException();
        }

        var book = await this.repository.Find(book => book.Id == id)
            .Include(b => b.Ratings)
            .ProjectTo<BookViewModel>(this.mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return book;
    }
}
