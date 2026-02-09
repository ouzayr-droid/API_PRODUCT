using System.Net;

public class ApplicationException: Exception
{
    public HttpStatusCode StatusCode { get; }
    
    public ApplicationException(string message, HttpStatusCode statusCode): base(message)
    {
        StatusCode = statusCode;
    }
}