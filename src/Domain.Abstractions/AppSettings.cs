namespace Pickles.Domain;

public class AppSettings
{
    public string AWS_REGION { get; set; }
    public string Environment { get; set; }
    public NotificationOptions NotificationOptions { get; set; }
    public MessagingOptions MessagingOptions { get; set; }
}

public class NotificationOptions
{
    public bool WhenUserAdded { get; set; }
    public bool WhenPlayerAdded { get; set; }
}

public class MessagingOptions
{
    public string BusName { get; set; }
}