using VenturaSoftHR.CrossCutting.Enums;
using VenturaSoftHR.CrossCutting.Notifications;
using VenturaSoftHR.Domain.SeedWork.Commands;

namespace VenturaSoftHR.Domain.SeedWork.Handlers;

public class BaseRequestHandler
{
    protected readonly INotificationHandler Notification;

    protected BaseRequestHandler(INotificationHandler notification)
    {
        Notification = notification;
    }

    protected virtual void NotifyNullOrEmptyObject()
    {
        Notification.RaiseError(CommonsEnum.Error.NullOrEmptyObject.ToString());
    }

    protected bool IsValid(BaseCommand command)
    {
        if (command.IsValid()) return true;

        foreach (var error in command.ValidationResult.Errors)
        {
            var commandError = error.CustomState as CommandErrorObject;
            Notification.RaiseError(commandError.Enum.ToString(), commandError.Reference);
        }

        return false;
    }
}
