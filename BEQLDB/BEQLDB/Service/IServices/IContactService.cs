﻿using BEQLDB.ServiceModel;
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
        //List<Contact> GetAll();
        List<Contact> GetAllWithPage(int pageSize, int pageIndex);
        Task<Contact> GetById(int id);
        Task<bool> Create(Contact contact);
        Task<bool> Update(Contact contact);
        Task<bool> Delete(int id);
        int Count();
        string GetPhoneNumberByName(string name);
    }
}
