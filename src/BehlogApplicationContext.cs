using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Microsoft.AspNetCore.Http;

namespace Behlog.Core
{

    public class BehlogApplicationContext : IBehlogApplicationContext
    {
        private const string __USER_AGENT_KEY = "User-Agent";
        private const string __URL_REFERER = "Referer";

        private readonly IHttpContextAccessor _contextAccessor;

        public BehlogApplicationContext(
            IHttpContextAccessor contextAccessor) {
            _contextAccessor = contextAccessor
                ?? throw new ArgumentNullException(nameof(contextAccessor));
        }

        public HttpContext Current => _contextAccessor.HttpContext;

        public HttpRequest Request => Current.Request;

        public string BaseUrl => $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

        public string UserAgent {
            get {
                return Request.Headers[__USER_AGENT_KEY][0];
                //return _detection.Browser.Name;
            }
        }

        public string OsPlatform {
            get {
                return "Windows x64";
            }
        }

        public string SessionId =>
            Current.Session.Id;

        public string IpAddress =>
            Current?.Connection?.RemoteIpAddress?.ToString() ?? "127.1.1.1";

        public string AbsoluteUrl {
            get {
                UriBuilder uriBuilder = new UriBuilder
                {
                    Scheme = Request.Scheme,
                    Host = Request.Host.Host,
                    Path = Request.Path.ToString(),
                    Query = Request.QueryString.ToString()
                };

                return uriBuilder.Uri.AbsoluteUri;
            }
        }

        public string? UrlReferer =>
            Request.Headers[__URL_REFERER].Any()
            ? Request.Headers[__URL_REFERER].ToString()
            : null;
    }
}
