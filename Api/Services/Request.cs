using System;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Entities.User;
using Chilkat;
using DotNetOpenAuth;

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
			OAuth1 oauth = new OAuth1();
			oauth.GenNonce(16);
			oauth.GenTimestamp();
			oauth.OauthUrl = uri;
			oauth.OauthVersion = "1.0";
			oauth.OauthMethod = "GET";
			oauth.ConsumerKey = user.consumerKey;
			oauth.ConsumerSecret = user.consumerSecret;
			oauth.Token = user.token;
			oauth.TokenSecret = user.tokenSecret;
			oauth.Realm = uri;
			oauth.SignatureMethod = "HMAC-SHA1";
			oauth.AddParam("oauth_callback", "oob");

			bool success = oauth.Generate();
			if(success != true)
			{
				return oauth.LastErrorText;
			}

			string requestTokenUrl = oauth.GeneratedUrl + "&oauth_signature=" + oauth.EncodedSignature;
			Http http = new Http();
			// Get the request token...
			HttpResponse resp = http.QuickGetObj(requestTokenUrl);
			if(resp == null)
			{
				return http.LastErrorText;
			}

			return "";
		}
	}
}