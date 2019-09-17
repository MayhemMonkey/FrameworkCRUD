using System;
using Framework.CRUD.Middleware;
using Framework.CRUD.Models;
using Framework.CRUD.Repo;
using Framework.CRUD.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.CRUD.Configure
{
    public class AutoConfigure
    {

        public static void AutoConfigureDefaultCrudFramework<TO, TI>(IServiceCollection services)
        {
//            services.AddSingleton(typeof(ICrudRepo<TO, TI>), 
//                typeof(DefaultRepo));
//            
//            services.AddSingleton(typeof(ICrudService<TO, TI>), 
//                typeof(DefaultCrudService));
//            
//            services.AddSingleton<DefaultRepo>();
//            services.AddSingleton<DefaultCrudService>();
        }

        public static void AutoConfigureMiddleWareCrudFramework(IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));
        }
    }
}