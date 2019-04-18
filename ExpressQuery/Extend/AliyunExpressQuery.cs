using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExpressQuery
{
    /// <summary>
    /// 阿里云
    /// </summary>
    public class AliyunExpressQuery : IExpressQuery
    {
        private const String host = "https://wuliu.market.alicloudapi.com";
        private const String path = "/kdi";
        private const String method = "GET";
        private const String appcode = "85310a0684234bde834d634b2e5e5c6b";

        public string ApiName { get { return "阿里云"; } }

        public string QueryUrl { get { return "https://wuliu.market.alicloudapi.com"; } }

        public string ExpressQuery(string expressNo)
        {
            String querys = string.Format("no={0}&type=", expressNo);
            String bodys = "";
            String url = host + path;
            HttpWebRequest httpRequest = null;
            HttpWebResponse httpResponse = null;

            if (0 < querys.Length)
            {
                url = url + "?" + querys;
            }

            if (host.Contains("https://"))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                httpRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            }
            else
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            httpRequest.Method = method;
            httpRequest.Headers.Add("Authorization", "APPCODE " + appcode);
            if (0 < bodys.Length)
            {
                byte[] data = Encoding.UTF8.GetBytes(bodys);
                using (Stream stream = httpRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            try
            {
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
            }
            Stream st = httpResponse.GetResponseStream();
            StreamReader reader = new StreamReader(st, Encoding.GetEncoding("utf-8"));
            return reader.ReadToEnd();

        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        public ExpressQueryResult ConvertResult(string param)
        {
            var result = new ExpressQueryResult() { Status = -1 };
            var tt = Newtonsoft.Json.JsonConvert.DeserializeObject<AliyunExpressResult>(param);
            if (tt.status == 0)
            {
                result.Status = 0;
            }
            return result;

        }
    }
    public class AliyunExpressResult
    {
        public int status { get; set; }
        public string msg { get; set; }
        public int deliverystatus { get; set; }
        public int issign { get; set; }
        public string expName { get; set; }
        public string expSite { get; set; }
        public string logo
        {
            get; set;
        }
        public string expPhone { get; set; }
        public string courier { get; set; }
        public string courierPhone { get; set; }
        public List<AluyunExpressDetail> list { get; set; }
    }
    public class AluyunExpressDetail
    {
        public DateTime time { get; set; }
        public string status { get; set; }
    }
}
