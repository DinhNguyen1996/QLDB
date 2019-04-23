using BEQLDB.ServiceInterface.DAL.Interface;
using BEQLDB.ServiceInterface.IServices;
using BEQLDB.ServiceModel;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface
{
    public class APINetworkService : ServiceStack.Service
    {
        private readonly INetworkService _netWorkService;

        public APINetworkService(INetworkService netWorkService)
        {
            _netWorkService = netWorkService;
        }

       

        public async Task<object> GET(GetNetWork request)
        {
            //var network = _context.Networks;
            Expression<Func<ServiceModel.Network, bool>> filter = x => (request.nameNetwork == null || x.nameNetwork.Contains(request.nameNetwork));
            var netWorkEntities = await _netWorkService.GetAll(filter: filter);
            var response = new BaseResponse();
            
            response.Message = "Get networks successfully";
            response.Results = netWorkEntities;
            return response;
        }

        public async Task<object> POST(CreateNetwork request)
        {
            var response = new BaseResponse();
            var crtNetwork = new ServiceModel.Network()
            {
                id = request.id,
                nameNetwork = request.nameNetwork
            };
            await _netWorkService.Create(crtNetwork);
           
            response.Message = "Created network successfully";
            return response;
        }
        public async Task<object> DELETE(NetworkById request)
        {
            var response = new BaseResponse();
            Expression<Func<ServiceModel.Network, bool>> keySelector = x => x.id == request.id;
            //if (keySelector == null)
            //{
            //    response.Message = "ID network is not correct";
            //    return response;
            //}
            var result = await _netWorkService.Delete(keySelector);

            response.Message = "Deleted network successfully";
            return response;
        }
        public async Task<object> PUT(UpdateNetwork request)
        {
            var response = new BaseResponse();
            //var networkUp = _context.Networks.SingleOrDefault(x => x.id == request.id);
            Expression<Func<ServiceModel.Network, bool>> keySelector = x => x.id == request.id;
            var networkUp = await _netWorkService.GetById(keySelector: keySelector);
           
            //if (networkUp == null)
            //{
            //    response.Message = "ID network is not correct";
            //    return response;
            //}
            networkUp.nameNetwork = request.nameNetwork;
         

            response.Message = "Updated network successfully";
            return response;
        }


    }
}
