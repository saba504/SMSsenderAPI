namespace SMSsenderAPI.Dto
{
    public class SmsFilterDto
    {
        public string? PhoneNumber { get; set; } = "";
        public DateTime DateTime { get; set; } = new DateTime(2020, 1, 1);
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1); 
    }
}
