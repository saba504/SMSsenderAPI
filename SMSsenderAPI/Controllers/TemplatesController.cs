using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSsenderAPI.Models;
using SMSsenderAPI.Services;

namespace SMSsenderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateService _templateService;

        public TemplatesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Template>>> GetAllTemplate()
        {
            return await _templateService.GetAllTemplate();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sms>> GetSingleTemplate(int id)
        {
            var result = await _templateService.GetSingleTemplate(id);
            if (result is null)
                return NotFound("Template not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Sms>>> AddTemplate(Template template)
        {
            var result = await _templateService.AddTemplate(template);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Template>>> UpdateTemplate(int id, Template request)
        {
            var result = await _templateService.UpdateTemplate(id, request);
            if (result is null)
                return NotFound("Template not found.");

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Template>>> DeleteTemplate(int id)
        {
            var result = await _templateService.DeleteTemplate(id);
            if (result is null)
                return NotFound("Template not found.");

            return Ok(result);
        }
    }
}
