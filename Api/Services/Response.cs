using System.Text.Json;

namespace Api.Services
{
	public class Response<T>
	{
		public static T FromString(string data)
		{
			return JsonSerializer.Deserialize<T>(data);
		}
	}
}