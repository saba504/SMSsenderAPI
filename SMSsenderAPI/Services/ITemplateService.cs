using SMSsenderAPI.Models;

namespace SMSsenderAPI.Services
{
    public interface ITemplateService
    {
        Task<List<Template>> GetAllTemplate();
        Task<Template?> GetSingleTemplate(int id);
        Task<List<Template>> AddTemplate(Template template);
        Task<List<Template>?> UpdateTemplate(int id, Template request);
        Task<List<Template>?> DeleteTemplate(int id);
    }
}
