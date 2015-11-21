namespace WebApplication1
{
    using System.Web.Http;
    using App_Start;
    using SourceControlSystem.Common.Constants;
    using System.Reflection;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
