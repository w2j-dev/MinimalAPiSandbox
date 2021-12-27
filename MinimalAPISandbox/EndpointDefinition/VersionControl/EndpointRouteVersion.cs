namespace MinimalAPISandbox.EndpointDefinition.VersionControl
{
    public static class EndpointRouteVersion
    {
        public static string Route(string hitPoint, string version, params string[] test)
        {
            if(test.Length != 0)
            {
                var result = string.Empty;
                foreach(var testItem in test)
                    result = $"{result}/{testItem}";
                return $"api/{version}/{hitPoint}{result}";
            }
            return $"api/{version}/{hitPoint}";
        }
        public static string Route(string hitPoint)
            => $"api/{hitPoint}";
    }

    public static class ApiVersionControl
    {
        public static readonly string V1 = "v1";
    }
}
