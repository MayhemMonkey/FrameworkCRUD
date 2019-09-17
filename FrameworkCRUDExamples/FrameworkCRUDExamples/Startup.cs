using System;
using Framework.CRUD.Configure;
using Framework.CRUD.Models;
using Framework.CRUD.Repo;
using Framework.CRUD.Services;
using FrameworkCRUDExamples.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace FrameworkCRUDExamples
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
//            AutoConfigure.AutoConfigureDefaultCrudFramework<Person, Guid>(services);

            services.AddSingleton<ICrudService<Person, Guid>, DefaultCrudService<Person>>();
            services.AddSingleton<DefaultCrudService<Person>>();
            services.AddSingleton<ICrudRepo<Person, Guid>, DefaultRepo<Person>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            AutoConfigure.AutoConfigureMiddleWareCrudFramework(app);
            app.UseMvc();
        }
    }
}