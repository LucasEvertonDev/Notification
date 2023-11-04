namespace Notification.Exceptions;

public class ValidationPropertWithOutGetSetException : System.Exception
{
    public ValidationPropertWithOutGetSetException(string message)
        : base(message)
    {
    }
}
