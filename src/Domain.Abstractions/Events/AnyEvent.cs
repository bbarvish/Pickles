namespace Pickles.Domain.Events;

public class AnyEvent
{   
    public string EventType { get; set; }
    public string DataPayload { get; set; }
    public string DataSasUrl { get; set; }
    public string Context { get; set; }
}