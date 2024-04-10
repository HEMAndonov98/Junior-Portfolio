namespace TheBookSummary.Services.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

using TheBookSummary.Web.ViewModels.Book;
using TheBookSummary.Web.ViewModels.Comments;

public interface ICommentService
{
     Task AddCommentAsync(CommentInputModel inputModel);

     Task AddReplyToComment(CommentInputModel inputModel);

     Task<CommentViewModel> GetSingleComment(string commentId);

     Task<IList<CommentViewModel>> GetCommentSet(int pageNum);
}
