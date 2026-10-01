using System.Web.Http;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // BẮT BUỘC: Kích hoạt tính năng đọc các thẻ định tuyến [Route] và [RoutePrefix] ở Backend của bạn
            config.MapHttpAttributeRoutes();

            // Cấu hình đường dẫn API mặc định
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
