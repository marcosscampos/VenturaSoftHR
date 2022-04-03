using VenturaSoftHR.Common.Exceptions;

namespace VenturaSoftHR.Api.Common;

public static class ErrorHandlerFactory
{
    public static ErrorHandler Create(Exception exception) => exception switch
    {
        GenericErrorException e => new ErrorHandler(e.GetType().Name, e.Message),
        InvalidSalaryException e => new ErrorHandler(e.GetType().Name, e.Message),
        InvalidFinalDateException e => new ErrorHandler(e.GetType().Name, e.Message),
        NotFoundException e => new ErrorHandler(e.GetType().Name, e.Message),
        _ => new ErrorHandler(exception.GetType().Name, exception.Message)
    };
}
