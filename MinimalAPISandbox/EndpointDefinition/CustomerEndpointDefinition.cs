using MinimalAPISandbox.EndpointDefinition.VersionControl;

namespace MinimalAPISandbox.EndpointDefinition
{
    public class CustomerEndpointDefinition : IEndpointDefinition
    {
        public void EndpointDefinition(WebApplication app)
        {
            app
                .MapGet(EndpointRouteVersion.Route("customer", ApiVersionControl.V1), GetAllCustomers)
                .WithName("GetallCustomers")
                .WithTags($"Customer {ApiVersionControl.V1}")
                .Produces<List<string>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithGroupName(ApiVersionControl.V1);
        }

        
        internal IResult GetAllCustomers()
        {
            return Results.Ok(new List<string> { "A", "B", "C", "D"});
        }
    }
}
