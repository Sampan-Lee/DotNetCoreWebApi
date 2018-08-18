using CoreApi.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Tools
{
    public static class ResultHelper
    {
        public static JsonResult ToJsonResult(this object obj)
        {
            return new ReturnResult(obj);            
        }
        /// <summary>
        /// 请求异常返回值
        /// </summary>
        /// <param name="StatusCode">异常状态码</param>
        /// <param name="Message">异常信息</param>
        /// <returns></returns>
        public static JsonResult ToExceptionResult(int StatusCode,string Message)
        {
            return new ReturnResult(StatusCode, Message);
        }
    }
}
