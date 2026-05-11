using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMSsenderAPI.Dto;
using SMSsenderAPI.Models;
using SMSsenderAPI.Paging;
using SMSsenderAPI.Services;
using System.Diagnostics.Contracts;

namespace SMSsenderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")] //ავტორიზაცია
    public class SmsesController : ControllerBase
    {
        private readonly ISmsService _smsService;
        private readonly ISmsSendService _smsSendService;
        private readonly IMapper _mapper;

        public SmsesController(ISmsService smsService,ISmsSendService smsSendService, IMapper mapper)
        {
            _smsService = smsService;
            _smsSendService = smsSendService;
            this._mapper = mapper;
        }

        [HttpGet("withfilter")]
        public async Task<IEnumerable<Sms>> GetSmsWithFilter([FromQuery] SmsFilterDto sms)
        {
            return await _smsService.GetSmsWithFilter(sms);
        }


        [HttpGet]
        public async Task<ActionResult<List<Sms>>> GetAllSms()
        {
            return await _smsService.GetAllSms();
        }

        //[HttpGet("withtype")]
        //public async Task<List<Sms>> GetSmsList([FromQuery] PageRequest pageRequest)
        //{
        //    return await _smsService.GetClientsList(pageRequest);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Sms>> GetSingleSms(int id)
        {
            var result = await _smsService.GetSingleSms(id);
            if (result is null)
                return NotFound("Sms not found.");

            return Ok(result);
        }

        [HttpPost("AddSmsWithoutTemplate")]  //შაბლონის გარეშე გაგზავნა
        
        public async Task<IActionResult> AddSmsWithoutTemplate([FromBody] SmsWithoutTemplateDto smsWithoutTemplateDto)
        {
            var model = _mapper.Map<Sms>(smsWithoutTemplateDto);

            await _smsService.AddSmsWithoutTemplate(model);
            await _smsSendService.Send(smsWithoutTemplateDto.PhoneNumber, smsWithoutTemplateDto.Text);

            return Ok();
        }

        //[HttpPost("AddSms/{TemplateId}")] //შაბლონით გაგზავნა
        //public async Task<IActionResult> AddSms([FromBody] SmsDto smsDto, [FromRoute] int TemplateId)
        //{
        //    var model = _mapper.Map<Sms>(smsDto);

        //    await _smsService.AddSms(model, TemplateId);
        //    await _smsSendService.Send(smsDto.PhoneNumber, smsDto.);

        //    return Ok();
        //}


        //[HttpPost]
        //public async Task<ActionResult<List<Sms>>> AddSmsWithoutTemplate(Sms sms)
        //{
        //    //var result = await _smsService.AddSmsWithoutTemplate(sms);
        //    //return Ok(result);
        //}


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
