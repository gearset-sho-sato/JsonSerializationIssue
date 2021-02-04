using JsonSerializationIssue.Controllers.Requests;
using JsonSerializationIssue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace JsonSerializationIssue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        const string request = @"
{
    'Fixes': [
        {
            'ProblemType': 'MissingDependency',
            'ComponentName': 'Account',
            'ProblemIdentifier': 'Account.AccountWorkflow,Account.Email_Alert,Account.NewAccountWorkflow',
            'AffectedItemIdentifiers': [
                'Account.AccountWorkflow',
                'Account.Email_Alert',
                'Account.NewAccountWorkflow'
            ]
        }
    ]
}";

        private readonly ILogger<ExampleController> _logger;

        public ExampleController(ILogger<ExampleController> logger)
        {
            _logger = logger;
        }

        // This fails if AffectedItemIdentifiers is something other than null
        [HttpPost("direct")]
        public void PostProblemKeyDirectly(PostProblemKeyDirectlyRequest request)
        {
        }

        // This succeeds no matter what as there is another layer sitting on top to avoid deserialization involving Enumerable.Empty<string>()
        [HttpPost("indirect")]
        public void PostProblemKeyIndirectly(PostProblemKeyIndirectlyRequest request)
        {
        }
    }
}
