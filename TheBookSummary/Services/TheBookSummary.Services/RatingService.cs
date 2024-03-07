namespace TheBookSummary.Services;

using System;
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
    private readonly IDeletableEntityRepository<Rating> repository;
    private readonly IMapper mapper;

    private readonly IHttpContextAccessor httpContext;

    private readonly UserManager<ApplicationUser> userManager;

    public RatingService(IDeletableEntityRepository<Rating> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.httpContext = httpContextAccessor;
        this.userManager = userManager;
    }

    public async Task AddBookRating(RatingInputModel ratingInputModel)
    {
        string userId = this.userManager.GetUserId(this.httpContext.HttpContext.User);

        if (string.IsNullOrWhiteSpace(ratingInputModel.BookId))
        {
            throw new ArgumentNullException();
        }

        if (string.IsNullOrEmpty(userId))
        {
            throw new ArgumentNullException();
        }

        ratingInputModel.UserId = userId;

        var existingRating = await this.repository.AllAsNoTracking()
            .Include(r => r.Book)
            .Include(r => r.ApplicationUser)
            .FirstOrDefaultAsync(r => r.BookId == ratingInputModel.BookId && r.ApplicationUser.Id == ratingInputModel.UserId);

        if (existingRating != null)
        {
            await this.EditBookRating(ratingInputModel.BookId, ratingInputModel);
        }
        else
        {
            var rating = this.mapper.Map<Rating>(ratingInputModel);

            await this.repository.AddAsync(rating);
            await this.repository.SaveChangesAsync();
        }
    }

    public async Task EditBookRating(string bookId, RatingInputModel ratingInputModel)
    {
        var existingRating = await this.repository.All()
            .Include(r => r.Book)
            .Include(r => r.ApplicationUser)
            .FirstOrDefaultAsync(r => r.BookId == bookId && r.ApplicationUser.Id == ratingInputModel.UserId);

        if (existingRating == null)
        {
            throw new NullReferenceException();
        }

        var editedRating = this.mapper.Map<Rating>(ratingInputModel);

        this.repository.Update(editedRating);
        await this.repository.SaveChangesAsync();
    }
}
