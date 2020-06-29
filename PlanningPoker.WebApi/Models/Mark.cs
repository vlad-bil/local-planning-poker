namespace PlanningPoker.WebApi.Models
{
    public class Mark
    {
        public Mark(string sessionId, string name, int value)
        {
            SessionId = sessionId;
            Name = name;
            Value = value;
        }

        public string SessionId { get; }
        
        public string Name { get; }
        
        public int Value { get; }
    }
}