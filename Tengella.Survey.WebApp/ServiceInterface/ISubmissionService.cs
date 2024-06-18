using Microsoft.AspNetCore.Mvc;
using Tengella.Survey.Data.Models;
using Tengella.Survey.WebApp.Models;

namespace Tengella.Survey.WebApp.ServiceInterface
{
    public interface ISubmissionService
    {
        Task<Submission> GetSubmissionAsync(int? id);
        Task<List<Submission>> GetAllSubmissionAsync();
        Task SubmitSubmissionAsync(Submission submission);
        Task SaveSubmissionAsync();
    }
}
