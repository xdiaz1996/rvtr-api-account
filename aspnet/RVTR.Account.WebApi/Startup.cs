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
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

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
        docs.SwaggerDoc("v0", new OpenApiInfo()
        {
          Title = "Account API",
          Version = "0.0.0"
        });
      });
    }

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
