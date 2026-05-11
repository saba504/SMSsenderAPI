using System.ComponentModel.DataAnnotations;

namespace SMSsenderAPI.Models
{
    public class Sms
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string Author { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{10}", ErrorMessage = "Phone number must contain only numbers.")]
        [MaxLength(9)]
        [MinLength(9)]
        public string PhoneNumber { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        //public bool IsDelivered { get; set; }
        //public int MessageId { get; set; }
        //public ICollection<Sms2Template>? Sms2Templates { get; set; }
    }
}
