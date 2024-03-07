namespace TheBookSummary.Data.Models.MyBookSummary_Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using TheBookSummary.Common.Database_Model_Constraints;
    using TheBookSummary.Data.Common.Models;
    using TheBookSummary.Data.Models.Identity;

    /// <summary>
    /// Represents a model for storing replies related to comments in the database.
    /// </summary>
    public class Reply : BaseDeletableModel<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reply"/> class.
        /// </summary>
        public Reply()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets the text of the reply.
        /// </summary>
        [Required]
        [MaxLength(ReplyModelConstraints.ReplyTextMaxLength)]
        [Comment("Text of the reply. It is required and has a maximum length as defined by ReplyModelConstraints.")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the parent comment.
        /// </summary>
        [ForeignKey(nameof(ParentComment))]
        [Comment("Foreign key referencing the parent comment.")]
        public string ParentCommentId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property representing the parent comment.
        /// </summary>
        [Comment("Navigation property representing the parent comment.")]
        public Comment ParentComment { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the parent reply.
        /// </summary>
        [ForeignKey(nameof(ParentReply))]
        [Comment("Foreign key referencing the parent reply.")]
        public string ParentReplyId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property representing the parent reply.
        /// </summary>
        [Comment("Navigation property representing the parent reply.")]
        public Reply ParentReply { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the user who made the reply.
        /// </summary>
        [ForeignKey(nameof(ApplicationUser))]
        [Comment("Foreign key referencing the user who made the reply.")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property representing the user who made the reply.
        /// </summary>
        [Comment("Navigation property representing the user who made the reply.")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
