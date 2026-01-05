namespace Stockly.Application.Exceptions;

public sealed class AlreadyExistsException : Exception
{
    public AlreadyExistsException(string message)
        : base(message)
    {
    }
}
