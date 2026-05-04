namespace SMSsenderAPI.Models
{
    public sealed record CreateEvaluationRequest(
    string ApplicationType,
    string ApplicationId,
    EvaluationTargetType TargetType,
    string TargetId,
    string TargetName,
    string CustomerPhoneNumber
);
    public sealed record CreateEvaluationRequestDto(
  string TargetId,
  string TargetName,
  string CustomerPhoneNumber
);
}
