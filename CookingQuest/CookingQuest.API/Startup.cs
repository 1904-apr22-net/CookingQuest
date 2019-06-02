using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingQuest.Data.Entities;
using CookingQuest.Data.Repository;
using CookingQuest.Library.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CookingQuest.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string AllowLocalAngularAllMethods = "_AllowLocalAngularAllMethods";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<CookingQuestContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("CookingQuest")));

            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<IEquipmentRepo, EquipmentRepo>();
            services.AddScoped<IFlavorRepo, FlavorRepo>();
            services.AddScoped<ILocationRepo, LocationRepo>();
            services.AddScoped<ILootRepo, LootRepo>();
            services.AddScoped<IPlayerRepo, PlayerRepo>();
            services.AddScoped<IRecipeRepo, RecipeRepo>();
            services.AddScoped<IStoreRepo, StoreRepo>();
            services.AddCors(options =>
            {
                options.AddPolicy(AllowLocalAngularAllMethods,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200",
                                    "https://cookingquestng.azurewebsites.net", "http://cookingquestng.azurewebsites.net").AllowAnyMethod().AllowAnyHeader();
                    });
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(AllowLocalAngularAllMethods);
            app.UseMvc();
        }
    }
}
