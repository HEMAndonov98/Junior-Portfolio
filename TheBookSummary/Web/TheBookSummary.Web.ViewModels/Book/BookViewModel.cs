using AutoMapper;

namespace TheBookSummary.Web.ViewModels.Book
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TheBookSummary.Services.Mapping;

    using TheBookSummary.Data.Models.MyBookSummary_Models;

    /// <summary>
    /// Represents a view model for displaying book information.
    /// </summary>
    public class BookViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        /// <summary>
        /// Gets or sets the ID of the book.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the book.
        /// </summary>
        [Display(Name = "Book name")]
        public string BookName { get; set; }

        /// <summary>
        /// Gets or sets the summary of the book.
        /// </summary>
        public BookSummaryViewModel Summary { get; set; }

        /// <summary>
        /// Gets or sets the rating of the book.
        /// </summary>
        [Display(Name = "Rating")]
        public int StarsRating { get; set; }

        /// <summary>
        /// Custom mapping configuration for the book view model.
        /// </summary>
        /// <param name="configuration">The AutoMapper profile configuration.</param>
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, BookViewModel>()
                .ForMember(
                    dst => dst.Summary,
                    opt => opt.MapFrom(
                        src => src.BookSummary));
        }
    }
}
