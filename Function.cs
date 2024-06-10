using Amazon.Lambda.Core;
using Microsoft.Extensions.Configuration;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace TestLambda;

public class Function
{
    private static readonly IConfiguration _configuration;
    private static readonly string? connection;
    static Function()
    {
        var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();

        _configuration = builder.Build();
        connection = _configuration["DefaultConnection"];
    }
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public string? FunctionHandler(string input, ILambdaContext context)
    {
        
        return connection + Call();
    }

    private static string? Call()
    {
        return connection;
    }
}
