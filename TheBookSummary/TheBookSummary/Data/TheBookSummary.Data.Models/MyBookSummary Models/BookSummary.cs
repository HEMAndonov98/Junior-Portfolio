namespace TheBookSummary.Data.Models.MyBookSummary_Models;

using System;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using TheBookSummary.Common.Database_Model_Constraints;
using TheBookSummary.Data.Common.Models;

/// <summary>
/// Represents a model for storing book summaries in the database.
/// </summary>
public class BookSummary : BaseDeletableModel<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BookSummary"/> class.
    /// </summary>
    public BookSummary()
    {
        // Set a unique identifier for the book summary.
        this.Id = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Gets or sets the short summary of the book.
    /// </summary>
    [Required]
    [MaxLength(BookConstraints.ShortSummaryLength)]
    [Comment("Short summary of the book. It is required and has a maximum length as defined by BookConstraints.")]
    public string ShortSummary { get; set; }

    /// <summary>
    /// Gets or sets the full summary of the book.
    /// </summary>
    [Required]
    [MaxLength(BookConstraints.FullSummaryLength)]
    [Comment("Full summary of the book. It is required and has a maximum length as defined by BookConstraints.")]
    public string FullSummary { get; set; }
}
