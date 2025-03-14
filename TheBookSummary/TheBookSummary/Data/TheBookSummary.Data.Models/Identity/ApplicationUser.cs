// ReSharper disable VirtualMemberCallInConstructor
namespace TheBookSummary.Data.Models.Identity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using TheBookSummary.Data.Common.Models;
    using TheBookSummary.Common.Database_Model_Constraints;

    /// <summary>
    /// Represents a model for application users in the system.
    /// </summary>
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUser"/> class.
        /// </summary>
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        [MaxLength(ApplicationUserConstraints.FirstNameMaxLength)]
        [Comment("First name of the user. It has a maximum length as defined by ApplicationUserConstraints.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        [MaxLength(ApplicationUserConstraints.LastNameMaxLength)]
        [Comment("Last name of the user. It has a maximum length as defined by ApplicationUserConstraints.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the number of summaries read by the user.
        /// </summary>
        [Comment("Number of summaries read by the user.")]
        public int SummariesRead { get; set; }

        /// <summary>
        /// Gets or sets the number of ratings given by the user.
        /// </summary>
        [Comment("Number of ratings given by the user.")]
        public int RatingsGiven { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was created.
        /// </summary>
        [Comment("Date and time when the user was created.")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was last modified.
        /// </summary>
        [Comment("Date and time when the user was last modified.")]
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is deleted.
        /// </summary>
        [Comment("Indicates whether the user is deleted.")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was deleted.
        /// </summary>
        [Comment("Date and time when the user was deleted.")]
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// Gets or sets the collection of roles assigned to the user.
        /// </summary>
        [Comment("Collection of roles assigned to the user.")]
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        /// <summary>
        /// Gets or sets the collection of claims associated with the user.
        /// </summary>
        [Comment("Collection of claims associated with the user.")]
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        /// <summary>
        /// Gets or sets the collection of external logins associated with the user.
        /// </summary>
        [Comment("Collection of external logins associated with the user.")]
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
