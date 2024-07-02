using Tengella.Survey.Data.Models;
using Tengella.Survey.Data;
using Tengella.Survey.WebApp.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Tengella.Survey.Data.Repository;
using Tengella.Survey.Data.Exceptions;
using Tengella.Survey.WebApp.Models;

namespace Tengella.Survey.WebApp.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<Question>> GetAllQuestionAsync()
        {
            var question = await _unitOfWork.Questions.GetAllAsync();
            return question.ToList();
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            var question = await _unitOfWork.Questions.GetAsync(q => q.QuestionId == id);
            if(question == null)
            {
                throw new QuestionNotFoundException(id);
            }

            return question;
        }

        public async Task SaveQuestionAsync()
        {
            await _unitOfWork.SaveAsync();
        }

        public async Task SubmitQuestionAsync(Question question)
        {
            await _unitOfWork.Questions.CreateAsync(question);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            await _unitOfWork.Questions.UpdateAsync(question);
            await _unitOfWork.SaveAsync();
        }
        public async Task SaveChoicesAsync(AddChoiceViewModel model)
        {
            var questionList = _mapper.Map<List<Question>>(model.Questions).ToList();
            for (int i = 0; i < questionList.Count; i++)
            {
                var question = await GetQuestionAsync(questionList[i].QuestionId);
                question.Choices = _mapper.Map<List<Choice>>(model.Questions[i].QuestionChoices).ToList();
                await UpdateQuestionAsync(question);
            }
        }


    }
}
