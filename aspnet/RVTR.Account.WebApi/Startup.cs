using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RVTR.Account.DataContext;
using RVTR.Account.DataContext.Repositories;

namespace RVTR.Account.WebApi
{
  /// <summary>
  ///
  /// </summary>
  public class Startup
  {
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public IConfiguration Configuration { get; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddDbContext<AccountContext>(options => options.UseNpgsql(Configuration.GetConnectionString("pgsql")));

      services.AddCors(cors =>
      {
        cors.DefaultPolicyName = "default";

        cors.AddDefaultPolicy(policy =>
        {
          policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
      });

      services.AddScoped<UnitOfWork>();
      services.AddSwaggerGen(docs =>
      {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        docs.SwaggerDoc("v0", new OpenApiInfo()
        {
          Contact = new OpenApiContact()
          {
            Email = "howdy.rvtr@outlook.com",
            Name = "RVTR",
            Url = new Uri("https://twitter.com/howdy_rvtr")
          },
          License = new OpenApiLicense()
          {
            Name = "MIT License",
            Url = new Uri("https://github.com/RVTR/rvtr-api-account/blob/master/LICENSE")
          },
          Title = "Account API",
          Version = "0.0.0"
        });

        docs.IncludeXmlComments(xmlPath);
      });
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseSwagger();
      app.UseSwaggerUI(urls =>
      {
        urls.SwaggerEndpoint("/swagger/v0/swagger.json", "v0");
      });
      app.UseRouting();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
