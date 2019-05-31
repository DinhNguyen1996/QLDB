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

        public async Task<bool> Create(Contact contact)
        {
            await _contactRepo.Create(contact);
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            _contactRepo.Delete(id);
            await _unitOfWork.Save();
            return true;
        }

        //public List<Contact> GetAll()
        //{
        //    var listContact = _contactRepo.GetAll();
        //    return listContact?.ToList();
        //}

        public int Count()
        {
            return _contactRepo.GetAll().Count();
        }

        public List<Contact> GetAllWithPage(int pageSize, int pageIndex)
        {
            var listContact = _contactRepo.GetPage(pageSize, pageIndex);
            return listContact?.ToList();
        }

        public async Task<Contact> GetById(int id)
        {
            var contact = await _contactRepo.GetById(id);
            return contact;
        }

        public string GetPhoneNumberByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Contact contact)
        {
            var contactUpdate = await _contactRepo.GetById(contact.id);
            if (contactUpdate != null)
            {
                contactUpdate.name = contact.name;
                contactUpdate.phoneNumber = contact.phoneNumber;
                contactUpdate.notes = contact.notes;
                contactUpdate.myFavourite = contact.myFavourite;
                contactUpdate.gender = contact.gender;
                contactUpdate.NetworkId = contact.NetworkId;

                _contactRepo.Update(contactUpdate);
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
