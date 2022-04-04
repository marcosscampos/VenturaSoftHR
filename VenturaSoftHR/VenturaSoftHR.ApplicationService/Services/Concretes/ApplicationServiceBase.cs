using VenturaSoftHR.CrossCutting.Notifications;

namespace VenturaSoftHR.Application.Services.Concretes;

public class ApplicationServiceBase
{
    protected INotificationHandler Notification;

    protected ApplicationServiceBase(INotificationHandler notification)
    {
        Notification = notification;
    }
}
