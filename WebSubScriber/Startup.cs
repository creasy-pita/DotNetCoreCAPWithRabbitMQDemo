using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebSubScriber
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<Service1>();
            services.AddOptions();
            services.AddDbContext<MYDbContext>(options =>
options.UseMySQL("Server=192.168.11.83;Database=finbook_beta_contact;Uid=root;Pwd=root;Encrypt=true"));
            services.AddCap(options =>
            {
                options
                    .UseEntityFramework<MYDbContext>()
                    .UseRabbitMQ("localhost");//TBD
                // If you are using Dapper,you need to add the config：
                //options.UseMySql("Server=192.168.11.83;Database=finbook_metadata;Uid=root;Pwd=root;Encrypt=true");

                // If your Message Queue is using RabbitMQ you need to add the config：
                //options.UseRabbitMQ("localhost");

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCap();
        }
    }
}
