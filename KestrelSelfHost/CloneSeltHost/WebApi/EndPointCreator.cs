using ICA.Ng.Carpark.WebApi.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Security.Authentication;

namespace ICA.Ng.Carpark.WebApi
{
    public class EndPointCreator
    {
        public string? ApiProtocol { get; set; }
        public string? ApiHost { get; set; }
        public string? ApiPort { get; set; }
        public string? WebApiAddress { get; set; }
        public string? UrlFromConfig { get; set; }                
        

        public EndPointCreator()
        {            
        }

        public void CreateEndPointAsync(IConfigurationRoot? config)
        {
            RunSelfHostAsync(config);
        }

        private void RunSelfHostAsync(IConfigurationRoot? config, int retry = 0)
        {
            try
            {
                WebApiAddress = BuildApiUrl(null);

                if (!string.IsNullOrEmpty(WebApiAddress))
                {
                    InitializeLoggerAsyncApi();

                    CreateHostBuilderAsync(WebApiAddress).Build().Run();
                }
            }
            catch (Exception ex)
            {
               // Logger.Error(string.Format("Error when trying to make the Web API available at the address{0} - Error: {1}", WebApiAddress, ex.Message));

                if (retry < 3)
                {
                    Thread.Sleep(2000);
                    RunSelfHostAsync(config, ++retry);
                }
            }
        }

        public IHostBuilder CreateHostBuilderAsync(string urlApi) =>
            Host.CreateDefaultBuilder(null)

            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<StartUp>();

                webBuilder.ConfigureKestrel(options =>
                {
                    options.ListenLocalhost(80);
                });
            })

            .ConfigureLogging((logging) =>
            {
                //logging.ClearProviders();
            });

        private void InitializeLoggerAsyncApi()
        {
           // Logger = _loggerFactory.Create("Async WebApi");
           // Logger.Info(string.Format("The Web API is listening for requests on:{0}", WebApiAddress));
        }

        private string BuildApiUrl(string? urlFromConfig)
        {
            return BuildUrlParts();
        }

        public string BuildUrlParts()
        {
            UrlFromConfig = "https://localhost:5001/";

            ApiProtocol = UrlFromConfig.ExtractProtocolFromUrl(UrlFromConfig);
            ApiHost = UrlFromConfig.ExtractHostlFromUrl(UrlFromConfig);
            ApiPort = UrlFromConfig.ExtractPortFromURL(UrlFromConfig);
            WebApiAddress = UrlFromConfig.BuildWebApiUrl(ApiProtocol, ApiHost, ApiPort);

            return WebApiAddress ?? string.Empty;
        }
    }
}
