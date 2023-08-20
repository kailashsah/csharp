using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Simple.Filters
{
    public class ExAsyncFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Trace.WriteLine($"Before execution {GetType().Name}");
            await next();
            Trace.WriteLine($"After execution {GetType().Name}");
        }
    }
}
