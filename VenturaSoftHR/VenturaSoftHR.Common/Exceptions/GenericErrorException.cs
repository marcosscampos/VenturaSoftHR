using System.Runtime.Serialization;

namespace VenturaSoftHR.Common.Exceptions;

[Serializable]
public class GenericErrorException : Exception
{
    private readonly string Name;
    private readonly string Message;
    public GenericErrorException(string name, string message) : base(message)
    {
        Name = name;
        Message = message;
    }

    protected GenericErrorException(SerializationInfo info, StreamingContext context) : base(info, context) {}
}
