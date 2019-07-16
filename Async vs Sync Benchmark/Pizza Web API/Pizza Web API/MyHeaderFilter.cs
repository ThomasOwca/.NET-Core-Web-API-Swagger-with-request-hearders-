using Microsoft.AspNetCore.JsonPatch.Operations;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Web_API
{
    /// <summary>
    /// Operation filter to add the requirement of the custom header
    /// </summary>
    public class MyHeaderFilter : IOperationFilter
    {
        public void Apply(Swashbuckle.AspNetCore.Swagger.Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "Username",
                In = "header",
                Type = "string",
                Required = true // set to false if this is optional
            });

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "Fullname",
                In = "header",
                Type = "string",
                Required = true // set to false if this is optional
            });
        }
    }
}
