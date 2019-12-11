using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Herald.Models
{
	public class Destination
	{
		public string Path { get; set; }
		public bool RequiresAuthentication { get; set; }
		public Destination(string uri, bool requiresAuthentication)
		{
			Path = uri;
			RequiresAuthentication = requiresAuthentication;
		}

		public Destination(string path)
			: this(path, false)
		{
		}

		private Destination()
		{
			Path = "/";
			RequiresAuthentication = false;
		}

		public async Task<HttpResponseMessage> SendRequest(HttpRequest request)
		{
			var _clientHandler = new HttpClientHandler();
			_clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
			_clientHandler.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
			_clientHandler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
			{
				return true;
			};
			var cert = await request.HttpContext.Connection.GetClientCertificateAsync();
			_clientHandler.ClientCertificates.Add(cert);
			HttpClient client = new HttpClient(_clientHandler);
			string requestContent;
			using (Stream receiveStream = request.Body)
			{
				using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
				{
					requestContent = await readStream.ReadToEndAsync();
				}
			}

			using (var newRequest = new HttpRequestMessage(new HttpMethod(request.Method), CreateDestinationUri(request)))
			{
				newRequest.Content = new StringContent(requestContent, Encoding.UTF8, request.ContentType);
				return await client.SendAsync(newRequest);
			}
		}

		private string CreateDestinationUri(HttpRequest request)
		{
			string requestPath = request.Path.ToString();
			string queryString = request.QueryString.ToString();

			string endpoint = "";
			string[] endpointSplit = requestPath.Substring(1).Split('/');

			if (endpointSplit.Length > 1)
				endpoint = endpointSplit[1];


			return Path + endpoint + queryString;
		}

	}
}