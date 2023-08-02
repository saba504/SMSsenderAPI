using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMSsenderAPI.Data;
using SMSsenderAPI.Models;

namespace SMSsenderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsesController : ControllerBase
    {
        private readonly DataContext dbContext;
        public SmsesController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetSms()
        {
            return Ok(await dbContext.Smses.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddModel(AddSmsRequest addModelRequest)
        {
            var sms = new Sms()
            {
                Name = addModelRequest.Name,
                Text = addModelRequest.Text,
                Author = addModelRequest.Author,
                PhoneNumber = addModelRequest.PhoneNumber,
                DateTime = addModelRequest.DateTime,
            };

            await dbContext.Smses.AddAsync(sms);
            await dbContext.SaveChangesAsync();

            return Ok(sms);
        }

    }
}
