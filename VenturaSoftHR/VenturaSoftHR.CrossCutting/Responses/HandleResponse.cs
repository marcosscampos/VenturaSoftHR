using VenturaSoftHR.CrossCutting.Notifications;

namespace VenturaSoftHR.CrossCutting.Responses;

public class HandleResponse
{
    public List<NotificationResponse> Errors { get; set; }
    public List<NotificationResponse> Success { get; set; }
    public object Data { get; set; }
}
