using MinimalAPISandbox.EndpointDefinition.AbstractionEndpointDefinition;

namespace MinimalAPISandbox.EndpointDefinition
{
    public class CustomerEndpointDefinition : AbstractCustomerEndpointDefinition
    {
        internal override IResult GetAllCustomers()
        {
            return Results.Ok(new List<string> { "A", "B", "C", "D" });
        }

        internal override IResult GetCustomer(int id)
        {
            return Results.Ok(id);
        }
    }
}
