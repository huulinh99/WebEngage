namespace WebEngage.Model
{
    public class EventRequest
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public string EventTime { get; set; }
        public EventData EventData { get; set; }
    }
}
