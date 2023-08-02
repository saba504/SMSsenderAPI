using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMSsenderAPI.Data;
using SMSsenderAPI.Models;

namespace SMSsenderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly DataContext dbContext;
        public TemplatesController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTemplate()
        {
            return Ok(await dbContext.Templates.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddTemplate(AddTemplateRequest addTemplateRequest)
        {
            var template = new Template()
            {
                Name = addTemplateRequest.Name,
                Text = addTemplateRequest.Text,
            };

            await dbContext.Templates.AddAsync(template);
            await dbContext.SaveChangesAsync();

            return Ok(template);
        }
    }
}
