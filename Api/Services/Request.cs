using System;
using System.Net.Http;
using Api.Entities.User;

namespace Api.Services
{
	/**
	 * Request-Service class for making Http-Requests
	 */
	public class Request
	{
		private static readonly HttpClient client = new HttpClient();
		private static Request _instance{get; set;}

		/**
		 * "get"-Function
		 */
		public static Request Singleton()
		{
			if(_instance == null)
			{
				_instance = new Request();
			}

			return _instance;
		}

		/**
		 * Function to build the uri
		 */
		private string getUri(string baseUrl, string endpoint)
		{
			string[] uriParts = {baseUrl.TrimEnd('/'), endpoint.TrimStart('/')};

			var uri = String.Join("/", uriParts);

			return uri;
		}

		/**
		 * Function to make an http get-request
		 */
		public string GetRequest(User user, string endpoint)
		{
			string uri = this.getUri(Configuration.BaseUrl, endpoint);
			
			return "";
		}
	}
}