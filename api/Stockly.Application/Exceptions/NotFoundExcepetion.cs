namespace Stockly.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(Type entityType)
        : base($"{entityType.Name} not found")
    {
    }
}