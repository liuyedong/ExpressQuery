using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressQuery
{
    public class ExpressEntity
    {

        public string ExpressNo;
        public string Company;
    }
    public class ExpressQueryResult
    {
        public int Status { get; set; }
        public string Msg { get; set; }
        public List<ExpressDetail> Result { get; set; }
    }
    public class ExpressDetail
    {
        public DateTime ModifyTime { get; set; }
        public string Message { get; set; }
    }
}
