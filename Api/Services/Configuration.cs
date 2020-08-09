using System.Collections.Generic;
using UserEntities = Api.Entities.User;
using UserFactories = Api.Factories.User;

namespace Api.Services
{
	public class Configuration
	{
		public static readonly string BaseUrl = "https://api.cardmarket.com/ws/v2.0/output.json";
		
		public static readonly Dictionary<string, UserEntities.User> User = new Dictionary<string, UserEntities.User>()
		{
			{
				"raden", getUserRaden()
			},
			{
				"patzer", getUserPatzer()
			}
		};

		private static UserEntities.User getUserRaden()
		{
			return UserFactories.User.CreateUser("bX3gsqGPU38ucFPM", "MMtOoh71AI2TQpmNOWqopNQ0Bln4OdbJ", "JCNYHxk35bLn2dAe9dURjt3LDKkMCpJs",
				"wC6Lb3zAMTA3aziivUX22MOlo0QVB3z3");
		}

		private static UserEntities.User getUserPatzer()
		{
			return UserFactories.User.CreateUser("", "", "", "");
		}
	}
}