using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSsenderAPI.Models;
using SMSsenderAPI.Services;

namespace SMSsenderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsesController : ControllerBase
    {
        private readonly ISmsService _smsService;

        public SmsesController(ISmsService smsService)
        {
            _smsService = smsService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Sms>>> GetAllHeroes()
        {
            return await _smsService.GetAllSms();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sms>> GetSingleSms(int id)
        {
            var result = await _smsService.GetSingleSms(id);
            if (result is null)
                return NotFound("Sms not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Sms>>> AddSms(Sms sms)
        {
            var result = await _smsService.AddSms(sms);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Sms>>> UpdateSms(int id, Sms request)
        {
            var result = await _smsService.UpdateSms(id, request);
            if (result is null)
                return NotFound("Sms not found.");

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Sms>>> DeleteSms(int id)
        {
            var result = await _smsService.DeleteSms(id);
            if (result is null)
                return NotFound("Sms not found.");

            return Ok(result);
        }
    }
}
