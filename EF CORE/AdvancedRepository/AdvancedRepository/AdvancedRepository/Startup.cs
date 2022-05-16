using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.Data;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.Repository.Classes;
using AdvancedRepository.Repository.Interfaces;
using AdvancedRepository.UnitofWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository
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
            services.AddDistributedMemoryCache();//Session için
            services.AddSession(options =>
            {
                        //Session için 
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });



            services.AddDbContext<SirketContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("Baglanti")));

            services.AddScoped<IProductsRepos,ProductsRepos>();
            services.AddScoped<IUnitsRepos, UnitsRepos>();
            services.AddScoped<ProductsModel>();
            services.AddScoped<ICategoriesRepos, CategoriesRepos>();
            services.AddScoped<ISuppliersRepos, SuppliersRepos>();
            services.AddScoped<CategoriesModel>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<UnitsModel>();
            services.AddScoped<IEmployeesRepos, EmployeesRepos>();
            services.AddScoped<ICountiesRepos, CountiesRepos>();
            services.AddScoped<CountiesModel>();
            services.AddScoped<EmployeesModel>();
            services.AddScoped<ICustomersRepos, CustomersRepos>();
            services.AddScoped<CustomersModel>();
            services.AddScoped<ICitiesRepos, CitiesRepos>();
            services.AddScoped<CitiesModel>();

            services.AddScoped<IFatMasterRepos, FatMasterRepos>();
            services.AddScoped<FatMasterModel>();
            services.AddScoped<FatDetailModel>();
            services.AddScoped<IFatDetailRepos, FatDetailRepos>();
            services.AddScoped<IAuthRepos, AuthRepos>();
            services.AddScoped<LoginModel>();
            services.AddScoped<Users>();

            services.AddScoped<IBasketMasterRepos, BasketMasterRepos>();
            services.AddScoped<IBasketDetailRepos, BasketDetailRepos>();

            services.AddScoped<BasketModel>();
            services.AddScoped<List<Basket>>();//?? neden yazdık?
            services.AddScoped<Basket>();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();   //Buradaki sıra önemli 
            app.UseSession();       //SEssion için ekledik

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
