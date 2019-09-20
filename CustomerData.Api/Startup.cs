using CustomerData.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Panda.DynamicWebApi;
using Swashbuckle.AspNetCore.Swagger;

namespace CustomerData.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info() { Title = "CustomerData WebApi", Version = "v1" });
                options.DocInclusionPredicate((docName, description) =>
                {
                    return true;
                });
                options.IncludeXmlComments(@"bin\Debug\netcoreapp2.2\CustomerData.Application.xml");
            });
            services.AddDynamicWebApi();
            services.AddDbContext<ProductContext>(options => options.UseMySQL(Configuration.GetSection("DBConnection:Product").Value));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerData WebApi");
            });
            app.UseMvc();
        }
    }
}
