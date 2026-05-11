using SMSsenderAPI.Models;

namespace SMSsenderAPI.Services
{
    internal class SmsSendService : ISmsSendService
    {
        public async Task<string> Send(string mobileNumber, string message)
        {
            var client = new HttpClient();

            var asdasd = $"asdasd{mobileNumber}";
            var url = string.Format("http://192.168.22.12:8075/api/Message/SmsSent?phone={0}&message={1}&applicationId=10", mobileNumber, message);
            client.Timeout = TimeSpan.FromSeconds(60);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer r7H]*eVaD0[4Ke5?'J.:.KOAmb");
            var response = await client.GetAsync(url);

            var result = response.Content.ReadAsStringAsync();

            Console.WriteLine(result);

            return null;
        }
    }
}
