namespace TheBookSummary.Services;

using System.Threading.Tasks;

using AutoMapper;
using TheBookSummary.Data.Common.Repositories;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Contracts;
using TheBookSummary.Web.ViewModels.Book;

public class RatingService : IRatingService
{
    private readonly IDeletableEntityRepository<Book> _repository;
    private readonly IMapper _mapper;

    public RatingService(IDeletableEntityRepository<Book> repository, IMapper mapper)
    {
        this._repository = repository;
        this._mapper = mapper;
    }
    
    public async Task AddBookRating(string bookId, RatingInputModel ratingInputModel)
    {
        
        throw new System.NotImplementedException();
    }

    public async Task EditBookRating(string bookId, RatingInputModel ratingInputModel)
    {
        throw new System.NotImplementedException();
    }
}