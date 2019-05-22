using BEQLDB.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface.IServices
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        bool Create(Contact contact);
        bool Update(Contact contact);
        bool Delete(int id);
        string GetPhoneNumberByName(string name);
    }
}
