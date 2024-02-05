namespace TheBookSummary.Data.Models.MyBookSummary_Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
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

        /// <summary>
        /// Gets or sets the name of the book.
        /// </summary>
        [Required]
        [MaxLength(BookConstraints.NameLength)]
        [Comment("Name of the book. It is required and has a maximum length as defined by BookConstraints.")]
        public string BookName { get; set; }
    }
}