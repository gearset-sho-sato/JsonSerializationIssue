#nullable disable
using System.Collections.Generic;

namespace JsonSerializationIssue.Controllers.Requests
{
    public class PostProblemKeyIndirectlyRequest
    {
        public IEnumerable<ProblemKeyRequest> Fixes { get; set; }
    }
}