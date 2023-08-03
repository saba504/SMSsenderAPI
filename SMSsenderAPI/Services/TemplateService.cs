using Microsoft.EntityFrameworkCore;
using SMSsenderAPI.Data;
using SMSsenderAPI.Models;

namespace SMSsenderAPI.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly DataContext _context;

        public TemplateService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Template>> AddTemplate(Template template)
        {
            _context.Templates.Add(template);
            await _context.SaveChangesAsync();
            return await _context.Templates.ToListAsync();
        }

        public async Task<List<Template>?> DeleteTemplate(int id)
        {
            var template = await _context.Templates.FindAsync(id);
            if (template is null)
                return null;

            _context.Templates.Remove(template);
            await _context.SaveChangesAsync();

            return await _context.Templates.ToListAsync();
        }


        public async Task<List<Template>> GetAllTemplate()
        {
            var templates = await _context.Templates.ToListAsync();
            return templates;
        }

        public async Task<Template?> GetSingleTemplate(int id)
        {
            var template = await _context.Templates.FindAsync(id);
            if (template is null)
                return null;

            return template;
        }

        public async Task<List<Template>?> UpdateTemplate(int id, Template request)
        {
            var template = await _context.Templates.FindAsync(id);
            if (template is null)
                return null;

            template.Name = request.Name;
            template.Text = request.Text;


            await _context.SaveChangesAsync();

            return await _context.Templates.ToListAsync();
        }
    }
}
