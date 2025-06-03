using System.IO;
using System.Reflection;
using System.Windows;

using log4net;
using log4net.Config;
using log4net.Repository;

namespace FHTW.Swen2.Places
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App: Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //log4net.Util.LogLog.InternalDebugging = true;

            ILoggerRepository repo = LogManager.GetRepository(Assembly.GetEntryAssembly()!);
            XmlConfigurator.Configure(repo, new FileInfo("log4net.config"));

            ILog log = LogManager.GetLogger(typeof(App));
            log.Info("Started logging.");
        }
    }

}
