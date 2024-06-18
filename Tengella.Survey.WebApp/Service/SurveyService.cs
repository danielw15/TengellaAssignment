using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.Models;
using Tengella.Survey.WebApp.ServiceInterface;

namespace Tengella.Survey.WebApp.Service
{
    public class SurveyService : ISurveyService
    {
        private readonly SurveyDbContext _context;
        public SurveyService(SurveyDbContext context)
        {
            _context = context;
        }
        public async Task<List<SurveyObject>> GetAllSurveyAsync()
        {
            var surveyDbContext = _context.SurveyObjects
                .Include(s => s.User)
                .Include(s => s.Questions);
            return await surveyDbContext.ToListAsync();
        }

        public async Task<SurveyObject> GetSurveyAsync(int? id)
        { 
            var surveyObject = await _context.SurveyObjects
                .Include(s => s.Questions)
                .ThenInclude(q => q.Choices)
                .FirstOrDefaultAsync(m => m.SurveyObjectId == id);
            
            return surveyObject;
        }

        public async Task SaveSurveyAsync()
        {
            _context.SaveChangesAsync();
        }

        public async Task SubmitSurveyAsync(SurveyObject survey)
        {
            _context.Add(survey);
        }

        
    }
}
