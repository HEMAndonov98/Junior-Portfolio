using AutoMapper;

namespace TheBookSummary.Web.ViewModels.Book;

using System.Collections.Generic;

using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Mapping;

public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
{
    public string Text { get; set; }

    public string Username { get; set; }

    public ICollection<CommentViewModel> Replies { get; set; }
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