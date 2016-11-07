using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Common
{
    public class ResultModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回结果信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 需要返回到客户端的数据
        /// </summary>
        public object ResultData { get; set; }

        public ResultModel()
            : this(200, "操作成功")
        { }

        public ResultModel(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public void SetErrorDefault()
        {
            this.Code = 500;
            this.Message = "操作失败";
            this.ResultData = string.Empty;
        }
    }
}
