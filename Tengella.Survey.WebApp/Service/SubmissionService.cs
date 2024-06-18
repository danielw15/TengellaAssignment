using Microsoft.EntityFrameworkCore;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.ServiceInterface;

namespace Tengella.Survey.WebApp.Service
{
    public class SubmissionService : ISubmissionService
    {
        private readonly SurveyDbContext _context;
        public SubmissionService(SurveyDbContext context) 
        {
            _context = context;
        }
        public async Task<List<Submission>> GetAllSubmissionAsync()
        {
            var submissionDbContext = _context.Submissions
                .Include(s => s.Answers);
            return await submissionDbContext.ToListAsync();
        }

        public async Task<Submission> GetSubmissionAsync(int? id)
        {
            var submissionObject = await _context.Submissions
                .Include(s => s.Answers)
                .FirstOrDefaultAsync(m => m.SubmissionId == id);

            return submissionObject;
        }

        public async Task SaveSubmissionAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task SubmitSubmissionAsync(Submission submission)
        {
            await _context.AddAsync(submission);
        }
    }
}
