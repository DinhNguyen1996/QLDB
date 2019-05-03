using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceModel.DTOs
{
    public class ContactDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string notes { get; set; }
        public bool myFavourite { get; set; }
        public bool gender { get; set; }

        public int NetworkId { get; set; }
        public string NetworkName { get; set; }
    }
}
