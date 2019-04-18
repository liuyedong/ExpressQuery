using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressQuery
{
    /// <summary>
    /// 查询实体
    /// </summary>
    public class ExpressEntity
    {

        public string ExpressNo;
        public string Company;
    }
    /// <summary>
    /// 结果实体
    /// </summary>
    public class ExpressQueryResult
    {
        public int Status { get; set; }
        public string Msg { get; set; }
        public List<ExpressDetail> Result { get; set; }
    }
    /// <summary>
    /// 结果详情实体
    /// </summary>
    public class ExpressDetail
    {
        public DateTime ModifyTime { get; set; }
        public string Message { get; set; }
    }
}
