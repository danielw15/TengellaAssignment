using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tengella.Survey.Data;
using Tengella.Survey.Data.Exceptions;
using Tengella.Survey.Data.Models;
using Tengella.Survey.Data.Repository;
using Tengella.Survey.WebApp.Models;
using Tengella.Survey.WebApp.ServiceInterface;
using static System.Net.WebRequestMethods;

namespace Tengella.Survey.WebApp.Service
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string _baseUrl = "https://localhost:7128";

        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SurveyObject>> GetAllSurveyAsync()
        {
            var surveys = await _unitOfWork.Surveys.GetAllAsync();
            return surveys.ToList();
        }

        public async Task<SurveyObject> GetSurveyAsync(int id)
        {
            var survey = await _unitOfWork.Surveys.GetAsync(s => s.SurveyObjectId == id);
            if (survey == null)
            {
                throw new SurveyNotFoundException(id);
            }
            return survey;
        }

        public async Task SaveSurveyAsync()
        {
            await _unitOfWork.SaveAsync();
        }

        public async Task SubmitSurveyAsync(SurveyObject survey)
        {
            await _unitOfWork.Surveys.CreateAsync(survey);
            await _unitOfWork.SaveAsync();
        }
        public async void UpdateSurvey(SurveyObject survey)
        {
            await _unitOfWork.Surveys.UpdateAsync(survey);
            await _unitOfWork.SaveAsync();
        }

        public string GenerateSurveyUrl(int surveyId)
        {
            var uniqueToken = Guid.NewGuid().ToString();
            return $"{_baseUrl}/take_survey/{surveyId}/{uniqueToken}";
        }

        public SurveyObject MapSurveyViewModelToSurveyObject(SurveyViewModel model)
        {
            var survey = _mapper.Map<SurveyObject>(model);
            for (int i = 0; i < model.SurveyQuestions.Count; i++)
            {
                var question = _mapper.Map<Question>(model.SurveyQuestions[i]);

                survey.Questions.Add(question);
            }
            return survey;
        }

        public async Task<DoSurveyViewModel> GetDoSurveyViewModelAsync(int surveyId, string uniqueToken)
        {
            if (surveyId == 0)
            {
                throw new SurveyNotFoundException(surveyId);
            }
            var submission = await _unitOfWork.Submissions.GetAsync(s => s.SurveyObjectId == surveyId && s.UniqueToken == uniqueToken);

            if (submission == null)
            {
                throw new SubmissionNotFoundException(surveyId, uniqueToken);
            }

            var surveyObject = await _unitOfWork.Surveys.GetAsync(s => s.SurveyObjectId == surveyId);

            if (surveyObject == null)
            {
                throw new SurveyNotFoundException(surveyId);
            }
            var viewModel = new DoSurveyViewModel
            {
                SubmissionId = submission.SubmissionId,
                SurveyObjectId = surveyObject.SurveyObjectId,
                UniqueToken = submission.UniqueToken,
                SurveyTitle = surveyObject.SurveyTitle,
                SurveyDescription = surveyObject.SurveyDescription,
                SurveyQuestions = surveyObject.Questions.Select(q => new QuestionViewModel
                {
                    QuestionId = q.QuestionId,
                    QuestionName = q.QuestionName,
                    QuestionType = q.QuestionType,
                    QuestionPosition = q.QuestionPosition,
                    SurveyObjectId = q.SurveyObjectId,
                    QuestionChoices = q.Choices.Select(c => new ChoiceViewModel
                    {
                        ChoiceId = c.ChoiceId,
                        ChoicePosition = c.ChoicePosition,
                        ChoiceText = c.ChoiceText,
                        QuestionId = c.QuestionId,
                    }).ToList(),
                }).ToList(),
                SurveyAnswers = _mapper.Map<List<AnswerViewModel>>(submission.Answers).ToList()
            };
            if (viewModel.SurveyQuestions.Count > viewModel.SurveyAnswers.Count)
            {
                for (int i = viewModel.SurveyAnswers.Count; i < viewModel.SurveyQuestions.Count; i++)
                {
                    viewModel.SurveyAnswers.Add(new AnswerViewModel());
                }
            }
            return viewModel;
        }
        public async Task<SendSurveyViewModel> GetSendSurveyViewModelAsync(int surveyId)
        {
            var survey = await GetSurveyAsync(surveyId);
            var questionList = _mapper.Map<List<QuestionViewModel>>(survey.Questions.ToList());
            int i = 0;
            foreach (var question in survey.Questions)
            {
                questionList[i].QuestionChoices = _mapper.Map<List<ChoiceViewModel>>(question.Choices).ToList();
                i++;
            }

            var addChoiceViewModel = new AddChoiceViewModel
            {
                SurveyObjectId = surveyId,
                Questions = questionList
            };

            var userList = new List<UserViewModel> { new UserViewModel() };

            var viewModel = new SendSurveyViewModel
            {
                SurveyObjectId = surveyId,
                SurveyTitle = survey.SurveyTitle,
                SurveyDescription = survey.SurveyDescription,
                AddChoice = addChoiceViewModel,
                Subject = "",
                Message = "",
                Users = userList
            };

            return viewModel;
        }


    }
}
