namespace SmartHospital
{
    public class MyMiddleWare : IMiddleware
    {
        Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
        {

            throw new NotImplementedException();
        }
    }
}
