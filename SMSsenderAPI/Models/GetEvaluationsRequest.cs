namespace SMSsenderAPI.Models
{
    public sealed record GetEvaluationsRequest(
        string? ApplicationType = null,
        string? ApplicationId = null,
        EvaluationTargetType? TargetType = null,
        string? TargetId = null,
        string? CustomerPhoneNumber = null,
        EvaluationStatus? Status = null,
        DateTime? CreatedFromUtc = null,
        DateTime? CreatedToUtc = null
    );
}
