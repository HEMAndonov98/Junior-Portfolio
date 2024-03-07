namespace TheBookSummary.Common.Database_Model_Constraints;

public static class CommentConstraints
{
    public const int CommentTextMaxLength = 1000;

    public const int CommentTextMinLength = 10;

    public const string RequiredMessage = "A {0} is Required!";

    public const string InvalidCommentLength = "The {0} should be between {2} and {1} characters long!";
}
