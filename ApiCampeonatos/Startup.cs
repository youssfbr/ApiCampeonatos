using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ApiCampeonatos.Entities;
using ApiCampeonatos.Helpers;
using ApiCampeonatos.Services;

namespace ApiCampeonatos
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
     
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");            
            string mySqlConnection;

            services.AddDbContext<AppDbContext>(options => 
            {
                if (env == "Development")
                {
                    mySqlConnection = Configuration.GetConnectionString("DefaultConnection");
                    options.UseMySql(mySqlConnection,
                    ServerVersion.AutoDetect(mySqlConnection));
                }
                else
                {
                    var connUrl = Environment.GetEnvironmentVariable("CLEARDB_DATABASE_URL");
                    connUrl = connUrl.Replace("mysql://", string.Empty);                    
                    var userPassSide = connUrl.Split("@")[0];                       
                    var hostSide = connUrl.Split("@")[1];                       

                    var connUser = userPassSide.Split(":")[0];                   
                    var connPass = userPassSide.Split(":")[1];                   
                    var connHost = hostSide.Split("/")[0];                   
                    var connDb = hostSide.Split("/")[1].Split("?")[0];

                    mySqlConnection = $"server={connHost};Uid={connUser};Pwd={connPass};Database={connDb}";
                    options.UseMySql(mySqlConnection,
                    ServerVersion.AutoDetect(mySqlConnection));
                }                   
            });   

            services.AddCors();
            services.AddControllers();
            
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            
            services.AddScoped<IUserService, UserService>();       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {  
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
