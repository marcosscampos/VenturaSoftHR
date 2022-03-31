using System.Runtime.Serialization;

namespace VenturaSoftHR.Common.Exceptions;

[Serializable]
public class InvalidSalaryException : Exception
{
    public InvalidSalaryException(string message) : base(message)
    {

    }
}
