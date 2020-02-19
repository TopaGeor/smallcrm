using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallCrm.Core.Services
{
    public static class test
    {
        //public static Log Name(StatusCode code, string text);

        public static Serilog.Core.Logger Information(this String text)
        {
            return new LoggerConfiguration().WriteTo.File("log.txt").CreateLogger();
        }
    }
}
