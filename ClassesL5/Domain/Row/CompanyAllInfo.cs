using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.CompanyAssets;

namespace Domain.Row
{
    public class CompanyAllInfo
    {
        public long Id { get;  set; }
        public string CompanyName { get;  set; }
        public FieldOfActivity Activity { get;  set; }
        public long AddressId { get;  set; }
        public string Street { get;  set; }
        public string City { get;  set; }
    }
}
