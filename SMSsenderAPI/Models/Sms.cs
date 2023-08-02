namespace SMSsenderAPI.Models
{
    public class Sms
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateTime { get; set; }
    }
}
