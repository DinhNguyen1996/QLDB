using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface.DTO
{
    public class NetworkDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage ="this field is required")]
        public string nameNetwork { get; set; }
    }
}
