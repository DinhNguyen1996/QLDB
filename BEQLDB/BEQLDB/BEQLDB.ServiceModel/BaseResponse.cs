using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceModel
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public object Results { get; set; } = null;
    }
}
