namespace Herald.Models
{
	public class Route
	{
		public string Endpoint { get; set; }
		public string AuthenticationType { get; set; }
		public Destination Destination { get; set; }
	}
}