using System;
using System.Collections.Generic;
using PlanningPoker.WebApi.Models;

namespace PlanningPoker.WebApi.Services
{
    public class SessionHolder
    {
        public SessionHolder()
        {
            _sessions = new Dictionary<string, Session>();
        }

        private IDictionary<string, Session> _sessions;
        private IEnumerable<int> _defaultValues = new[] {1, 2, 3, 5, 8, 13};

        public Session GetSession(string id)
        {
            if (_sessions.TryGetValue(id, out var session))
            {
                return session;
            }

            return null;
        }

        public Session CreateSession(IEnumerable<int> values = null)
        {
            var id = Guid.NewGuid().ToString();
            var session = new Session(id, values ?? _defaultValues);
            _sessions[id] = session;
            return session;
        }
    }
}