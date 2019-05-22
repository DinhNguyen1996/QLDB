using BEQLDB.ServiceInterface;
using BEQLDB.ServiceInterface.DAL.Repository;
using BEQLDB.ServiceInterface.DAL.UnitOfWork;
using BEQLDB.ServiceInterface.IServices;
using BEQLDB.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Imp
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Contact> _contactRepo;
        private readonly QLDBContext _context;

        public ContactService(IUnitOfWork unitOfWork, IGenericRepository<Contact> contactRepo, QLDBContext context)
        {
            _unitOfWork = unitOfWork;
            _contactRepo = contactRepo;
            _context = context;
        }

        public bool Create(Contact contact)
        {
            _contactRepo.Create(contact);
            _unitOfWork.Save();
            return true;
        }

        public bool Delete(int id)
        {
            _contactRepo.Delete(id);
            _unitOfWork.Save();
            return true;
        }

        public List<Contact> GetAll()
        {
            var listContact = _contactRepo.GetAll();
            return listContact?.ToList();
        }

        public Contact GetById(int id)
        {
            var contact = _contactRepo.GetById(id);
            return contact;
        }

        public string GetPhoneNumberByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Contact contact)
        {
            var contactUpdate = _contactRepo.GetById(contact.id);
            if (contactUpdate != null)
            {
                contactUpdate.name = contact.name;
                contactUpdate.phoneNumber = contact.phoneNumber;
                contactUpdate.notes = contact.notes;
                contactUpdate.myFavourite = contact.myFavourite;
                contactUpdate.gender = contact.gender;
                contactUpdate.NetworkId = contact.NetworkId;

                _contactRepo.Update(contactUpdate);
                _unitOfWork.Save();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
