﻿using BEQLDB.ServiceModel;
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
        public NetworkService(QLDBContext context)
        {
            _context = context;
        }
        public object GET(GetNetWork request)
        {
            var network = _context.Networks;
            var response = new BaseResponse();

            response.Success = true;
            response.StatusCode = (int)HttpStatusCode.OK;
            response.Message = "Get networks successfully";
            response.Results = network;
            return response;
        }
        public object POST(CreateNetwork request)
        {
            var response = new BaseResponse();
            var crtNetwork = new ServiceModel.Network();
            crtNetwork.nameNetwork = request.nameNetwork;

            _context.Networks.Add(crtNetwork);
            _context.SaveChanges();

            response.Success = true;
            response.StatusCode = (int)HttpStatusCode.OK;
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

            response.Success = true;
            response.StatusCode = (int)HttpStatusCode.OK;
            response.Message = "Deleted network successfully";
            return response;
        }
        public object PUT(UpdateNetwork request)
        {
            var response = new BaseResponse();
            var networkUp = _context.Networks.SingleOrDefault(x => x.id == request.id);
            if(networkUp == null)
            {
                response.Message = "ID network is not correct";
                return response;
            }
            networkUp.nameNetwork = request.nameNetwork;
            _context.Networks.Update(networkUp);
            _context.SaveChanges();

            response.Success = true;
            response.StatusCode = (int)HttpStatusCode.OK;
            response.Message = "Updated network successfully";
            return response;
        }


    }
}
