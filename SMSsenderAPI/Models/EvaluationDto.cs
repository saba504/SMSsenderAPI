namespace SMSsenderAPI.Models
{
    public sealed record EvaluationDto(
        Guid Id,
        string ApplicationType,
        string ApplicationId,
        EvaluationTargetType TargetType,
        string TargetId,
        string TargetName,
        string CustomerPhoneNumber,
        int? RatingScore,
        string? Comment,
        EvaluationStatus Status,
        DateTime CreatedAtUtc
    );
}
