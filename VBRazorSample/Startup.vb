Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.AspNetCore.Http
Imports Microsoft.AspNetCore.HttpsPolicy
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Mvc.ViewEngines
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Options

Public Class Startup

    Public Sub New(ByVal configuration As IConfiguration)

        Me.Configuration = configuration
    End Sub

    Public ReadOnly Property Configuration() As IConfiguration

    ' This method gets called by the runtime. Use this method to add services to the container.
    Public Sub ConfigureServices(ByVal services As IServiceCollection)

        services.Configure(Of CookiePolicyOptions)(
            Sub(options)
                ' This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = Function(context) True
                options.MinimumSameSitePolicy = SameSiteMode.None
            End Sub)

        services.AddTransient(Of IConfigureOptions(Of MvcViewOptions), VBRazor.VBRazorMvcViewOptionsSetup)()
        services.AddSingleton(Of IViewEngine, VBRazor.VBRazorViewEngine)()


        services.AddMvc().AddNewtonsoftJson()

    End Sub

    ' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IHostingEnvironment)

        If env.IsDevelopment() Then
            app.UseDeveloperExceptionPage()

        Else
            app.UseExceptionHandler("/Home/Error")
            ' The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts()
        End If

        app.UseHttpsRedirection()

        app.UseStaticFiles()

        app.UseRouting(Sub(routes)
                           routes.MapApplication()
                           routes.MapControllerRoute(name:="default", template:="{controller=Home}/{action=Index}/{id?}")

                       End Sub)

        app.UseCookiePolicy()

        app.UseAuthorization()

    End Sub

End Class
