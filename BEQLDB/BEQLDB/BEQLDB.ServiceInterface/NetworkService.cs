using BEQLDB.ServiceInterface.DAL.Interface;
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
        private QLDBContext _context { get; set; }
        private INetworkRepository _iNetworkRepository;

        public NetworkService(QLDBContext context, INetworkRepository iNetworkRepository)
        {
            _context = context;
            _iNetworkRepository = iNetworkRepository;
        }
        public object GET(GetNetWork request)
        {
            var network = _context.Networks;
            var response = new BaseResponse();
            
            response.Message = "Get networks successfully";
            response.Results = network;
            return response;
        }
        public object POST(CreateNetwork request)
        {
            var response = new BaseResponse();
            var crtNetwork = new ServiceModel.Network();
            crtNetwork.id = request.id;
            crtNetwork.nameNetwork = request.nameNetwork;
            _iNetworkRepository.Create(crtNetwork);
            //_context.Networks.Add(crtNetwork);
            //_context.SaveChanges();

            response.Message = "Created network successfully";
            return response;
        }
        public object DELETE(NetworkById request)
        {
            var response = new BaseResponse();
            var networkDel = _context.Networks.FirstOrDefault(x => x.id == request.id);
            if (networkDel == null)
            {
                response.Message = "ID network is not correct";
                return response;
            }
            _context.Networks.Remove(networkDel);
            _context.SaveChanges();

            response.Message = "Deleted network successfully";
            return response;
        }
        public object PUT(UpdateNetwork request)
        {
            var response = new BaseResponse();
            var networkUp = _context.Networks.SingleOrDefault(x => x.id == request.id);
            if (networkUp == null)
            {
                response.Message = "ID network is not correct";
                return response;
            }
            networkUp.nameNetwork = request.nameNetwork;
            _context.Networks.Update(networkUp);
            _context.SaveChanges();

            response.Message = "Updated network successfully";
            return response;
        }


    }
}
