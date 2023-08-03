using Microsoft.EntityFrameworkCore;
using SMSsenderAPI.Data;
using SMSsenderAPI.Models;

namespace SMSsenderAPI.Services
{
    public class SmsService : ISmsService
    {
        private readonly DataContext _context;

        public SmsService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Sms>> AddSms(Sms sms)
        {
            _context.Smses.Add(sms);
            await _context.SaveChangesAsync();
            return await _context.Smses.ToListAsync();
        }

        public async Task<List<Sms>?> DeleteSms(int id)
        {
            var sms = await _context.Smses.FindAsync(id);
            if (sms is null)
                return null;

            _context.Smses.Remove(sms);
            await _context.SaveChangesAsync();

            return await _context.Smses.ToListAsync();
        }


        public async Task<List<Sms>> GetAllSms()
        {
            var smses = await _context.Smses.ToListAsync();
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

            sms.Name = request.Name;
            sms.Text = request.Text;
            sms.Author = request.Author;
            sms.PhoneNumber = request.PhoneNumber;
            sms.DateTime = request.DateTime;


            await _context.SaveChangesAsync();

            return await _context.Smses.ToListAsync();
        }

    }
}
