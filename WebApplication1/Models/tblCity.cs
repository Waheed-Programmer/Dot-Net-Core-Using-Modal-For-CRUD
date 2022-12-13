using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class tblCity
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }

        public virtual List<tblCustomers> tblCustomers { get; set; }

    }
}
