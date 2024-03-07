namespace TheBookSummary.Web.ViewModels.Book;

using System.ComponentModel.DataAnnotations;

using TheBookSummary.Common.Database_Model_Constraints;

/// <summary>
/// Represents an input model for creating a new comment for a book.
/// </summary>
public class BookCommentInputModel
{
    /// <summary>
    /// Gets or sets the text of the comment.
    /// </summary>
    [Display(Name = "Comment")]
    [Required(
        AllowEmptyStrings = false,
        ErrorMessage = CommentConstraints.RequiredMessage)]
    [StringLength(
        CommentConstraints.CommentTextMaxLength,
        MinimumLength = CommentConstraints.CommentTextMinLength,
        ErrorMessage = CommentConstraints.InvalidCommentLength)]
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the ID of the book associated with the comment.
    /// </summary>
    public string BookId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who made the comment.
    /// </summary>
    public string UserId { get; set; }
}
