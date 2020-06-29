using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanningPoker.WebApi.Models;
using PlanningPoker.WebApi.Services;

namespace PlanningPoker.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private ILogger<SessionController> _logger;
        private SessionHolder _sessionHolder;

        public SessionController(ILogger<SessionController> logger, SessionHolder sessionHolder)
        {
            _logger = logger;
            _sessionHolder = sessionHolder;
        }

        [HttpGet]
        [Route("{id}")]
        public Session Get(string id)
        {
            var session = _sessionHolder.GetSession(id);
            if (session == null)
            {
                _logger.Log(LogLevel.Error, "session not found");
                throw new KeyNotFoundException("no session found by id");
            }

            return session;
        }

        [HttpGet]
        [Route("{id}/toggle-hidden")]
        public void ToggleHidden(string id)
        {
            var session = Get(id);
            session.IsHidden = !session.IsHidden;
        }

        [HttpPut]
        [Route("")]
        public Session Create(IEnumerable<int> values)
        {
            var session = _sessionHolder.CreateSession(values);
            return session;
        }
    }
}