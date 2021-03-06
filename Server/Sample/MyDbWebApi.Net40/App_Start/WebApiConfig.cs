﻿using System.Web.Http;
using DbParallel.DataAccess;
using DataBooster.DbWebApi;
using MyDbWebApi.Handlers;

namespace MyDbWebApi
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
				name: "DbWebApi",
				routeTemplate: "{sp}/{ext}",
				defaults: new { controller = "DbWebApi", action = "DynExecute", ext = RouteParameter.Optional },
				constraints: new { ext = @"|json|xml|csv|xlsx|jsonp|razor" }
			);

			config.Routes.MapHttpRoute(
				name: "MiscApi",
				routeTemplate: "api/{controller}/{action}"
			);

			config.RegisterDbWebApi();
#if DEBUG
			config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
#endif
			config.MessageHandlers.Add(new CorsHandler());

		//	DbWebApiOptions.DefaultPropertyNamingConvention = PropertyNamingConvention.PascalCase;
		}
	}
}
