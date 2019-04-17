using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceModel
{
    public class Network
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string nameNetwork { get; set; }
        public double priceCall { get; set; }
        public double priceMessage { get; set; }
    }
}
