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

        public object GET(GetNetWork request)
        {
            //Expression<Func<ServiceModel.Network, bool>> filter = x => (request.nameNetwork == null || x.nameNetwork.Contains(request.nameNetwork));
            //var netWorkEntities = await _netWorkService.GetAll(filter: filter);
            var response = new BaseResponse();
            var listNetwork = _netWorkService.GetAll();

            response.Message = "Get networks successfully";
            response.Results = listNetwork;
            return response;
        }

        public object GET(NetworkById request)
        {
            //Expression<Func<ServiceModel.Network, bool>> keySelector = x => x.id == request.id;
            //var networkByID = await _netWorkService.GetById(keySelector: keySelector);
            var network = _netWorkService.GetById(request.id);
            var response = new BaseResponse();

            response.Message = $"Get network by ID:{request.id} successfully";
            response.Results = network;
            if (network != null)
            {
                response.Message = $"Get network by ID:{request.id} successfully";
            }
            else
            {
                response.Message = $"ID:{request.id} is not exist!";
            }
            return response;
        }

        public object POST(CreateNetwork request)
        {
            var response = new BaseResponse();
            var crtNetwork = new ServiceModel.Network()
            {
                id = request.id,
                nameNetwork = request.nameNetwork
            };
            var result = _netWorkService.Create(crtNetwork);

            response.Results = result;
            if ((bool)response.Results == true)
            {
                response.Message = "Created network successfully";
            }
            else
            {
                response.Message = "Created network failed";
            }
            return response;
        }
        public object DELETE(NetworkById request)
        {
            var response = new BaseResponse();
            //Expression<Func<ServiceModel.Network, bool>> keySelector = x => x.id == request.id;
            //var result = await _netWorkService.Delete(keySelector);

            response.Results = _netWorkService.Delete(request.id);
            if ((bool)response.Results == true)
            {
                response.Message = "Deleted network successfully";
            }
            else
            {
                response.Message = "Deleted network failed";
            }
            return response;
        }
        public object PUT(UpdateNetwork request)
        {
            var response = new BaseResponse();
            //Expression<Func<ServiceModel.Network, bool>> keySelector = x => x.id == request.id;
            var networkUp = new ServiceModel.Network
            {
                id = request.id,
                nameNetwork = request.nameNetwork
            };


            response.Results = _netWorkService.Update(networkUp);
            if ((bool)response.Results == true)
            {
                response.Message = "Updated network successfully";
            }
            else
            {
                response.Message = "Updated network failed";
            }
            return response;
        }


    }
}
