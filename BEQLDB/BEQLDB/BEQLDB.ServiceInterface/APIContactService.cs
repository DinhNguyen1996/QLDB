using BEQLDB.ServiceInterface.IServices;
using BEQLDB.ServiceModel;
using BEQLDB.ServiceModel.DTOs;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface
{
    public class APIContactService : ServiceStack.Service
    {

        private readonly IContactService _contactService;
        public APIContactService(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<object> GET(GetALLContact request)
        {
            var response = new BaseResponse();
            Expression<Func<ServiceModel.Contact, bool>> filter = x => (request.name == null || x.name.Contains(request.name))
                                                                    && (request.phoneNumber == null || x.phoneNumber.Contains(request.phoneNumber))
                                                                    && (request.notes == null || x.notes.Contains(request.notes));
            var contactEntities = await _contactService.GetAll(filter: filter, includeProperties:"Network");
            var contactDtos = contactEntities.ToList().ConvertAll(x =>
            {
                var dto = x.ConvertTo<ContactDTO>();
                dto.NetworkName = x.Network.nameNetwork;
                return dto;
            });

            response.Message = "Get contact successfully";
            response.Results = contactDtos;
            return response;
        }

        public async Task<object> GET(ContactById request)
        {
            var response = new BaseResponse();
            Expression<Func<ServiceModel.Contact, bool>> keySelector = x => x.id == request.id;
            var contactByID = await _contactService.GetById(keySelector: keySelector, includeProperties:"Network");
            var dto = contactByID.ConvertTo<ContactDTO>();
            dto.NetworkName = contactByID.Network.nameNetwork;

            response.Message = $"Get contact by ID:{request.id} successfully";
            response.Results = dto;
            return response;
        }

        public async Task<object> POST(CreateContact request)
        {
            var response = new BaseResponse();
            var crtContact = new Contact()
            {
                id = request.id,
                name = request.name,
                phoneNumber = request.phoneNumber,
                notes = request.notes,
                myFavourite = request.myFavourite,
                gender = request.gender,
                NetworkId = request.NetworkId
            };
            await _contactService.Create(crtContact);

            response.Message = "Created contact successfully";
            return response;
        }

        public async Task<object> PUT(UpdateContact request)
        {
            var response = new BaseResponse();
            Expression<Func<ServiceModel.Contact, bool>> keySelector = x => x.id == request.id;
            var contactUp = await _contactService.GetById(keySelector: keySelector);
           
            contactUp.name = request.name;
            contactUp.phoneNumber = request.phoneNumber;
            contactUp.notes = request.notes;
            contactUp.myFavourite = request.myFavourite;
            contactUp.gender = request.gender;
            contactUp.NetworkId = request.NetworkId;
            await _contactService.Update(contactUp);

            response.Message = "Updated contact successfully";
            return response;
        }

        public async Task<object> DELETE(ContactById request)
        {
            var response = new BaseResponse();
            Expression<Func<ServiceModel.Contact, bool>> keySelector = x => x.id == request.id;
            await _contactService.Delete(keySelector: keySelector);

            response.Message = "Deleted contact successfully";
            return response;
        }
    }

}
