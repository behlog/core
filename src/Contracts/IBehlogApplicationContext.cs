using Microsoft.AspNetCore.Http;

namespace Behlog.Core.Contracts
{

    public interface IBehlogApplicationContext
    {
        HttpContext Current { get; }
        HttpRequest Request { get; }
        string BaseUrl { get; }
        string UserAgent { get; }
        string OsPlatform { get; }
        string SessionId { get; }
        string? IpAddress { get; }
        string AbsoluteUrl { get; }
        string? UrlReferer { get; }
    }
}
