namespace TheBookSummary.Web.ViewModels.Book;

using System.ComponentModel.DataAnnotations;

using TheBookSummary.Common.Database_Model_Constraints;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Mapping;

public class RatingInputModel : IMapTo<Rating>
{
    [Display(Name ="Rating")]
    [Required(ErrorMessage = RatingConstraints.RequiredMessage)]
    [Range(
        RatingConstraints.MinStarRating,
        RatingConstraints.MaxStarRating,
        ErrorMessage = RatingConstraints.InvalidRatingGiven)]
    public int Stars { get; set; }

    public string UserId { get; set; }
}