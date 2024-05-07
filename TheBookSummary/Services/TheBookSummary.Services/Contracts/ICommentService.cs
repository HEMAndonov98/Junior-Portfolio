namespace TheBookSummary.Services.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

using TheBookSummary.Web.ViewModels.Book;
using TheBookSummary.Web.ViewModels.Comments;

public interface ICommentService
{
     Task AddCommentAsync(CommentInputModel inputModel);

     Task AddReplyToCommentAsync(CommentInputModel inputModel);

     Task<CommentViewModel> GetSingleCommentAsync(string commentId);

     Task<IList<CommentViewModel>> GetCommentSetAsync(int pageNum);
}
