using System;
using System.Net;

namespace Asp.NetCoreBoilerPlate.API.Exceptions
{
	public class HTTPException<TEnum> : Exception where TEnum : Enum
	{
		public HttpStatusCode StatusCode { get; private set; }
		public TEnum MessageCode { get; private set; }
		public object Object { get; private set; }

		public HTTPException(HttpStatusCode statusCode, object @object = null)
		{
			StatusCode = statusCode;
			Object = @object;
		}

		public HTTPException(HttpStatusCode statusCode, TEnum messageCode, object @object = null)
		{
			StatusCode = statusCode;
			MessageCode = messageCode;
			Object = @object;
		}
	}
}