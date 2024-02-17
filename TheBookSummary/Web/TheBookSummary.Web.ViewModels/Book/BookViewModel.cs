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
        /// Gets or sets the short summary of the book.
        /// </summary>
        [Display(Name = "Short summary")]
        public string ShortSummary { get; set; }

        /// <summary>
        /// Gets or sets the full summary of the book.
        /// </summary>
        [Display(Name = "Full summary")]
        public string FullSummary { get; set; }

        /// <summary>
        /// Gets or sets the rating of the book.
        /// </summary>
        [Display(Name = "Rating")]
        public int StarsRating { get; set; }

        /// <summary>
        /// Gets or sets the collection of comment view models associated with the book.
        /// </summary>
        [Display(Name = "Comments")]
        public ICollection<CommentViewModel> CommentViewModels { get; set; }

        /// <summary>
        /// Custom mapping configuration for the book view model.
        /// </summary>
        /// <param name="configuration">The AutoMapper profile configuration.</param>
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Rating, BookViewModel>()
                .ForMember(
                    source => source.StarsRating,
                    destination => destination.MapFrom(member => member.Stars));

            configuration.CreateMap<Comment[], BookViewModel>()
                .ForMember(
                    source => source.CommentViewModels,
                    destination => destination.MapFrom(member => member));
        }
    }
}
