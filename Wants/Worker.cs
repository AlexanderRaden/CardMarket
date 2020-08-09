using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Api.Services;
using Wants.Services;

namespace Wants
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;

		public Worker(ILogger<Worker> logger)
		{
			_logger = logger;
		}

		/**
		 * Function which is called one time
		 */
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var selectedUser = Configuration.User["raden"];
			var result = Request.Singleton().GetRequest(selectedUser, EndpointConfig.Path);
		}
	}
}