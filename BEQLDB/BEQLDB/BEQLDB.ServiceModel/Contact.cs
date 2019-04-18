using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceModel
{
    [Table("Contact")]
    public class Contact
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string notes { get; set; }
        public bool myFavourite { get; set; }
        public bool gender { get; set; }

        public int NetworkId { get; set; }
        public virtual Network Network { get; set; }
    }

    [Route("/contacts","GET")]
    public class GetALLContact : IReturn<BaseResponse>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string notes { get; set; }
        public bool myFavourite { get; set; }
        public bool gender { get; set; }
        public int NetworkId { get; set; }
    }

    [Route("/contacts", "POST")]
    public class CreateContact : IReturn<BaseResponse>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string notes { get; set; }
        public bool myFavourite { get; set; }
        public bool gender { get; set; }
        public int NetworkId { get; set; }
    }

    [Route("/contacts/{id}", "PUT")]
    public class UpdateContact : IReturn<BaseResponse>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string notes { get; set; }
        public bool myFavourite { get; set; }
        public bool gender { get; set; }
        public int NetworkId { get; set; }
    }

    [Route("/contacts/{id}", "Get, DELETE")]
    public class ContactById : IReturn<BaseResponse>
    {
        public int id { get; set; }
    }
}
