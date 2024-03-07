namespace TheBookSummary.Common.ViewModelConstraints;

public static class BookViewModelConstraints
{
    public const int BookNameMinLength = 5;

    public const int BookNameMaxLength = 100;

    public const int BookShortSummaryMinLength = 10;

    public const int BookShortSummaryMaxLength = 500;

    public const int BookFullSummaryMinLength = 10;

    public const int BookFullSummaryMaxLength = 2000;

    public const string InvalidNameLength = "The {0} should be between {2} and {1} characters long!";

    public const string InvalidSummaryLength = "The {0} must be between {2} and {1} characters!";

    public const string RequiredMessage = "{0} is Required!";
}
