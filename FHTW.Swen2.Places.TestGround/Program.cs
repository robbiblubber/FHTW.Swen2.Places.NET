using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Util;
using Microsoft.Data.Sqlite;

namespace FHTW.Swen2.Places.TestGround
{
    internal class Program
    {
        private static readonly ILog _Log = LogManager.GetLogger(typeof(Program));


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!\n");

            //LogLog.InternalDebugging = true;

            
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            LogManager.GetRepository().Threshold = Level.Debug;

            _Log.Info("Hello, World!");
        }
    }
}