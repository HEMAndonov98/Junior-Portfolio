namespace TheBookSummary.Services;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TheBookSummary.Common.Service_MagicNumbers;
using TheBookSummary.Data.Common.Repositories;
using TheBookSummary.Data.Models.Identity;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Contracts;
using TheBookSummary.Web.ViewModels.Comments;

public class CommentService : ICommentService
{
    private readonly IDeletableEntityRepository<Comment> commentRepo;
    private readonly IDeletableEntityRepository<Reply> replyRepo;
    private readonly IHttpContextAccessor httpContext;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IMapper mapper;

    public CommentService(
        IDeletableEntityRepository<Comment> commentRepo,
        IDeletableEntityRepository<Reply> replyRepo,
        IHttpContextAccessor httpContext,
        UserManager<ApplicationUser> userManager,
        IMapper mapper)
    {
        this.commentRepo = commentRepo;
        this.replyRepo = replyRepo;
        this.httpContext = httpContext;
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async Task AddCommentAsync(CommentInputModel inputModel)
    {
        var newComment = this.mapper.Map<Comment>(inputModel);

        newComment.ApplicationUser = await this.userManager.GetUserAsync(this.httpContext.HttpContext.User);

        await this.commentRepo.AddAsync(newComment);
        await this.commentRepo.SaveChangesAsync();
    }

    public async Task AddReplyToCommentAsync(CommentInputModel inputModel)
    {
        var newReply = this.mapper.Map<Reply>(inputModel);

        newReply.ApplicationUser = await this.userManager.GetUserAsync(this.httpContext.HttpContext.User);

        await this.replyRepo.AddAsync(newReply);
        await this.replyRepo.SaveChangesAsync();
    }

    public async Task<CommentViewModel> GetSingleCommentAsync(string commentId)
    {
        var comment = await this.commentRepo
            .AllAsNoTracking()
            .Include(c => c.ApplicationUser.UserName)
            .Include(c => c.Replies)
            .FirstOrDefaultAsync(c => c.Id == commentId);

        var viewModel = this.mapper.Map<CommentViewModel>(comment);

        return viewModel;
    }

    public async Task<IList<CommentViewModel>> GetCommentSetAsync(int pageNum)
    {
        var topComments = await this.commentRepo
            .AllAsNoTracking()
            .Include(c => c.ApplicationUser.UserName)
            .Include(c => c.Replies)
            .OrderBy(c => c.CreatedOn)
            .Skip(pageNum)
            .Take(CommentServiceConstraints.TopLevelCommentSet)
            .ProjectTo<CommentViewModel>(this.mapper.ConfigurationProvider)
            .ToListAsync();

        return topComments;
    }
}
