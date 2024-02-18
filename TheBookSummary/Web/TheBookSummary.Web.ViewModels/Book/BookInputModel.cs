namespace TheBookSummary.Web.ViewModels.Book;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using TheBookSummary.Common.ViewModelConstraints;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Mapping;

public class BookInputModel : IMapTo<Book>
{
    [Display(Name = "Book name")]
    [Required(
        AllowEmptyStrings = false,
        ErrorMessage = BookViewModelConstraints.RequiredMessage)]
    [StringLength(
        BookViewModelConstraints.BookNameMaxLength,
        MinimumLength = BookViewModelConstraints.BookNameMinLength,
        ErrorMessage = BookViewModelConstraints.InvalidNameLength)]
    public string BookName { get; set; }

    public BookSummaryInputModel Summary { get; set; }

    public ICollection<RatingInputModel> Ratings { get; set; }

    public ICollection<BookCommentInputModel> Comments { get; set; }
}