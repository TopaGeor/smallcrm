using Microsoft.AspNetCore.Mvc;
using SmallCrm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCrm.Web.Extensions
{
    public static class ApiResultExtensions
    {
        public static ObjectResult AsStatusResult<T>(this ApiResult<T> @this)
        {
            var result = new ObjectResult(@this);

            result.StatusCode = (int)@this.ErrorCode;

            if (@this.Success)
            {
                result.Value = @this.Data;
            }
            else
            {
                result.Value = @this.ErrorText;
            }


            return result;
        }
    }
}
