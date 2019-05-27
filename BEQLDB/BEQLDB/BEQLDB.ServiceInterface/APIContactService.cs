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

        public async Task<object> GET(ContactById request)
        {
            var response = new BaseResponse();
            //Expression<Func<ServiceModel.Contact, bool>> keySelector = x => x.id == request.id;
            //var contactByID = await _contactService.GetById(keySelector, includeProperties:"Network");
            //var dto = contactByID.ConvertTo<ContactDTO>();
            //dto.NetworkName = contactByID.Network.nameNetwork;
            var contact = await _contactService.GetById(request.id);

            response.Results = contact;
            response.Message = $"Get contact by ID:{request.id} successfully";
            
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
            var result = await _contactService.Create(crtContact);

            response.Results = result;
            if ((bool)response.Results == true)
            {
                response.Message = "Created contact successfully";
            }
            else
            {
                response.Message = "Created contact failed";
            }
            return response;
        }

        public async Task<object> PUT(UpdateContact request)
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

            response.Results = await _contactService.Update(contactUp);
            if ((bool)response.Results == true)
            {
                response.Message = "Updated contact successfully";
            }
            else
            {
                response.Message = "Updated contact failed";
            }

            return response;
        }

        public async Task<object> DELETE(ContactById request)
        {
            var response = new BaseResponse();
            response.Results = await _contactService.Delete(request.id);
            if ((bool)response.Results == true)
            {
                response.Message = "Deleted contact successfully";
            }
            else
            {
                response.Message = "Deleted contact failed";
            }
            return response;
        }

        public string GetPhoneNumberByName(string name)
        {
            var number = _contactService.GetPhoneNumberByName(name);
            return number;
        }
    }

}
