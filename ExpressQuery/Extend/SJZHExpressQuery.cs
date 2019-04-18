using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExpressQuery
{
    public class SJZHExpressQuery : IExpressQuery
    {
        /// <summary>
        /// 数据智汇
        /// </summary>
        public string ApiName { get { return "数据智汇"; } }

        public string QueryUrl { get { return "http://api.shujuzhihui.cn/api/sjzhApi/searchExpress"; } }
        public string appKey;
        public SJZHExpressQuery()
        {
            appKey = "3450fa27aa0a4d948b132c7620727a48";
        }
        public string ExpressQuery(string expressno)
        {
            string querystringStr = string.Format("appKey={0}&expressNo={1}", appKey, expressno);
            var req = WebRequest.CreateHttp(QueryUrl + "?" + querystringStr);
            req.Method = "post";
            req.ContentType = "application/json";
            using (StreamWriter sw = new StreamWriter(req.GetRequestStream()))
            {
                sw.Write(querystringStr);
            }
            using (StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                var result = sr.ReadToEnd();
                return result;
            }
        }

        public ExpressQueryResult ConvertResult(string param)
        {
            ExpressQueryResult result = new ExpressQueryResult();
            var tt = Newtonsoft.Json.JsonConvert.DeserializeObject<SJZHExpressResult>(param);
            if (tt.ERRORCODE == 0)
            {
                result.Status = 0;
                result.Msg = "";
                result.Result = new List<ExpressDetail>();
                if (tt.RESULT != null)
                {
                    foreach (var item in tt.RESULT.context)
                    {
                        ExpressDetail detail = new ExpressDetail();
                        detail.ModifyTime = item.time;
                        detail.Message = item.desc;
                    }
                }
            }
            return result;

        }
    }
    public class SJZHExpressResult
    {
        public int ERRORCODE { get; set; }
        public SJZHExpressDetail RESULT { get; set; }
    }
    public class SJZHExpressDetail
    {
        /// <summary>
        /// 公司
        /// </summary>
        public string com { get; set; }
        public List<StatusDetail> context { get; set; }
    }
    public class StatusDetail
    {
        public DateTime time { get; set; }
        public string desc { get; set; }
    }
}
