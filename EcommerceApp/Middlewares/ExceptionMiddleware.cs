using EcommerceApp.HandelResponses;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EcommerceApp.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly ILogger<ExceptionMiddleware> Logger;
        private readonly IHostEnvironment Environment;

        public ExceptionMiddleware(RequestDelegate _next,ILogger<ExceptionMiddleware>logger ,IHostEnvironment environment)
        {
            Next = _next;
            Logger = logger;
            Environment = environment;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await Next(context);
          
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = Environment.IsDevelopment() ?
                    new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) :
                    new ApiException((int)HttpStatusCode.InternalServerError);


                var options=new JsonSerializerOptions {PropertyNamingPolicy=JsonNamingPolicy.CamelCase};//optional

                var json=JsonSerializer.Serialize(response,options);
                await context.Response.WriteAsync(json);

            }
        }
    }
}
