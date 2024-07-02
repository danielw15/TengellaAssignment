using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Exceptions
{
    public class SurveyNotFoundException : Exception
    {
        public int SurveyId { get; }

        public SurveyNotFoundException(int surveyId)
            : base($"Survey not found for Survey ID: {surveyId}")
        {
            SurveyId = surveyId;
        }

        public SurveyNotFoundException(int surveyId, Exception innerException)
            : base($"Survey not found for Survey ID: {surveyId}", innerException)
        {
            SurveyId = surveyId;
        }
    }
}
