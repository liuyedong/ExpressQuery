using ExpressQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressQueryConsolel
{
    class Program
    {
        static void Main(string[] args)
        {


            SJZHExpressQuery query = new SJZHExpressQuery();
            var result = query.ExpressQuery("73111964768386");
            query.ConvertResult(result);
            Console.WriteLine(result);
            //AliyunExpressQuery query1 = new AliyunExpressQuery();
            //var result1 = query1.ExpressQuery("201653440897");
            //Console.WriteLine(result1);
            //JHExpressQuery queryjh = new JHExpressQuery();
            //var result2 = queryjh.ExpressQuery(new ExpressEntity() { ExpressNo = "3704922757290", Company = "申通" });
            //Console.WriteLine(result2);
            //YongyouExpressQuery queryyy = new YongyouExpressQuery();
            //var resultyy = queryyy.ExpressQuery(new ExpressEntity() { ExpressNo = "3704922757290", Company = "申通" });
            //Console.WriteLine(resultyy);
            Console.ReadKey();
        }
        static List<ExpressEntity> InitQuery()
        {
            List<ExpressEntity> expressList = new List<ExpressEntity>();
            expressList.Add(new ExpressEntity() { ExpressNo = "1131155670283", Company = "邮政EMS" });
            expressList.Add(new ExpressEntity() { ExpressNo = "448045039180", Company = "顺丰物流" });
            expressList.Add(new ExpressEntity() { ExpressNo = "73111964768386", Company = "中通" });
            expressList.Add(new ExpressEntity() { ExpressNo = "221534273114", Company = "申通" });
            expressList.Add(new ExpressEntity() { ExpressNo = "300241862634", Company = "安能" });
            expressList.Add(new ExpressEntity() { ExpressNo = "71013527169155", Company = "百世快递" });
            expressList.Add(new ExpressEntity() { ExpressNo = "8324911503", Company = "德邦" });
            expressList.Add(new ExpressEntity() { ExpressNo = "805297405320070035", Company = "圆通" });
            return expressList;
        }
    }

}
