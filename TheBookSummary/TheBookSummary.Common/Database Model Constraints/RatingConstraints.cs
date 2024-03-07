namespace TheBookSummary.Common.Database_Model_Constraints;

public static class RatingConstraints
{
    public const int MinStarRating = 0;

    public const int MaxStarRating = 10;

    public const string RequiredMessage = "A {0} is Required!";

    public const string InvalidRatingGiven = "{0} should be between {2} and {1}";
}
