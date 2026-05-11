using SMSsenderAPI.Dto;
using SMSsenderAPI.Models;
using SMSsenderAPI.Paging;

namespace SMSsenderAPI.Services
{
    public interface ISmsService
    {
        Task<List<Sms>> GetAllSms();
        Task<Sms?> GetSingleSms(int id);
        public Task<List<Sms>> GetSmsWithFilter(SmsFilterDto sms);
        //public Task<List<Sms>> GetSmsList(PageRequest pageRequest, out PageResponse pageResponse);

        //Task AddSms(Sms sms, int TemplateID);
        Task AddSmsWithoutTemplate(Sms sms); // შაბლონის გარეშე
        Task<List<Sms>?> UpdateSms(int id, Sms request);
        Task<List<Sms>?> DeleteSms(int id);

    }
}
