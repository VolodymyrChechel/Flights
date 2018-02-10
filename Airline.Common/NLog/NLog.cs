using System;
using System.Reflection;
using NLog;
using NLog.Config;

namespace Airline.Common.NLog
{
    public static class NLog
    {
        private static string path, path1;
        private static XmlLoggingConfiguration conf, conf0, conf1, conf2, conf3;
        static NLog()
        {
            try
            {
             //   path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                path = Assembly.GetExecutingAssembly().CodeBase;
                path1 = Environment.CurrentDirectory;
                //LogManager.Configuration = new XmlLoggingConfiguration(@"../../NLog.config");
                 conf0 = new XmlLoggingConfiguration(@"../NLog.config");
                 conf = new XmlLoggingConfiguration(@"../../NLog.config");
                 conf1 = new XmlLoggingConfiguration(@"../../../NLog.config");
                 conf2 = new XmlLoggingConfiguration(@"../../../../NLog.config");
                 conf3 = new XmlLoggingConfiguration(@"../../../../../NLog.config");
            }
            catch (Exception e)
            {
                
            }
        }
        public static void LogTrace(Type declaringType, string message)
        {
            LogManager.GetLogger(declaringType.FullName).Trace(message);
        }

        public static void LogDebug(Type declaringType, string message)
        {
            LogManager.GetLogger(declaringType.FullName).Debug(message);
        }

        public static void LogInfo(Type declaringType, string message)
        {
            LogManager.GetLogger(declaringType.FullName).Info(message);
        }

        public static void LogWarn(Type declaringType, string message)
        {
            LogManager.GetLogger(declaringType.FullName).Warn(message);
        }

        public static void LogError(Type declaringType, string message)
        {
            LogManager.GetLogger(declaringType.FullName).Error(message);
        }

        public static void LogFatal(Type declaringType, string message)
        {
            LogManager.GetLogger(declaringType.FullName).Fatal(message);
        }
    }
}