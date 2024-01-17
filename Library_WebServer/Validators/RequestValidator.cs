using Library_WebServer.Models.Author.Request;
using Library_WebServer.Models.Comment.Request;

namespace Library_WebServer.Validators;

public static class RequestValidator
{
    #region Consts
    private const string GuidRequestValidationError = "Field must be a Guid";
    private const string TopRequestValidationError = "Top value must be an integer greater than 0 and lower than 100";
    private const string SkipRequestValidationError = "Skip value must be an integer greater than 0";

    private const string AuthorRequestBaseModelValidationError = "Author FirstName and LastName must be a non-empty string";
    private const string AuthorRequestUpdateModelValidationError = "Author FirstName and LastName must be a non-empty string and the Id must be a Guid";

    private const string CommentRequestBaseModelValidationError = "UserId and PublicationId must bea Guid, Grade mush be an integer between 0 and 5";
    private const string CommentRequestUpdateModelValidationError = "Id, UserId and PublicationId must bea Guid, Grade mush be an integer between 0 and 5";
    #endregion

    #region BasicTypes
    public static bool IsValidGuid(this string model, out string message)
        => GetValidation<string>(IsValidGuidString, model, GuidRequestValidationError, out message);

    public static bool IsValidTop(this string model, out string message)
         => GetValidation<string>(IsValidTopString, model, TopRequestValidationError, out message);

    public static bool IsValidSkip(this string model, out string message)
        => GetValidation<string>(IsValidSkipString, model, SkipRequestValidationError, out message);
    #endregion

    #region Author
    public static bool IsValid(this AuthorRequestBaseModel model, out string message)
        => GetValidation(x => !string.IsNullOrEmpty(x.LastName) && !string.IsNullOrEmpty(x.FirstName),
            model, AuthorRequestBaseModelValidationError, out message);

    public static bool IsValid(this AuthorRequestUpdateModel model, out string message)
        => GetValidation(x => !string.IsNullOrEmpty(x.LastName) && !string.IsNullOrEmpty(x.FirstName) && IsValidGuidString(x.Id),
            model, AuthorRequestUpdateModelValidationError, out message);
    #endregion

    #region Comment
    public static bool IsValid(this CommentRequestBaseModel model, out string message)
       => GetValidation(x => IsValidGradeString(x.Grade) && IsValidGuidString(x.PublicationId) && IsValidGuidString(x.UserId),
            model, CommentRequestBaseModelValidationError, out message);

    public static bool IsValid(this CommentRequestUpdateModel model, out string message)
         => GetValidation(x => IsValidGradeString(x.Grade) && IsValidGuidString(x.PublicationId) && IsValidGuidString(x.UserId) && IsValidGuidString(x.Id),
            model, CommentRequestUpdateModelValidationError, out message);
    #endregion

    #region Validators
    private static bool IsValidPhoneNumber(string input)
        => string.IsNullOrWhiteSpace(input); //TODO: Add proper validation

    private static bool IsValidEnum<T>(string input)
        where T : struct
        => !string.IsNullOrWhiteSpace(input)
            && Enum.TryParse<T>(input, out _);

    private static bool IsValidEmail(string input)
        => !string.IsNullOrWhiteSpace(input)
            && input.Length > 3
            && input.Contains('@', StringComparison.OrdinalIgnoreCase);
    private static bool IsValidGuidString(string input)
        => !string.IsNullOrWhiteSpace(input)
            && Guid.TryParse(input, out _);

    private static bool IsValidTopString(string input)
    {
        bool parseResult = int.TryParse(input, out int topInt);

        return !string.IsNullOrWhiteSpace(input)
                && parseResult && topInt > 0 && topInt < 100;
    }

    private static bool IsValidSkipString(string input)
    {
        bool parseResult = int.TryParse(input, out int skipInt);

        return !string.IsNullOrWhiteSpace(input)
                && parseResult && skipInt > 0;
    }

    private static bool IsValidGradeString(string input)
    {
        bool parseResult = ushort.TryParse(input, out ushort gradeInt);

        return !string.IsNullOrWhiteSpace(input)
                && parseResult && gradeInt >= 0 && gradeInt <= 5;
    }
    #endregion

    private static bool GetValidation<T>(Predicate<T> predicate, T model, string error, out string message)
    {
        bool validation = predicate(model);

        message = validation
        ? ""
        : error;

        return validation;
    }
}
