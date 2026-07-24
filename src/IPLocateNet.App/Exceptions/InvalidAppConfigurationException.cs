namespace IPLocateNet.App.Exceptions;

public class InvalidAppConfigurationException : InvalidOperationException
{
    public InvalidAppConfigurationException(string? message) : base(message)
    {
    }

    public InvalidAppConfigurationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
