using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace JsonSerializationIssue.Models
{
    public class ProblemKey
    {
        [JsonConstructor]
        public ProblemKey(string problemType, string componentName, string problemIdentifier)
        {
            ProblemType = problemType;
            ComponentName = componentName;
            ProblemIdentifier = problemIdentifier;
            AffectedItemIdentifiers = Enumerable.Empty<string>();
        }

        public ProblemKey(string problemType, string componentName, string problemIdentifier, IEnumerable<string> affectedItemIdentifiers)
        {
            ProblemType = problemType;
            ComponentName = componentName;
            ProblemIdentifier = problemIdentifier;
            AffectedItemIdentifiers = affectedItemIdentifiers;
        }

        public string ProblemType { get; private set; }

        public string ComponentName { get; private set; }

        public string ProblemIdentifier { get; private set; }

        public IEnumerable<string> AffectedItemIdentifiers { get; private set; }
    }
}