using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FIT_Api_Examples.Helper.AutentifikacijaAutorizacija
{
    public class AddAuthorizationHeader : IOperationFilter
    {
       

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "autentifikacija-token",
                In = ParameterLocation.Header,
                Description = "opisi",
                
            });
        }
    }
}
