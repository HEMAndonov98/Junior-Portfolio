namespace TheBookSummary.Web.ViewModels.Rating;

using AutoMapper;
using TheBookSummary.Services.Mapping;

public class RatingViewModel : IMapFrom<Data.Models.MyBookSummary_Models.Rating>, IHaveCustomMappings
{
    /// <summary>
    /// Gets or sets the rating given to the book.
    /// </summary>
    public int Stars { get; set; }

    /// <summary>
    /// Gets or sets the ID of the Book that is connected to this rating.
    /// </summary>
    public string BookId { get; set; }

    /// <inheritdoc />
    public void CreateMappings(IProfileExpression configuration)
    {
        configuration.CreateMap<Data.Models.MyBookSummary_Models.Rating, RatingViewModel>()
            .ForMember(
                dst => dst.Stars,
                opt => opt.MapFrom(
                    src => src.Stars))
            .ForMember(
                dst => dst.BookId,
                opt => opt.MapFrom(
                    src => src.BookId));
    }
}
