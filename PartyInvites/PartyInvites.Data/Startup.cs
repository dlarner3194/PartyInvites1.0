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
using PartyInvites.Data.Models;

namespace PartyInvites.Data
{
    public class Startup
    {
    //public Startup(IConfiguration configuration)
    //{
    //    Configuration = configuration;
    //}

        string _testSecret = null;
        public Startup(IHostingEnvironment env)
        {
          var builder = new ConfigurationBuilder();
          if (env.IsDevelopment())
          {
            builder.AddUserSecrets<Startup>();
          }

          Configuration = builder.Build();
        }    

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //in memory db
            //services.AddDbContext<GuestResponseContext>(opt =>
            //    opt.UseInMemoryDatabase("GuestList"));

            //sql server connection
            var connection = @"Server=desktop-gagc9ti\sqlexpress;Database=PartyInvitesDB;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<GuestResponseContext>(options => options.UseSqlServer(connection));

            _testSecret = Configuration["MySecret"];
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
