using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proj.Api.DataAccess;
using Proj.Api.Repository;
using Proj.Api.Service;
using System;

namespace Proj.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string applocal = "applocal";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(opt =>
            //{
            //    opt.AddPolicy(name: applocal, builder =>
            //    {
            //        builder.WithOrigins("https://localhost:44353/")
            //        .AllowAnyHeader()
            //        .WithMethods("GET")
            //        .WithMethods("POST")
            //        .WithMethods("DELETE");
            //    });
            //});
            services.AddControllers()
               .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<ProjDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IProductRepo, ProductService>();
            services.AddScoped<ICategoryRepo, CategoryService>();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Logiwa API",
                    Version = "v1",
                    Description = "Code Challange",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Yusuf Muzaffer Deveci",
                        Email = "ym.dvc@hotmail.com",
                        Url = new Uri("https://www.linkedin.com/in/yusuf-muzaffer-deveci-913954186")
                    }
                });
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseCors(applocal);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
