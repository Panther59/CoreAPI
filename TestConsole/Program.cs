using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			Console.ReadLine();

			var handler = new HttpClientHandler();
			handler.ClientCertificateOptions = ClientCertificateOption.Manual;
			handler.SslProtocols = SslProtocols.Tls12;
			handler.ClientCertificates.Add(new X509Certificate2(@"C:\certs\utkarsh_chauhan_ayvan.crt"));
			var client = new HttpClient(handler);
			var result = client.GetAsync("https://localhost:44326/weather/weatherforecast").GetAwaiter().GetResult();
		}
	}
}
