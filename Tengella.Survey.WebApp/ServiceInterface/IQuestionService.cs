using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.Models;

namespace Tengella.Survey.WebApp.ServiceInterface
{
    public interface IQuestionService
    {
        Task<Question> GetQuestionAsync(int id);
        Task<List<Question>> GetAllQuestionAsync();
        Task SubmitQuestionAsync(Question question);
        Task UpdateQuestionAsync(Question question);
        Task SaveQuestionAsync();
        Task SaveChoicesAsync(AddChoiceViewModel model);
    }
}
