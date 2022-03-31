using System.Runtime.Serialization;

namespace VenturaSoftHR.Common.Exceptions;

[Serializable]
public class GenericErrorException : Exception
{
    public GenericErrorException(string message) : base(message)
    {
    }

    protected GenericErrorException(SerializationInfo info, StreamingContext context) : base(info, context) {}
}
