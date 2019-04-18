using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressQuery
{
    public interface IExpressQuery
    {
        string ApiName { get; }
        string QueryUrl { get; }
        string ExpressQuery(ExpressEntity entity);
    }
}
