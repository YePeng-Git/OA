using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Common
{
    public class JsonResultHelper
    {
        /// <summary>
        /// 执行结果 
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 记录列表
        /// </summary>
        public object rows { get; set; }

        /// <summary>
        /// 记录对象
        /// </summary>
        public object obj { get; set; }

        /// <summary>
        /// 记录数量
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public JsonResultHelper()
        {
            this.success = false;
            this.msg = "";
            this.rows = null;
            this.obj = null;
            this.total = 0;
        }
    }
}
