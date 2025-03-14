using AutoMapper;

namespace TheBookSummary.Web.ViewModels.Book;

using System.ComponentModel.DataAnnotations;

using TheBookSummary.Common.ViewModelConstraints;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Mapping;

public class BookSummaryInputModel : IMapTo<BookSummary>
{
    [Display(Name = "Short summary")]
    [Required(
        AllowEmptyStrings = false,
        ErrorMessage = BookViewModelConstraints.RequiredMessage)]
    [StringLength(
        BookViewModelConstraints.BookShortSummaryMaxLength,
        MinimumLength = BookViewModelConstraints.BookFullSummaryMinLength,
        ErrorMessage = BookViewModelConstraints.InvalidSummaryLength)]
    public string ShortSummary { get; set; }

    [Display(Name = "Full summary")]
    [Required(
        AllowEmptyStrings = false,
        ErrorMessage = BookViewModelConstraints.RequiredMessage)]
    [StringLength(
        BookViewModelConstraints.BookFullSummaryMaxLength,
        MinimumLength = BookViewModelConstraints.BookFullSummaryMinLength,
        ErrorMessage = BookViewModelConstraints.InvalidSummaryLength)]
    public string FullSummary { get; set; }
}
