using Asp.NetCoreBoilerPlate.API.Businesses;
using Asp.NetCoreBoilerPlate.API.Businesses.Interfaces;

using Microsoft.Extensions.DependencyInjection;

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