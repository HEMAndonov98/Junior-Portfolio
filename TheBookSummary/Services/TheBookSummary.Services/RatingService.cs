namespace TheBookSummary.Services;

using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheBookSummary.Data.Common.Repositories;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Contracts;
using TheBookSummary.Web.ViewModels.Book;

public class RatingService : IRatingService
{
    private readonly IDeletableEntityRepository<Rating> _repository;
    private readonly IMapper _mapper;

    public RatingService(IDeletableEntityRepository<Rating> repository, IMapper mapper)
    {
        this._repository = repository;
        this._mapper = mapper;
    }

    public async Task AddBookRating(string bookId, RatingInputModel ratingInputModel)
    {
        var existingRating = await this._repository.AllAsNoTracking()
            .Include(r => r.Book)
            .Include(r => r.ApplicationUser)
            .FirstOrDefaultAsync(r => r.BookId == bookId && r.ApplicationUser.Id == ratingInputModel.UserId);

        if (existingRating != null)
        {
             await this.EditBookRating(bookId, ratingInputModel);
        }
        else
        {
            var rating = this._mapper.Map<Rating>(ratingInputModel);

            await this._repository.AddAsync(rating);
            await this._repository.SaveChangesAsync();

        }

        throw new System.NotImplementedException();
    }

    public async Task EditBookRating(string bookId, RatingInputModel ratingInputModel)
    {
        throw new System.NotImplementedException();
    }
}