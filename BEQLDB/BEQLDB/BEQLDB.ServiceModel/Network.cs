using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceModel
{
    [Table("Network")]
    public class Network
    {
        public int id { get; set; }
        public string nameNetwork { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }

    [Route("/networks", "GET")]
    public class GetNetWork : IReturn<BaseResponse>
    {
        public int id { get; set; }
        public string nameNetwork { get; set; }
    }

    [Route("/networks", "POST")]
    public class CreateNetwork : IReturn<BaseResponse>
    {
        public int id { get; set; }
        public string nameNetwork { get; set; }
    }

    [Route("/networks/{id}", "PUT")]
    public class UpdateNetwork : IReturn<BaseResponse>
    {
        public int id { get; set; }
        public string nameNetwork { get; set; }
    }

    [Route("/networks/{id}", "DELETE")]
    public class NetworkById : IReturn<BaseResponse>
    {
        public int id { get; set; }
    }
}
