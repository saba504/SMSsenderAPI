using Microsoft.AspNetCore.Mvc;
using SMSsenderAPI.Models;
using SMSsenderAPI.Services;

namespace SMSsenderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class EvaluationsController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationsController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpPost("evaluations")]
        public async Task<IActionResult> CreateEvaluation(
            string applicationId,
            [FromBody] CreateEvaluationRequestDto request,
            CancellationToken cancellationToken)
        {
            var evaluationId = await _evaluationService.CreateAsync(
                new CreateEvaluationRequest(
                    ApplicationType: "1",
                    ApplicationId: "1",
                    TargetType: EvaluationTargetType.Operator,
                    TargetId: request.TargetId,
                    TargetName: request.TargetName,
                    CustomerPhoneNumber: request.CustomerPhoneNumber),
                cancellationToken);

            return Ok(new { Id = evaluationId });
        }

        [HttpGet("{applicationId}/evaluations")]
        public async Task<IActionResult> GetEvaluations(
            string applicationId,
            [FromQuery] string? applicationType,
            [FromQuery] EvaluationTargetType? targetType,
            [FromQuery] string? targetId,
            [FromQuery] string? customerPhoneNumber,
            [FromQuery] EvaluationStatus? status,
            [FromQuery] DateTime? createdFromUtc,
            [FromQuery] DateTime? createdToUtc,
            CancellationToken cancellationToken)
        {
            var result = await _evaluationService.GetAsync(
                new GetEvaluationsRequest(
                    ApplicationType: applicationType,
                    ApplicationId: applicationId,
                    TargetType: targetType,
                    TargetId: targetId,
                    CustomerPhoneNumber: customerPhoneNumber,
                    Status: status,
                    CreatedFromUtc: createdFromUtc,
                    CreatedToUtc: createdToUtc),
                cancellationToken);

            return Ok(result);
        }
    }
}
