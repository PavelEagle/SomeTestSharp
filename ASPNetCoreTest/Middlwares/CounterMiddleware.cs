using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ASPNetCoreTest
{
  public class CounterMiddleware
  {
    private readonly RequestDelegate _newx;
    private int i;

    public CounterMiddleware(RequestDelegate newx)
    {
      _newx = newx;
      i = 0;
    }

    public async Task InvokeAsync(HttpContext httpContext, ICounter counter, CounterService counterService)
    {
      i++;
      httpContext.Response.ContentType = "text/html;charset=utf-8";
      await httpContext.Response.WriteAsync(
        $"Запрос {i}; Counter: {counter.Value}; Service: {counterService.Counter.Value}");
    }
  }
}
