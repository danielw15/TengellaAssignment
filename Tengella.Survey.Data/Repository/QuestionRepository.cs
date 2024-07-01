using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tengella.Survey.Data.Models;

namespace Tengella.Survey.Data.Repository
{
    public class QuestionRepository(SurveyDbContext surveyDbContext) : Repository<Question>(surveyDbContext), IQuestionRepository
    {
    }
}
