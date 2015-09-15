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
        public long Id { get; protected set; }
        public string CompanyName { get; protected set; }
        public FieldOfActivity Activity { get; protected set; }
        public long AddressId { get; protected set; }
        public string Street { get; protected set; }
        public string City { get; protected set; }
    }
}
