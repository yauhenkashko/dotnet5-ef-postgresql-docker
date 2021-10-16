using System.Collections.Generic;

namespace DOTNET_5_EF_PostgreSQL_Docker.Models
{
    public class PhoneOrderViewModel
    {
        public IList<PhoneViewModel> Phones { get; set; }

        public PhoneViewModel Phone { get; set; }

        public OrderViewModel Order { get; set; }
    }
}
