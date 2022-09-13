using Microsoft.AspNetCore.Builder;

namespace PhoneManager.WebApi.Middleware
{
    public static class CusomExceptionHandlerMiddlewareExceptions
    {
        public static IApplicationBuilder UseCusomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CusomExceptionHandlerMiddleware>();
        }
    }
}
