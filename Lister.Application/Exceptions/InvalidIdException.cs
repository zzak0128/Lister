using System.Runtime.Serialization;

namespace Lister.Application.Exceptions;

public class InvalidIdException : Exception
{
    public InvalidIdException()
    {
    }

    public InvalidIdException(int id) : base($"The given ID could not be found, or does not exist.{Environment.NewLine} ID: {id}")
    {
        Console.WriteLine(base.StackTrace);
    }

    public InvalidIdException(string? message) : base(message)
    {
    }

    public InvalidIdException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
