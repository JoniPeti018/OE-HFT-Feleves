using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OGT2SA_HFT_2021221.Data;
using OGT2SA_HFT_2021221.Logic;
using OGT2SA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IAnimeLogic, AnimeLogic>();
            services.AddTransient<ICharacterLogic, CharacterLogic>();
            services.AddTransient<IStudioLogic, StudioLogic>();
            services.AddTransient<IAnimeRepository, AnimeRepository>();
            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<IStudioRepository, StudioRepository>();
            services.AddTransient<AnimeDataDbContext, AnimeDataDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
