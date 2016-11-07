using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Common.Enums
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum OptType
    {
        /// <summary>
        /// 登录
        /// </summary>
        [EnumHelper("登录")]
        Login = 1,
        /// <summary>
        /// 添加
        /// </summary>
        [EnumHelper("添加")]
        Add = 2,
        /// <summary>
        /// 修改
        /// </summary>
        [EnumHelper("修改")]
        Modify = 3,
        /// <summary>
        /// 删除
        /// </summary>
        [EnumHelper("删除")]
        Delete = 4,
        /// <summary>
        /// 导入
        /// </summary>
        [EnumHelper("导入")]
        Import = 5,
        /// <summary>
        /// 导出
        /// </summary>
        [EnumHelper("导出")]
        Export = 6,
        /// <summary>
        /// 其他
        /// </summary>
        [EnumHelper("其他")]
        Else = 7,
    }
}
