using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.webapi.two.Filters
{
    [AttributeUsage(validOn:AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        const string ApiKeyHeaderName = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialKey))
              {

                context.Result = new UnauthorizedResult();
                return;
            }
            // get value from the appsettings
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var apikey = configuration.GetValue<string>(key: "ApiKey");
            if (!apikey.Equals(potentialKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
