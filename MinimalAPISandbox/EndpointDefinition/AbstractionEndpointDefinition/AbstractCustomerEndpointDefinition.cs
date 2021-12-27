using MinimalAPISandbox.EndpointDefinition.VersionControl;

namespace MinimalAPISandbox.EndpointDefinition.AbstractionEndpointDefinition
{
    public abstract class AbstractCustomerEndpointDefinition : IEndpointDefinition
    {
        public void EndpointDefinition(WebApplication app)
        {
            app
               .MapGet(EndpointRouteVersion.Route("GetallCustomers", ApiVersionControl.V1), GetAllCustomers)
               .WithName("GetallCustomers")
               .WithTags($"Customer {ApiVersionControl.V1}")
               .Produces<IList<string>>(StatusCodes.Status200OK)
               .Produces(StatusCodes.Status400BadRequest)
               .WithGroupName(ApiVersionControl.V1);

            app
                .MapGet(EndpointRouteVersion.Route("GetCustomer", ApiVersionControl.V1, "{id}"), GetCustomer)
                .WithName("GetCustomer")
                .WithTags($"Customer {ApiVersionControl.V1}")
                .Produces<List<string>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .WithGroupName(ApiVersionControl.V1);
        }

        internal abstract IResult GetAllCustomers();
        internal abstract IResult GetCustomer(int id);
    }
}
