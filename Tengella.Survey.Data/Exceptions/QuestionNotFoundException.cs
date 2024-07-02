using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Exceptions
{
    public class QuestionNotFoundException : Exception
    {
        public int QuestionId { get; }

        public QuestionNotFoundException(int questionId)
            : base($"Question not found for Question ID: {questionId}")
        {
            QuestionId = questionId;
        }

        public QuestionNotFoundException(int questionId, Exception innerException)
            : base($"Question not found for Question ID: {questionId}", innerException)
        {
            QuestionId = questionId;
        }
    }
}
