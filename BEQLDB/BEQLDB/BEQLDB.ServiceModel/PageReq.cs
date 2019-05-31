using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceModel
{
    public class PageReq
    {
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
    }
}
