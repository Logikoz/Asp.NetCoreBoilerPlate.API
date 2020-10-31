using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

using Asp.NetCoreBoilerPlate.Dependencies.Enums.MessageCode;

using System.Net;

namespace Asp.NetCoreBoilerPlate.API.Filters
{
	public class GlobalFilter : IExceptionFilter
	{
		private readonly IWebHostEnvironment _webHostEnvironment;

		public GlobalFilter(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
		}

		public void OnException(ExceptionContext context)
		{
			context.HttpContext.Response.ContentType = "application/json";
			context.Result = new ObjectResult(new
			{
				statusCode = HttpStatusCode.InternalServerError,
				messageCode = APIEnum.API_INTERNAL_ERROR,
				exception = _webHostEnvironment.IsDevelopment() ? new
				{
					context.Exception.Message,
					context.Exception.StackTrace,
					context.Exception.InnerException
				} : null
			})
			{ StatusCode = (int)HttpStatusCode.InternalServerError };
		}
	}
}