using BasicRepository.Models.Classes;
using BasicRepository.Models.Data;
using BasicRepository.Models.Repos;
using BasicRepository.Models.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepository
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
            services.AddControllersWithViews();
            services.AddDbContext<PerContext>(options =>                               //https://docs.microsoft.com/tr-tr/ef/core/miscellaneous/connection-strings buradan kopyalaiJSONun hemen altındaki   
        options.UseSqlServer(Configuration.GetConnectionString("Baglanti")));
            services.AddScoped<IBaseRepository<City>, BaseRepository<City>> (); // dependency of injection, IBaseRepository gördüğün yere BaseRepository göstericek , faydası: classtaki metotları değiştirirsek BaseRepository2 yaratırız burda yazarız büyük projelerde kullanabiliriz 
            services.AddScoped<IBaseRepository<Personel>, BaseRepository<Personel>>();
            // Interface  üzerinden modeli tanımlardık ama çok sık lullanılan bir şey olsaydı yani her kategoride yinelenen bir şey olsaydı!
            //  AddSingleton  bir kere tanımlar ilk tanımladığımız yerde kalır memoryden silinmez,dezavantajları da var örneğin ynei bir kategori tanomlandığında kullanıcı sayfaya yenilemesi gerekir gözükmesi için.
            //AddScoped tanımlı olduğusüslü parantez içinden(scopedan) çıktıktan sonra memoryden silinir
            services.AddScoped<CityModel>();
        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
