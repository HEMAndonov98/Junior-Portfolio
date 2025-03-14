namespace TheBookSummary.Data.Models.MyBookSummary_Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using TheBookSummary.Common.Database_Model_Constraints;
using TheBookSummary.Data.Common.Models;
using TheBookSummary.Data.Models.Identity;

/// <summary>
///     Represents a model for storing ratings of books in the database.
/// </summary>
public class Rating : BaseDeletableModel<string>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Rating" /> class.
    /// </summary>
    public Rating()
    {
        // Set a unique identifier for the rating.
        this.Id = Guid.NewGuid().ToString();
    }

    /// <summary>
    ///     Gets or sets the number of stars given in the rating.
    /// </summary>
    [Range(RatingConstraints.MinStarRating, RatingConstraints.MaxStarRating)]
    [Comment("Number of stars given in the rating. Must be within the defined range.")]
    public int Stars { get; set; }

    /// <summary>
    ///     Gets or sets the foreign key referencing the associated book.
    /// </summary>
    [ForeignKey(nameof(Book))]
    [Comment("Foreign key referencing the associated book.")]
    public string BookId { get; set; }

    /// <summary>
    ///     Gets or sets the navigation property representing the associated book.
    /// </summary>
    [Comment("Navigation property representing the associated book.")]
    public Book Book { get; set; }

    /// <summary>
    ///     Gets or sets the foreign key referencing the user who made the rating.
    /// </summary>
    [ForeignKey(nameof(ApplicationUser))]
    [Comment("Foreign key referencing the user who made the rating.")]
    public string UserId { get; set; }

    /// <summary>
    ///     Gets or sets the navigation property representing the user who made the rating.
    /// </summary>
    [Comment("Navigation property representing the user who made the rating.")]
    public ApplicationUser ApplicationUser { get; set; }
}
