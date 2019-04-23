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
    public class ContactService : ServiceStack.Service
    {
        private QLDBContext _context { get; set; }
        public ContactService(QLDBContext context)
        {
            _context = context;
        }

        public object GET(GetALLContact request)
        {
            var response = new BaseResponse();
            var contact = _context.Contacts;

            response.Message = "Get contact successfully";
            response.Results = contact;
            return response;
        }

        public object GET(ContactById request)
        {
            var response = new BaseResponse();
            var contactByID = _context.Contacts.FirstOrDefault(x => x.id == request.id);
            if(contactByID == null)
            {
                response.Message = "ID contact is not correct";
                return response;
            }

            response.Message = $"Get contact by ID:{request.id} successfully";
            response.Results = contactByID;
            return response;
        }

        public object POST(CreateContact request)
        {
            var response = new BaseResponse();
            var crtContact = new Contact();
            crtContact.id = request.id;
            crtContact.name = request.name;
            crtContact.phoneNumber = request.phoneNumber;
            crtContact.notes = request.notes;
            crtContact.myFavourite = request.myFavourite;
            crtContact.gender = request.gender;
            crtContact.NetworkId = request.NetworkId;
            _context.Contacts.Add(crtContact);
            _context.SaveChanges();

            response.Message = "Created contact successfully";
            return response;
        }

        public object PUT(UpdateContact request)
        {
            var response = new BaseResponse();
            var contactUp = _context.Contacts.SingleOrDefault(x => x.id == request.id);
            if(contactUp == null)
            {
                response.Message = "ID contact is not correct";
                return response;
            }
            contactUp.name = request.name;
            contactUp.phoneNumber = request.phoneNumber;
            contactUp.notes = request.notes;
            contactUp.myFavourite = request.myFavourite;
            contactUp.gender = request.gender;
            contactUp.NetworkId = request.NetworkId;
            _context.Contacts.Update(contactUp);
            _context.SaveChanges();

            response.Message = "Updated contact successfully";
            return response;
        }

        public object DELETE(ContactById request)
        {
            var response = new BaseResponse();
            var contactDel = _context.Contacts.FirstOrDefault(x => x.id == request.id);
            if (contactDel == null)
            {
                response.Message = "ID contact is not correct";
                return response;
            }
            _context.Contacts.Remove(contactDel);
            _context.SaveChanges();

            response.Message = "Deleted contact successfully";
            return response;
        }
    }

}
