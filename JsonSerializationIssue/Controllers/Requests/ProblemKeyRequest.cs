#nullable disable
using System.Collections.Generic;

namespace JsonSerializationIssue.Controllers.Requests
{
    public class ProblemKeyRequest
    {
        public string ProblemType { get; set; }

        public string ComponentName { get; set; }

        public string ProblemIdentifier { get; set; }

        public IEnumerable<string> AffectedItemIdentifiers { get; set; }
    }
}