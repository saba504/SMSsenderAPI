using SMSsenderAPI.Models;

namespace SMSsenderAPI.Services
{
    public interface IEvaluationService
    {
        Task<Guid> CreateAsync(
            CreateEvaluationRequest request,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<EvaluationDto>> GetAsync(
            GetEvaluationsRequest request,
            CancellationToken cancellationToken = default);
    }
}
