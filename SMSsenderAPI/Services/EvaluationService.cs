using Microsoft.Extensions.Options;
using SMSsenderAPI.Models;
using System.Net.Http.Headers;
using System.Web;

namespace SMSsenderAPI.Services
{
    public sealed class EvaluationService : IEvaluationService
    {
        private readonly HttpClient _httpClient;
        private readonly EvaluationApiOptions _options;

        public EvaluationService(
            HttpClient httpClient,
            IOptions<EvaluationApiOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<Guid> CreateAsync(
            CreateEvaluationRequest request,
            CancellationToken cancellationToken = default)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, "evaluations")
            {
                Content = JsonContent.Create(request)
            };

            httpRequest.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _options.ApiKey);

            using var response = await _httpClient.SendAsync(httpRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new HttpRequestException(
                    $"Evaluation API Create failed: {(int)response.StatusCode} - {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<CreateEvaluationResponse>(cancellationToken: cancellationToken);

            return result!.Id;
        }

        public async Task<IReadOnlyList<EvaluationDto>> GetAsync(
            GetEvaluationsRequest request,
            CancellationToken cancellationToken = default)
        {
            var query = BuildQueryString(request);

            using var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"evaluations{query}");

            httpRequest.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _options.ApiKey);

            using var response = await _httpClient.SendAsync(httpRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new HttpRequestException(
                    $"Evaluation API Get failed: {(int)response.StatusCode} - {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<List<EvaluationDto>>(cancellationToken: cancellationToken);

            return result ?? new List<EvaluationDto>();
        }

        private static string BuildQueryString(GetEvaluationsRequest r)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (r.ApplicationType != null) query["applicationType"] = r.ApplicationType;
            if (r.ApplicationId != null) query["applicationId"] = r.ApplicationId;
            if (r.TargetType != null) query["targetType"] = ((int)r.TargetType).ToString();
            if (r.TargetId != null) query["targetId"] = r.TargetId;
            if (r.CustomerPhoneNumber != null) query["customerPhoneNumber"] = r.CustomerPhoneNumber;
            if (r.Status != null) query["status"] = ((int)r.Status).ToString();
            if (r.CreatedFromUtc != null) query["createdFromUtc"] = r.CreatedFromUtc.Value.ToString("O");
            if (r.CreatedToUtc != null) query["createdToUtc"] = r.CreatedToUtc.Value.ToString("O");

            var qs = query.ToString();
            return string.IsNullOrWhiteSpace(qs) ? "" : $"?{qs}";
        }

        private sealed record CreateEvaluationResponse(Guid Id);
    }
}
