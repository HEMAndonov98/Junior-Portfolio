namespace TheBookSummary.Services;

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TheBookSummary.Data.Common.Repositories;
using TheBookSummary.Data.Models.Identity;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Contracts;
using TheBookSummary.Web.ViewModels.Book;

public class RatingService : IRatingService
{
    private readonly IDeletableEntityRepository<Rating> _repository;
    private readonly IMapper _mapper;

    private readonly IHttpContextAccessor _httpContext;

    private readonly UserManager<ApplicationUser> _userManager;

    public RatingService(IDeletableEntityRepository<Rating> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
    {
        this._repository = repository;
        this._mapper = mapper;
        this._httpContext = httpContextAccessor;
        this._userManager = userManager;
    }

    public async Task AddBookRating(string bookId, RatingInputModel ratingInputModel)
    {
        string userId = this._userManager.GetUserId(this._httpContext.HttpContext.User);

        if (string.IsNullOrEmpty(userId))
        {
            throw new ArgumentNullException();
        }

        ratingInputModel.UserId = userId;

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
        var existingRating = await this._repository.All()
            .Include(r => r.Book)
            .Include(r => r.ApplicationUser)
            .FirstOrDefaultAsync(r => r.BookId == bookId && r.ApplicationUser.Id == ratingInputModel.UserId);

        if (existingRating == null)
        {
            throw new NullReferenceException();
        }

        var editedRating = this._mapper.Map<Rating>(ratingInputModel);

        this._repository.Update(editedRating);
        await this._repository.SaveChangesAsync();
    }
}