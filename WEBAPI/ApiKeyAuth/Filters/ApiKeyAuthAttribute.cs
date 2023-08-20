using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiKeyAuth.Filters
{
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string apiKey = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // get value from header
            bool res = context.HttpContext.Request.Headers.TryGetValue(apiKey, out var keyFmHeader);
            if (!res)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            // get value from appsetting
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var keyFmConfiguration = configuration.GetValue<string>(apiKey);

            // compare
            if(keyFmHeader!= keyFmConfiguration)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
