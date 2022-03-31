using VenturaSoftHR.Common.Exceptions;

namespace VenturaSoftHR.Api.Common;

public static class ErrorHandlerFactory
{
    public static ErrorHandler Create(Exception exception) => exception switch
    {
        GenericErrorException e => new ErrorHandler(e.GetType().Name, e.Message),
        _ => new ErrorHandler()
    };
}
