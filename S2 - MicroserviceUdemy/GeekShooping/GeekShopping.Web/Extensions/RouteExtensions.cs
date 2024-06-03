using GeekShopping.web.Areas.Product;

namespace GeekShopping.web.Extensions {
    public static class RouteExtensions {

        public static void UseCustomEndpoints(this IApplicationBuilder app) {

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                        name: "ProductsArea",
                        areaName: "Products",
                        pattern: "Products/{controller=Product}/{action=Index}/{id?}");

            });
        }
    }
}
