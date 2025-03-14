#nullable enable
namespace TheBookSummary.Web.ViewModels.Comments;

using System.ComponentModel.DataAnnotations;

using TheBookSummary.Common.Database_Model_Constraints;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Mapping;

public class CommentInputModel : IMapTo<Comment>, IMapTo<Reply>
{
    /// <summary>
    /// Gets or sets the Text of the comment.
    /// </summary>
    [Required]
    [StringLength(
        CommentConstraints.CommentTextMaxLength,
        MinimumLength = CommentConstraints.CommentTextMinLength,
        ErrorMessage = CommentConstraints.InvalidCommentLength)]
    [Display(Name = "Comment")]
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the id of the book associated to this comment.
    /// </summary>
    public string BookId { get; set; }

    /// <summary>
    /// Gets or sets the id of the parent comment if this is a reply to a top level comment.
    /// </summary>
    public string? ParentCommentId { get; set; }
}
