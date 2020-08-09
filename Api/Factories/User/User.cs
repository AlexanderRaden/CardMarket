using UserEntities = Api.Entities.User;

namespace Api.Factories.User
{
	public class User
	{
		public static UserEntities.User CreateUser(string consumerKey, string consumerSecret, string token, string tokenSecret)
		{
			var user = new UserEntities.User();
			user.consumerKey = consumerKey;
			user.consumerSecret = consumerSecret;
			user.token = token;
			user.tokenSecret = tokenSecret;
			return user;
		}
	}
}