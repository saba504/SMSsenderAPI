using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace SMSsenderAPI.Models
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
