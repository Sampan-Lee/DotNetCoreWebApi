using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters.Json.Internal;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace CoreApi.DTO
{
    public class ReturnResult : JsonResult
    {
        public ReturnResult(object value) : base(value)
        {
            this.Value = new ResultValue(value);
        }
        public ReturnResult(int StatusCode, string Message) : base(new ResultValue(StatusCode, Message))
        {
            this.Value = base.Value;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override void ExecuteResult(ActionContext context)
        {
            base.ExecuteResult(context);
        }
        public override Task ExecuteResultAsync(ActionContext context)
        {
            return base.ExecuteResultAsync(context);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class ResultValue {
        /// <summary>
        /// 正常返回值
        /// </summary>
        /// <param name="value">返回值数据</param>        
        public ResultValue(object value)
        {
            this.Status = true;
            this.StatusCode = 200;
            this.Message = string.Empty;
            this.data = value;
        }
        /// <summary>
        /// 异常返回值
        /// </summary>
        /// <param name="StatusCode">异常状态码</param>
        /// <param name="Message">异常信息</param>
        public ResultValue(int StatusCode, string Message)
        {
            this.Status = false;
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.data = null;
        }
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object data { get; set; }
    }
}
