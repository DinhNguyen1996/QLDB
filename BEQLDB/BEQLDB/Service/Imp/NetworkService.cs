using BEQLDB.ServiceInterface;
using BEQLDB.ServiceInterface.DAL.Repository;
using BEQLDB.ServiceInterface.DAL.UnitOfWork;
using BEQLDB.ServiceInterface.IServices;
using BEQLDB.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Imp
{
    public class NetworkService : INetworkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Network> _networkRepo;

        public NetworkService(IUnitOfWork unitOfWork, IGenericRepository<Network> networkRepo)
        {
            _unitOfWork = unitOfWork;
            _networkRepo = networkRepo;
        }

        public int Count()
        {
            return _networkRepo.GetAll().Count();
        }

        public async Task<bool> Create(Network network)
        {
            await _networkRepo.Create(network);
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            _networkRepo.Delete(id);
            await _unitOfWork.Save();
            return true;
        }

        public List<Network> GetAll()
        {
            var listNetwork = _networkRepo.GetAll();
            return listNetwork?.ToList();
        }

        public List<Network> GetAllWithPage(int pageSize, int pageIndex)
        {
            var listNetwork = _networkRepo.GetPage(pageSize, pageIndex);
            return listNetwork?.ToList();
        }

        public async Task<Network> GetById(int id)
        {
            var network = await _networkRepo.GetById(id);
            return network;
        }


        public async Task<bool> Update(Network network)
        {
            var networkUpdate = await _networkRepo.GetById(network.id);
            if (networkUpdate != null)
            {
                networkUpdate.nameNetwork = network.nameNetwork;

                _networkRepo.Update(networkUpdate);
                await _unitOfWork.Save();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
