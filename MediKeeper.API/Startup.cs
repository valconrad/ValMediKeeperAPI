using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using MediKeeper.Application.Item;
using MediKeeper.Persistence;
using MediKeeper.Persistence.Items;
using Microsoft.OpenApi.Models;

namespace MediKeeper.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MediKeeper API", Version = "v1" });
            });



            services.AddControllers();

            services.AddDbContext<MediKeeperDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("MediKeeper")); 
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddTransient<IItemRepository, ItemRepository>();

            services.AddTransient<IItemManager, ItemManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediKeeper API V1");
            });
        }
    }
}
