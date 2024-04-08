namespace TheBookSummary.Web.ViewModels.Rating;

using System.ComponentModel.DataAnnotations;

using TheBookSummary.Common.Database_Model_Constraints;
using TheBookSummary.Services.Mapping;

/// <summary>
/// Represents an input model for adding a rating to a book.
/// </summary>
public class RatingInputModel : IMapTo<Data.Models.MyBookSummary_Models.Rating>
{
    /// <summary>
    /// Gets or sets the rating given to the book.
    /// </summary>
    [Display(Name = "Rating")]
    [Required(ErrorMessage = RatingConstraints.RequiredMessage)]
    [Range(
        RatingConstraints.MinStarRating,
        RatingConstraints.MaxStarRating,
        ErrorMessage = RatingConstraints.InvalidRatingGiven)]
    public int Stars { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who submitted the rating.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the Book that is connected to this rating.
    /// </summary>
    public string BookId { get; set; }
}
