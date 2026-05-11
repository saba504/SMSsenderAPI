using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMSsenderAPI.Data;
using SMSsenderAPI.Dto;
using SMSsenderAPI.Extensions;
using SMSsenderAPI.Models;
using SMSsenderAPI.Paging;
using System.Diagnostics.Contracts;

namespace SMSsenderAPI.Services
{
    public class SmsService : ISmsService
    {
        private readonly DataContext _context;
        private readonly IMapper mapper;

        public SmsService(DataContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }



        public async Task<List<Sms>> GetSmsWithFilter(SmsFilterDto sms)
        {


            if (string.IsNullOrEmpty(sms.PhoneNumber))
            {
                sms.PhoneNumber = "";
            }


            var smses = await _context.Smses
                               .OrderByDescending(x => x.Id)
                               .Where(x => (sms.PhoneNumber == "" || x.PhoneNumber == sms.PhoneNumber)
                               && (x.DateTime >= sms.DateTime && x.DateTime <= sms.EndDate))
                               .ToListAsync();

            return smses;
        }




        public async Task AddSmsWithoutTemplate(Sms sms)  //შაბლონის გარეშე გაგზავნა
        {
            {
                var smssend = mapper.Map<Sms>(sms);
                var sms2 = new Sms()
                {
                    Text = smssend.Text,
                    PhoneNumber = smssend.PhoneNumber,
                    DateTime = DateTime.Now,
                Author = smssend.Author,
                };

                await _context.Smses.AddAsync(sms);
                await _context.SaveChangesAsync();

                //await _context.Sms2Template.AddAsync(new Sms2Template()
                //{
                //    SmsId = sms.Id,
                //});
                //await _context.SaveChangesAsync();
            }
        }


        //public async Task AddSms(Sms sms, int TemplateID)
        //{
        //    var smssend = mapper.Map<Sms>(sms);
        //    var sms2 = new Sms()
        //    {
        //        Text = smssend.Text,
        //        // MessageId = result,
        //        PhoneNumber = smssend.PhoneNumber,
        //        DateTime = DateTime.Now,
        //        Author = smssend.Author,
        //    };

        //    await _context.Smses.AddAsync(sms);
        //    await _context.SaveChangesAsync();

        //    await _context.Sms2Template.AddAsync(new Sms2Template()
        //    {
        //        SmsId = sms.Id,
        //        TemplateId = TemplateID
        //    });
        //    await _context.SaveChangesAsync();
        //}

        public async Task<List<Sms>?> DeleteSms(int id)
        {
            var sms = await _context.Smses.FindAsync(id);
            if (sms is null)
                return null;

            _context.Smses.Remove(sms);
            await _context.SaveChangesAsync();

            return await _context.Smses.ToListAsync();
        }


        public async Task<List<Sms?>> GetAllSms()
        {
            var smses = await _context.Smses.OrderByDescending(x => x.DateTime)  //OrderByDescending(x => x.DateTime) ამით ალაგებს orderBy
            .ToListAsync();
            return smses;
        }

        

        public async Task<Sms?> GetSingleSms(int id)
        {
            var sms = await _context.Smses.FindAsync(id);
            if (sms is null)
                return null;

            return sms;
        }



        





        public async Task<List<Sms>?> UpdateSms(int id, Sms request)
        {
            var sms = await _context.Smses.FindAsync(id);
            if (sms is null)
                return null;

            //sms.Name = request.Name;
            sms.Text = request.Text;
            sms.Author = request.Author;
            sms.PhoneNumber = request.PhoneNumber;
            sms.DateTime = request.DateTime;


            await _context.SaveChangesAsync();

            return await _context.Smses.ToListAsync();
        }

        
    }
}
