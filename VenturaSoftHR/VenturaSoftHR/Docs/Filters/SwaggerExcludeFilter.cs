﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text.Json.Serialization;

namespace VenturaSoftHR.Api.Docs.Filters;

public class SwaggerExcludeFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var ignoredProperties = context.MethodInfo.GetParameters()
            .SelectMany(p => p.ParameterType.GetProperties()
                             .Where(prop => prop.GetCustomAttribute<JsonIgnoreAttribute>() != null)
                             );
        if (ignoredProperties.Any())
        {
            foreach (var property in ignoredProperties)
            {
                operation.Parameters = operation.Parameters
                    .Where(p => (!p.Name.Equals(property.Name, StringComparison.InvariantCulture) && !p.In.Value.ToString().Equals("route", StringComparison.InvariantCultureIgnoreCase)))
                    .ToList();
            }

        }
    }
}