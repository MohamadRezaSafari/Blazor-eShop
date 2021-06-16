using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.UseCases.SearchProductScreen;
using eShop.UseCases.ViewProductScreen;
using eShop.UseCases.ViewProductScreen.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using eShop.UseCases.ShoppingCartScreen.Interfaces;
using eShop.UseCases.ShoppingCartScreen;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.StateStore.DI;

namespace eShop.Web
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
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
            services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
            services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
            services.AddTransient<IShoppingCart, ShoppingCart.LocalStorage.ShoppingCart>();
            services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
            services.AddTransient<IShoppingCartStateStore, ShoppingCartStateStore>(); 
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
