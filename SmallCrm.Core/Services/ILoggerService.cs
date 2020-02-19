using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallCrm.Core.Services
{
    public interface ILoggerService 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        Serilog.Core.Logger Error(StatusCode code, string text);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Serilog.Core.Logger Information(string text);
    }
}
