using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASPNetCoreTest
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      string[] arh = {"asdasd=1", "asda=2"};
      var builder = new ConfigurationBuilder().AddCommandLine(arh)
        .AddXmlFile("test.xml").AddIniFile("test.ini")
        .AddConfiguration(configuration);

      Configuration = builder.Build();
      var bb = Configuration["name"];
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddTransient<IConfiguration>(provider=> Configuration);

      services.AddControllers();

      services.AddSingleton<ICounter, RandomCounter>();
      services.AddSingleton<CounterService>();

      services.AddTransient<ITimer, Timer>();
      services.AddTransient<TimeService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseMiddleware<ConfigMiddleware>();
      app.UseMiddleware<CounterMiddleware>();

      app.UseDeveloperExceptionPage();
      app.UseMiddleware<TimerMiddleware>();

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
