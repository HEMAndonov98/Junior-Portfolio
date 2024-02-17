namespace TheBookSummary.Web.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;

    using Services.Mapping;
    
    using Data.Models.MyBookSummary_Models;
    using TheBookSummary.Common.ViewModelConstraints;

    /// <summary>
    /// Represents a view model for displaying book information.
    /// </summary>
    public class BookViewModel : IMapFrom<Book>
    {
        /// <summary>
        /// Gets or sets the ID of the book.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the book.
        /// </summary>
        [Display(Name = "Book name")]
        [Required(ErrorMessage = BookViewModelConstraints.RequiredMessage)]
        [StringLength(BookViewModelConstraints.BookNameMaxLength,
            MinimumLength = BookViewModelConstraints.BookNameMinLength,
            ErrorMessage = BookViewModelConstraints.InvalidNameLength)]
        public string BookName { get; set; }
        
        //ToDo AddSummaryViewModel
        
        //ToDo AddRatingsViewModel
        
        //TODo AddCollectionOfCommentViewModel
    }
}
