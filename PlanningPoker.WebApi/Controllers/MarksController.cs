using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanningPoker.WebApi.Models;
using PlanningPoker.WebApi.Services;

namespace PlanningPoker.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarksController : ControllerBase
    {
        private SessionHolder _sessionHolder;
        private ILogger<MarksController> _logger;

        public MarksController(SessionHolder sessionHolder, ILogger<MarksController> logger)
        {
            _sessionHolder = sessionHolder;
            _logger = logger;
        }

        [HttpPut]
        [Route("")]
        public void SetMarks(Mark mark)
        {
            var session = _sessionHolder.GetSession(mark.SessionId);
            if (session == null)
            {
                _logger.Log(LogLevel.Error, "session not found");
                throw new KeyNotFoundException("no session found by id");
            }

            if (session.DefinedMarks.Contains(mark.Value))
            {
                session.UserNamesAndMarks[mark.Name] = mark.Value;
            }
        }
    }
}