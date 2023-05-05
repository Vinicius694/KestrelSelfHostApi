using ICA.Ng.Carpark.WebApi;
using Microsoft.Extensions.Configuration;

namespace ICA.Ng.Carpark.WebApi
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string jsonPath = @"C:\Users\vaguiar\source\repos\CloneSeltHost\CloneSeltHost\appsettings.json";

            IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddJsonFile(jsonPath);
            IConfigurationRoot configuration = builder.Build();

            EndPointCreator endpoint = new EndPointCreator();

            endpoint.CreateEndPointAsync(configuration);

            Console.WriteLine("inicio");

        }
    }
}


