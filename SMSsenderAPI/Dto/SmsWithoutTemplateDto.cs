namespace SMSsenderAPI.Dto
{
    public class SmsWithoutTemplateDto
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public string PhoneNumber { get; set; }
        //public DateTime DateTime { get; set; } = DateTime.Now;
    }
        
}
