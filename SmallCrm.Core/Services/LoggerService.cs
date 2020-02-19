using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallCrm.Core.Services
{
    public class LoggerService : ILoggerService
    {
        public Serilog.Core.Logger Logger;
        public LoggerService()
        {
            Logger = new LoggerConfiguration().WriteTo.File("log.txt").CreateLogger();
        }

        public Serilog.Core.Logger Error(StatusCode code, string text)
        {
            throw new NotImplementedException();
        }

        public Serilog.Core.Logger Information(string text)
        {
            throw new NotImplementedException();
        }
    }
}
