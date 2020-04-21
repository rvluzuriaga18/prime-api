using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Prime.Account.API.Startup))]

namespace Prime.Account.API
{
    public partial class Startup
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Configuration(IAppBuilder app)
        {
            log4net.Config.XmlConfigurator.Configure();
            Logger.Info("PrimeAPI Logger has been configured.");

            ConfigureOAuth(app);
        }
    }
}