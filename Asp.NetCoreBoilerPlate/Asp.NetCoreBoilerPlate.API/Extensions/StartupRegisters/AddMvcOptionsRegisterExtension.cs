using Microsoft.AspNetCore.Mvc;

using Asp.NetCoreBoilerPlate.API.Filters;
using Asp.NetCoreBoilerPlate.Dependencies.Enums.MessageCode;

namespace Asp.NetCoreBoilerPlate.API.Extensions.StartupRegisters
{
	public static class AddMvcOptionsRegisterExtension
	{
		public static void AddMvcOptionsRegister(this MvcOptions options)
		{
			options.Filters.Add<HTTPFilter<HomeEnum>>();
			options.Filters.Add<GlobalFilter>(1);
		}
	}
}