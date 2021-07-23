using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class CustomerOrder : Model
    {
        public int OrderId { set; get; }
        public DateTime? OrderDate { set; get; }
        public DateTime? RequiredDate { set; get; }
        public DateTime? ShippedDate { set; get; }
    }
}
