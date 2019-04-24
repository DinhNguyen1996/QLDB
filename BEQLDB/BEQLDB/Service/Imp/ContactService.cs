using BEQLDB.ServiceInterface;
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
    public class ContactService : BaseService<Contact>, IContactService
    {
        public ContactService(IUnitOfWork<Contact> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
