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

        public object GET(GetALLContact request)
        {
            var response = new BaseResponse();
            //Expression<Func<ServiceModel.Contact, bool>> filter = x => (request.name == null || x.name.Contains(request.name))
            //                                                        && (request.phoneNumber == null || x.phoneNumber.Contains(request.phoneNumber))
            //                                                        && (request.notes == null || x.notes.Contains(request.notes));
            //var contactEntities = await _contactService.GetAll(filter, includeProperties:"Network");
            //var contactDtos = contactEntities.ToList().ConvertAll(x =>
            //{
            //    var dto = x.ConvertTo<ContactDTO>();
            //    dto.NetworkName = x.Network.nameNetwork;
            //    return dto;
            //});
            
            var listContact = _contactService.GetAll();
            response.Message = "Get contact successfully";
            response.Results = listContact;
            return response;

        }

        public object GET(ContactById request)
        {
            var response = new BaseResponse();
            //Expression<Func<ServiceModel.Contact, bool>> keySelector = x => x.id == request.id;
            //var contactByID = await _contactService.GetById(keySelector, includeProperties:"Network");
            //var dto = contactByID.ConvertTo<ContactDTO>();
            //dto.NetworkName = contactByID.Network.nameNetwork;
            var contact = _contactService.GetById(request.id);

            response.Message = $"Get contact by ID:{request.id} successfully";
            response.Results = contact;
            return response;
           
        }

        public object POST(CreateContact request)
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
            var result = _contactService.Create(crtContact);

            response.Message = "Created contact successfully";
            response.Results = result;
            return response;
        }

        public object PUT(UpdateContact request)
        {
            var response = new BaseResponse();
            var contactUp = new Contact
            {
                id = request.id,
                name = request.name,
                phoneNumber = request.phoneNumber,
                notes = request.notes,
                myFavourite = request.myFavourite,
                gender = request.gender,
                NetworkId = request.NetworkId,
            };

            response.Message = "Updated contact successfully";
            response.Results = _contactService.Update(contactUp);

            return response;
        }

        public object DELETE(ContactById request)
        {
            var response = new BaseResponse();
            response.Message = "Deleted contact successfully";
            response.Results = _contactService.Delete(request.id);
            return response;
        }

        public string GetPhoneNumberByName(string name)
        {
            var number = _contactService.GetPhoneNumberByName(name);
            return number;
        }
    }

}
