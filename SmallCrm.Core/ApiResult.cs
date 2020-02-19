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

        public bool Success => ErrorCode == StatusCode.ok;

        public ApiResult()
        {

        }

        public ApiResult(StatusCode errorCode, string errorString)
        {
            ErrorCode = errorCode;
            ErrorText = errorString;
        }

        public ApiResult<U> ConvertResult<U>()
        {
            var res = new ApiResult<U>()
            { 
                ErrorCode = ErrorCode,
                ErrorText = ErrorText
            };
            return res;
        }

        public static ApiResult<T> CreateSucces(T Data)
        {
            var res = new ApiResult<T>()
            {
                ErrorCode = StatusCode.ok,
                Data = Data
            };
            return res;
        }
    }
}
