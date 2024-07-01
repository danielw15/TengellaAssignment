using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tengella.Survey.Data.Repository
{
    public class UnitOfWork(SurveyDbContext surveyDbContext, ISurveyObjectRepository surveys, IQuestionRepository questions, IChoiceRepository choices, ISubmissionRepository submissions, IAnswerRepository answers) : IUnitOfWork
    {
        public ISurveyObjectRepository SurveyObjectRepository { get; } = surveys;
        public IAnswerRepository AnswerRepository { get; } = answers;

        public IChoiceRepository ChoiceRepository { get; } = choices;

        public IQuestionRepository QuestionRepository { get; } = questions;

        public ISubmissionRepository SubmissionRepository { get; } = submissions;

        public async Task SaveAsync()
        {
            await surveyDbContext.SaveChangesAsync();
        }
    }
}
