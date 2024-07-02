using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Repository;
using Tengella.Survey.WebApp.Models;
using Tengella.Survey.WebApp.ServiceInterface;

namespace Tengella.Survey.WebApp.Service
{

    public class StatisticsService : IStatisticsService
    {
        private readonly SurveyDbContext _surveyDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<StatisticsService> _logger;

        public StatisticsService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<StatisticsService> logger, SurveyDbContext surveyDbContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _surveyDbContext = surveyDbContext;
        }

        //Currently do not have a way to implement this method without using DbContext and Eager Loading. UoW pattern broken here.
        public async Task<List<SurveySummaryViewModel>> GetSurveySummariesAsync()
        {
            // Fetch all submissions with related Answers and SurveyObject
            var submissions = await _surveyDbContext.Submissions
             .Include(s => s.Answers)
             .Include(s => s.SurveyObject)
             .ToListAsync();

            _logger.LogInformation("Fetched {Count} submissions from the database.", submissions.Count());

            foreach (var submission in submissions)
            {
                _logger.LogInformation("Submission ID: {SubmissionId}, SurveyObject ID: {SurveyObjectId}, Answer Count: {AnswerCount}",
                    submission.SubmissionId,
                    submission.SurveyObject?.SurveyObjectId ?? 0, // Ensure null-coalescing operator for SurveyObjectId
                    submission.Answers?.Count ?? 0); // Ensure null-coalescing operator for Answer Count
            }

            var groupedSubmissions = submissions
                .Where(s => s.SurveyObject != null) // Ensure SurveyObject is not null
                .GroupBy(s => s.SurveyObject)
                .Select(g => new SurveySummaryViewModel
                {
                    SurveyObjectId = g.Key?.SurveyObjectId ?? 0, // Use null-coalescing operator
                    SurveyTitle = g.Key?.SurveyTitle ?? "Unknown Title", // Use null-coalescing operator
                    SurveyDescription = g.Key?.SurveyDescription ?? "No Description", // Use null-coalescing operator
                    TotalSubmissions = g.Count(),
                    AverageAnswersPerSubmission = g.Average(s => s.Answers?.Count ?? 0) // Handle null Answers
                }).ToList();

            _logger.LogInformation("Grouped submissions count: {Count}", groupedSubmissions.Count);

            return groupedSubmissions;
        }
    }
}
