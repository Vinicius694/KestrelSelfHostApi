namespace ICA.Ng.Carpark.WebApi.Helpers
{
    public static class UriExtensions
    {
        public static string? ExtractProtocolFromUrl(this string uriAddress, string? protocol)
        {
            if (!string.IsNullOrEmpty(protocol))
            {
                protocol = protocol?.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
               .FirstOrDefault();
            }

            return protocol;
        }
        public static string? ExtractHostlFromUrl(this string uriAddress, string? host)
        {
            if (!string.IsNullOrEmpty(host))
            {
                if (host.Contains(@"://"))
                    host = host.Split(new string[] { "://" }, 2, StringSplitOptions.None)[1];
            }

            return host?.Split(":").FirstOrDefault();
        }

        public static string? ExtractPortFromURL(this string uriAddress, string? port)
        {
            if (!string.IsNullOrEmpty(port))
            {
                port = port?.Split(':').LastOrDefault();
            }

            return port;
        }

        public static string? BuildWebApiUrl(this string webApiUrl, string? protocol, string? host, string? port)
        {             
            if (!string.IsNullOrEmpty(protocol) && !string.IsNullOrEmpty(host) && !string.IsNullOrEmpty(port))
            {
                webApiUrl = string.Format("{0}{1}{2}", protocol + "//", host + ":", port);
            }

            return webApiUrl;
        }
    }
}
