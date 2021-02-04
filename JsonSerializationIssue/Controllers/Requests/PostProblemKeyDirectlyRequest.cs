#nullable disable
using JsonSerializationIssue.Models;
using System.Collections.Generic;

namespace JsonSerializationIssue.Controllers.Requests
{
    public class PostProblemKeyDirectlyRequest
    {
        public IEnumerable<ProblemKey> Fixes { get; set; }
    }
}