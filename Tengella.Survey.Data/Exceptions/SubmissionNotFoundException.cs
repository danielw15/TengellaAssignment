using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Exceptions
{
    public class SubmissionNotFoundException : Exception
    {
        public int SurveyId { get; }
        public string UniqueToken { get; }

        public SubmissionNotFoundException(int surveyId, string uniqueToken)
            : base($"Submission not found for Survey ID: {surveyId} and Token: {uniqueToken}")
        {
            SurveyId = surveyId;
            UniqueToken = uniqueToken;
        }

        public SubmissionNotFoundException(int surveyId, string uniqueToken, Exception innerException)
            : base($"Submission not found for Survey ID: {surveyId} and Token: {uniqueToken}", innerException)
        {
            SurveyId = surveyId;
            UniqueToken = uniqueToken;
        }
    }
}
