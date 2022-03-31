using System.Runtime.Serialization;

namespace VenturaSoftHR.Common.Exceptions;

[Serializable]
public class InvalidFinalDateException : Exception
{
    public InvalidFinalDateException(string message) : base(message)
    {

    }
}
