using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Filters
{
    public class ExampleAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public string attrib { get; set; }

        public int Order { get; set; }

        public ExampleAttribute(string attribute, int order)
        {
            this.attrib = attribute;
            this.Order = order;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Trace.WriteLine($" {this.attrib} - after example");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Trace.WriteLine($" {this.attrib} - before example");
        }
    }
}
