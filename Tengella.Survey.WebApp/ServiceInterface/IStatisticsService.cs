using Tengella.Survey.WebApp.Models;

namespace Tengella.Survey.WebApp.ServiceInterface
{
    public interface IStatisticsService
    {
        Task<List<SurveySummaryViewModel>> GetSurveySummariesAsync();
    }
}
