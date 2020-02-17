using System;
using System.Collections.Generic;
using System.Text;

namespace SmallCrm.Core
{
    public class ApiResult<T>
    {
        public StatusCode ErrorCode { get; set; }
        public string ErrorText { get; set; }

        public T Data { get; set; }

        public ApiResult()
        {

        }

        public ApiResult(StatusCode errorCode, string errorString)
        {
            ErrorCode = errorCode;
            ErrorText = errorString;
        }
    }
}
