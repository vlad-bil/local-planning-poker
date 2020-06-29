using System.Collections;
using System.Collections.Generic;

namespace PlanningPoker.WebApi.Models
{
    public class Session
    {
        public Session(string id, IEnumerable<int> definedMarks)
        {
            Id = id;
            DefinedMarks = definedMarks;
            UserNamesAndMarks = new Dictionary<string, int>();
            IsHidden = false;
        }

        public string Id { get; }
        
        public IEnumerable<int> DefinedMarks { get; }

        public IDictionary<string, int> UserNamesAndMarks { get; }
        
        public bool IsHidden { get; set; }
    }
}