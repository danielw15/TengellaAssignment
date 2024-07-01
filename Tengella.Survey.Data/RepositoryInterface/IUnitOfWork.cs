using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Repository
{
    public interface IUnitOfWork
    {
        IAnswerRepository AnswerRepository { get; }
        IChoiceRepository ChoiceRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        ISubmissionRepository SubmissionRepository { get; }
        ISurveyObjectRepository SurveyObjectRepository { get; }
        Task SaveAsync();
    }
}
