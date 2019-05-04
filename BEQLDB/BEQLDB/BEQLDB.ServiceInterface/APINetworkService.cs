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
            Expression<Func<ServiceModel.Network, bool>> filter = x => (request.nameNetwork == null || x.nameNetwork.Contains(request.nameNetwork));
            var netWorkEntities = await _netWorkService.GetAll(filter: filter);
            var response = new BaseResponse();
            
            response.Message = "Get networks successfully";
            response.Results = netWorkEntities;
            return response;
        }

        public async Task<object> GET(NetworkById request)
        {
            var response = new BaseResponse();
            Expression<Func<ServiceModel.Network, bool>> keySelector = x => x.id == request.id;
            var networkByID = await _netWorkService.GetById(keySelector: keySelector);

            response.Message = $"Get network by ID:{request.id} successfully";
            response.Results = networkByID;
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
            var result = await _netWorkService.Delete(keySelector);

            response.Message = "Deleted network successfully";
            return response;
        }
        public async Task<object> PUT(UpdateNetwork request)
        {
            var response = new BaseResponse();
            Expression<Func<ServiceModel.Network, bool>> keySelector = x => x.id == request.id;
            var networkUp = await _netWorkService.GetById(keySelector);
            networkUp.nameNetwork = request.nameNetwork;
            await _netWorkService.Update(networkUp);

            response.Message = "Updated network successfully";
            return response;
        }


    }
}
