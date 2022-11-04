using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BoilerDemo.Controllers
{
    public class ErrorController : Controller
    {
        private readonly IConfiguration _configuration;

        public ErrorController(
            IConfiguration configuration
        )
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Global Error Handling Enpoint
        /// </summary>
        /// <returns>IActionResult</returns>
        [Route( "/Error" )]
        public IActionResult Error()
        {
            // Configure Serilog logger to log any exceptions in Logs/error_logs.txt
            string LogFilePath = _configuration.GetValue<string>( "ErrorLogPath" );
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File( LogFilePath, rollingInterval: RollingInterval.Day )
                .CreateLogger();
            Exception exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>().Error;
            Log.Information( exception.Message );
            Log.Information( exception.StackTrace );
            ViewBag.StackTrace = exception.StackTrace;
            ViewBag.AuthorName = Environment.GetEnvironmentVariable( "AuthorName" );
            return View();
        }
    }
}
