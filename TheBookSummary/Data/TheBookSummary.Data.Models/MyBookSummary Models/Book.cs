namespace TheBookSummary.Data.Models.MyBookSummary_Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TheBookSummary.Common.Database_Model_Constraints;
using TheBookSummary.Data.Common.Models;

/// <summary>
/// Represents a model for storing book information in the database.
/// </summary>
public class Book : BaseDeletableModel<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Book"/> class.
    /// </summary>
    public Book()
    {
        // Set a unique identifier for the book.
        Id = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Gets or sets the name of the book.
    /// </summary>
    [Required]
    [MaxLength(BookConstraints.NameLength)]
    [Comment("Name of the book. It is required and has a maximum length as defined by BookConstraints.")]
    public string BookName { get; set; }

    /// <summary>
    /// Gets or sets the foreign key referencing the associated book summary.
    /// </summary>
    [ForeignKey(nameof(BookSummary))]
    [Comment("Foreign key referencing the associated book summary.")]
    public string BookSummaryId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property representing the associated book summary.
    /// </summary>
    [Comment("Navigation property representing the associated book summary.")]
    public BookSummary BookSummary { get; set; }

    /// <summary>
    /// Gets or sets the collection of ratings associated with the book.
    /// </summary>
    [InverseProperty(nameof(Rating.Book))]
    [Comment("Collection of ratings associated with the book.")]
    public ICollection<Rating> Ratings { get; set; }

    /// <summary>
    /// Gets or sets the collection of comments associated with the book.
    /// </summary>
    [InverseProperty(nameof(Comment.Book))]
    [Comment("Collection of comments associated with the book.")]
    public ICollection<Comment> Comments { get; set; }
}
