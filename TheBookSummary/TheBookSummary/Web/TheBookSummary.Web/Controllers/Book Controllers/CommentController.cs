namespace TheBookSummary.Web.Controllers.Book_Controllers;

using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheBookSummary.Services.Contracts;
using TheBookSummary.Web.Controllers.Base_Controller;
using TheBookSummary.Web.ViewModels.Comments;

public class CommentController : BaseController
{
    private readonly ICommentService commentService;
    private readonly ILogger logger;

    public CommentController(ICommentService commentService, ILogger<CommentController> logger)
    {
        this.commentService = commentService;
        this.logger = logger;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddComment(CommentInputModel inputModel)
    {
        try
        {
            if (!this.ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }

            await this.commentService.AddCommentAsync(inputModel);
            this.logger.LogInformation($"{this.User.Identity.Name} Added a new comment with text: {Environment.NewLine} {inputModel.Text}");
            return this.RedirectToAction("Details", "Book", new { id = inputModel.BookId });
        }
        catch (Exception e)
        {
            this.logger.LogError("CommentController/AddComment", e);
            return this.RedirectToAction("Details", "Book", new { id = inputModel.BookId });
        }
    }

    public async Task<IActionResult> AddReply()
    {
        throw new NotImplementedException();
    }
}
