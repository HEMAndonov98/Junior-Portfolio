namespace TheBookSummary.Web.ViewModels.Comments;

using System.Collections.Generic;

using AutoMapper;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Mapping;

/// <summary>
/// Represents a view model for displaying comment data to the client.
/// </summary>
public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
{
    /// <summary>
    /// Gets or sets the text of the comment.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the username of the user who made the comment.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the collection of reply view models associated with the comment.
    /// </summary>
    public ICollection<CommentViewModel> Replies { get; set; }

    /// <summary>
    /// Custom mapping configuration for the comment view model.
    /// </summary>
    /// <param name="configuration">The AutoMapper profile configuration.</param>
    public void CreateMappings(IProfileExpression configuration)
    {
        configuration.CreateMap<Comment, CommentViewModel>()
            .ForMember(
                source => source.Username,
                destination => destination.MapFrom(member => member.ApplicationUser.UserName));

        configuration.CreateMap<Reply, CommentViewModel>()
            .ForMember(
                source => source.Username,
                destination => destination.MapFrom(member => member.ApplicationUser.UserName));

        configuration.CreateMap<Reply[], CommentViewModel>()
            .ForMember(
                source => source.Replies,
                destination => destination.MapFrom(member => member));
    }
}
