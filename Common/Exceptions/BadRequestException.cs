namespace csharp_chat_api.Common.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message = "") : base(message)
    {
    }

    public BadRequestException(string message, Exception inner) : base(message, inner)
    {
    }
}