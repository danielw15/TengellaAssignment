using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tengella.Survey.Data.Repository;
using Tengella.Survey.WebApp.Models;
using Tengella.Survey.WebApp.ServiceInterface;

namespace Tengella.Survey.WebApp.Service
{

    public class StatisticsService : IStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<StatisticsService> _logger;

        public StatisticsService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<StatisticsService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<SurveySummaryViewModel>> GetSurveySummariesAsync()
        {
            var submissions = await _unitOfWork.Submissions.GetAllAsync(includeProperties: true);
            var answers = await _unitOfWork.Answers.GetAllAsync(includeProperties: true);
            


            foreach (var submission in submissions)
            {
                _logger.LogInformation("Submission ID: {SubmissionId}, SurveyObject ID: {SurveyObjectId}, Answer Count: {AnswerCount}",
                    submission.SubmissionId,
                    submission.SurveyObjectId,
                    submission.Answers?.Count);
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
                    AverageAnswersPerSubmission = answers.Count() // Handle null Answers
                }).ToList();

            _logger.LogInformation("Grouped submissions count: {Count}", groupedSubmissions.Count);

            return groupedSubmissions;
        }
    }
}
