using Asp.NetCoreBoilerPlate.API.Businesses.Interfaces;
using Asp.NetCoreBoilerPlate.API.Exceptions;
using Asp.NetCoreBoilerPlate.Dependencies.Enums.MessageCode;

using System.Net;

namespace Asp.NetCoreBoilerPlate.API.Businesses
{
	public class HomeBusiness : IHomeBusiness
	{
		public void SendHelloWorld()
		{
			throw new HTTPException<HomeEnum>(HttpStatusCode.OK, HomeEnum.HOME_HELLO_WORLD);
		}
	}
}