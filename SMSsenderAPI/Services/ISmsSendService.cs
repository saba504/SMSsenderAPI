namespace SMSsenderAPI.Services
{
    public interface ISmsSendService
    {
        Task<string> Send(string mobileNumber, string message);
    }
}
