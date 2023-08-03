using SMSsenderAPI.Models;

namespace SMSsenderAPI.Services
{
    public interface ISmsService
    {
        Task<List<Sms>> GetAllSms();
        Task<Sms?> GetSingleSms(int id);
        Task<List<Sms>> AddSms(Sms sms);
        Task<List<Sms>?> UpdateSms(int id, Sms request);
        Task<List<Sms>?> DeleteSms(int id);
    }
}
