namespace TheBookSummary.Web.ViewModels.Book;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using TheBookSummary.Common.ViewModelConstraints;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Mapping;

/// <summary>
/// Represents an input model for creating or updating a book.
/// </summary>
public class BookInputModel : IMapTo<Book>
{
    /// <summary>
    /// Gets or sets the name of the book.
    /// </summary>
    [Display(Name = "Book name")]
    [Required(
        AllowEmptyStrings = false,
        ErrorMessage = BookViewModelConstraints.RequiredMessage)]
    [StringLength(
        BookViewModelConstraints.BookNameMaxLength,
        MinimumLength = BookViewModelConstraints.BookNameMinLength,
        ErrorMessage = BookViewModelConstraints.InvalidNameLength)]
    public string BookName { get; set; }

    /// <summary>
    /// Gets or sets the summary input model for the book.
    /// </summary>
    public BookSummaryInputModel Summary { get; set; }

    /// <summary>
    /// Gets or sets the collection of rating input models for the book.
    /// </summary>
    public ICollection<Rating> Ratings { get; set; }

    /// <summary>
    /// Gets or sets the collection of comment input models for the book.
    /// </summary>
    public ICollection<Comment> Comments { get; set; }
}