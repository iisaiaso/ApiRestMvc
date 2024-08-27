
using ApiMvc.Controllers.Exceptions;
using ApiMvc.Service.Cores.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace ApiMvc.Controllers.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public ExceptionMiddleware()
        {
            
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception) 
            {
                var errorResult = new ErrorModel();
                HttpStatusCode statusCode;

                switch (exception)
                {
                    case NotFoundCoreException e:
                        statusCode = HttpStatusCode.NotFound;
                        errorResult.Message = e.Message;
                        break;

                    default:
                        statusCode = HttpStatusCode.InternalServerError;
                        errorResult.Message = "Se ha producido un error inesperado";
                        break;
                }

                var response = context.Response;

                if (!response.HasStarted) 
                {
                    response.ContentType = "application/json";
                    response.StatusCode = (int)statusCode;

                    await response.WriteAsJsonAsync(errorResult);
                }
            }
        }
    }
}
