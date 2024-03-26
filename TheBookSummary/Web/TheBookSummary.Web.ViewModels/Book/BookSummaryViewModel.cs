namespace TheBookSummary.Web.ViewModels.Book;

using System.ComponentModel.DataAnnotations;

using AutoMapper;

using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services.Mapping;

public class BookSummaryViewModel : IMapFrom<BookSummary>, IHaveCustomMappings
{
    [Display( Name ="Short summary")]
    public string ShortSummary { get; set; }

    [Display(Name = "Full summary")]
    public string FullSummary { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
        configuration.CreateMap<BookSummary, BookSummaryViewModel>()
            .ForMember(
                dst => dst.ShortSummary,
                opr => opr.MapFrom(
                    src => src.ShortSummary))
            .ForMember(
                dst => dst.FullSummary,
                opt => opt.MapFrom(
                    src => src.FullSummary));
    }
}
