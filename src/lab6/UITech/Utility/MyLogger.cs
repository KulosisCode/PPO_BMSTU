﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITech.Utility
{
    public class MyLogger : ILogger
    {
        //singleton pattern 
        private static MyLogger? instance;
        private static Logger? logger;

        private MyLogger() { }
        //singleton design pattern shown here
        public static MyLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new MyLogger();
            }
            return instance;
        }
        
        private Logger GetLogger(string theLogger)
        {
            if (MyLogger.logger == null)
            {
                MyLogger.logger = LogManager.GetLogger(theLogger);
            }
            return MyLogger.logger;
        }

        public void Debug(string message, string? arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Debug(message);
            else
                GetLogger("myAppLoggerRules").Debug(message, arg);
        }

        public void Error(string message, string? arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Error(message);
            else
                GetLogger("myAppLoggerRules").Error(message, arg);
        }

        public void Info(string message, string? arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Info(message);
            else
                GetLogger("myAppLoggerRules").Info(message, arg);
        }

        public void Warning(string message, string? arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Warn(message);
            else
                GetLogger("myAppLoggerRules").Warn(message, arg);
        }
    }
}
