using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Repository
{
    public interface IUnitOfWork
    {
        IAnswerRepository Answers { get; }
        IChoiceRepository Choices { get; }
        IQuestionRepository Questions { get; }
        ISubmissionRepository Submissions { get; }
        ISurveyObjectRepository Surveys { get; }
        Task SaveAsync();
    }
}
