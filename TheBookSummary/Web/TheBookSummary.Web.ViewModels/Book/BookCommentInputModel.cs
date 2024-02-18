namespace TheBookSummary.Web.ViewModels.Book;

using System.ComponentModel.DataAnnotations;

using TheBookSummary.Common.Database_Model_Constraints;

public class BookCommentInputModel
{
    [Display(Name = "Comment")]
    [Required(
        AllowEmptyStrings = false,
        ErrorMessage = CommentConstraints.RequiredMessage)]
    [StringLength(
        CommentConstraints.CommentTextMaxLength,
        MinimumLength = CommentConstraints.CommentTextMinLength,
        ErrorMessage = CommentConstraints.InvalidCommentLength)]
    public string Text { get; set; }

    public string BookId { get; set; }

    public string UserId { get; set; }
}