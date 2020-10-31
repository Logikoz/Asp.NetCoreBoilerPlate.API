using Microsoft.AspNetCore.Mvc;

using Asp.NetCoreBoilerPlate.API.Businesses.Interfaces;
using Asp.NetCoreBoilerPlate.Dependencies.Enums.MessageCode;

namespace Asp.NetCoreBoilerPlate.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly IHomeBusiness _homeBusiness;

		public HomeController(IHomeBusiness homeBusiness)
		{
			_homeBusiness = homeBusiness;
		}

		/// <summary>
		/// Envia um Hello World
		/// </summary>
		/// <response code="200"><see cref="HomeEnum.HOME_HELLO_WORLD"/></response>
		[HttpGet]
		[ProducesResponseType(200)]
		public void HelloWorld()
		{
			_homeBusiness.SendHelloWorld();
		}
	}
}