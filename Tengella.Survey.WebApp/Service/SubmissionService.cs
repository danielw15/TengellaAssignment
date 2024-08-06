using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Exceptions;
using Tengella.Survey.Data.Models;
using Tengella.Survey.Data.Repository;
using Tengella.Survey.WebApp.ServiceInterface;

namespace Tengella.Survey.WebApp.Service
{
    public class SubmissionService : ISubmissionService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubmissionService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<Submission>> GetAllSubmissionAsync()
        {
            var submissions = await _unitOfWork.Submissions.GetAllAsync();
            
            return submissions.ToList();
        }

        public async Task<Submission> GetSubmissionAsync(int? surveyId, string uniqueToken)
        {
            var submission = await _unitOfWork.Submissions.GetAsync(m => m.SurveyObjectId == surveyId && m.UniqueToken == uniqueToken);
            if(submission == null)
            {
                throw new SubmissionNotFoundException(surveyId.GetValueOrDefault(), uniqueToken);
            }

            return submission;
        }

        public async Task SaveSubmissionAsync()
        {
            await _unitOfWork.Submissions.SaveAsync();
        }

        public async Task SubmitSubmissionAsync(Submission submission)
        {
            await _unitOfWork.Submissions.CreateAsync(submission);
            await _unitOfWork.SaveAsync();
        }

        public async void UpdateSubmission(Submission submission)
        {
            await _unitOfWork.Submissions.UpdateAsync(submission);
            await _unitOfWork.SaveAsync();
        }
        public async Task<string> CreateSubmission(int surveyId)
        {
            var surveyObject = await _unitOfWork.Surveys.GetAsync(s => s.SurveyObjectId == surveyId);
            if (surveyObject == null)
            {
                throw new SurveyNotFoundException(surveyId);
            }
            var uniqueToken = Guid.NewGuid().ToString();

            var submission = new Submission
            {
                SurveyObjectId = surveyId,
                UniqueToken = uniqueToken
            };

            await SubmitSubmissionAsync(submission);
            return uniqueToken;
        }
    }
}
