using Framework.CRUD.Middleware;
using Framework.CRUD.Models;
using Framework.CRUD.Repo;
using Framework.CRUD.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.CRUD.Configure
{
    public static class AutoConfigure
    {

        public static void AutoConfigureDefaultCrudFramework<TO, TI>(IServiceCollection services) where TO : IDefaultEntity
        {
            services.AddSingleton(typeof(ICrudRepo<TO, TI>), 
                typeof(DefaultRepo<TO>));
            
            services.AddSingleton(typeof(ICrudService<TO, TI>), 
                typeof(DefaultCrudService<TO>));
            
            services.AddSingleton<DefaultRepo<TO>>();
            services.AddSingleton<DefaultCrudService<TO>>();
        }

        public static void AutoConfigureMiddleWareCrudFramework(IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));
        }
    }
}