namespace SMSsenderAPI.Models
{
    public class AddSmsRequest
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateTime { get; set; }
    }
}
