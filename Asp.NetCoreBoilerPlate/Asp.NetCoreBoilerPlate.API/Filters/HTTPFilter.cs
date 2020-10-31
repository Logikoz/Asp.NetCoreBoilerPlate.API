using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Asp.NetCoreBoilerPlate.API.Exceptions;

using System;
using System.Net;

namespace Asp.NetCoreBoilerPlate.API.Filters
{
	public class HTTPFilter<TException> : IExceptionFilter where TException : Enum
	{
		public void OnException(ExceptionContext context)
		{
			if (context.Exception is HTTPException<TException> e)
			{
				context.HttpContext.Response.ContentType = "application/json";
				context.Result = new ObjectResult(e.StatusCode == HttpStatusCode.NoContent ? null : new
				{
					statusCode = e.StatusCode,
					messageCode = e.MessageCode,
					data = e.Object
				})
				{
					StatusCode = (int)e.StatusCode
				};
			}
		}
	}
}