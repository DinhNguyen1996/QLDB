using BEQLDB.ServiceModel;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface
{
    class NetworkService : Service
    {
        public object GET(GetNetWork request)
        {


            var response = new BaseResponse();
            response.Success = true;
            response.StatusCode = (int)HttpStatusCode.OK;
            response.Message = "Get Network successfully";
            response.Results = Db;
            return response;
        }
    }
}
