using Microsoft.Extensions.DependencyInjection;

using Asp.NetCoreBoilerPlate.API.Businesses;
using Asp.NetCoreBoilerPlate.API.Businesses.Interfaces;

namespace Asp.NetCoreBoilerPlate.API.Extensions.StartupRegisters
{
	public static class RegisterBusinessExtension
	{
		public static void RegisterBusiness(this IServiceCollection services)
		{
			services.AddScoped<IHomeBusiness, HomeBusiness>();
		}
	}
}