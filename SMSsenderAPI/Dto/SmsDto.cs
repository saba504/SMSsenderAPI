using SMSsenderAPI.Models;

namespace SMSsenderAPI.Dto
{
    public class SmsDto
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        //public string Text { get; set; }
        public string Author { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? aDate { get; set; }

    }
}
