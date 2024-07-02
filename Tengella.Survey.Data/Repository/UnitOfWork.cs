using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tengella.Survey.Data.Repository
{
    public class UnitOfWork(SurveyDbContext surveyDbContext, ISurveyObjectRepository surveys, IQuestionRepository questions, IChoiceRepository choices, ISubmissionRepository submissions, IAnswerRepository answers) : IUnitOfWork
    {
        public ISurveyObjectRepository Surveys { get; } = surveys;
        public IAnswerRepository Answers { get; } = answers;

        public IChoiceRepository Choices { get; } = choices;

        public IQuestionRepository Questions { get; } = questions;

        public ISubmissionRepository Submissions { get; } = submissions;

        public async Task SaveAsync()
        {
            await surveyDbContext.SaveChangesAsync();
        }
    }
}
