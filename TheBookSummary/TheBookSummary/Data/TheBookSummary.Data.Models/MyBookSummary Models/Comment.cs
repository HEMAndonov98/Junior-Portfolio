namespace TheBookSummary.Data.Models.MyBookSummary_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using TheBookSummary.Common.Database_Model_Constraints;
    using TheBookSummary.Data.Common.Models;
    using TheBookSummary.Data.Models.Identity;

    /// <summary>
    /// Represents a model for storing comments related to books in the database.
    /// </summary>
    public class Comment : BaseDeletableModel<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class.
        /// </summary>
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets the text of the comment.
        /// </summary>
        [Required]
        [MaxLength(CommentConstraints.CommentTextMaxLength)]
        [Comment("Text of the comment. It is required and has a maximum length as defined by CommentConstraints.")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the associated book.
        /// </summary>
        [ForeignKey(nameof(Book))]
        [Comment("Foreign key referencing the associated book.")]
        public string BookId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property representing the associated book.
        /// </summary>
        [Comment("Navigation property representing the associated book.")]
        public Book Book { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the user who made the comment.
        /// </summary>
        [ForeignKey(nameof(ApplicationUser))]
        [Comment("Foreign key referencing the user who made the comment.")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property representing the user who made the comment.
        /// </summary>
        [Comment("Navigation property representing the user who made the comment.")]
        public ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Gets or sets the collection of replies associated with the comment.
        /// </summary>
        [InverseProperty(nameof(Reply.ParentComment))]
        [Comment("Collection of replies associated with the comment.")]
        public ICollection<Reply> Replies { get; set; }
    }
}
