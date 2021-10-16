using System.Collections.Generic;

namespace DOTNET_5_EF_PostgreSQL_Docker.Models
{
    public class PhoneOrderViewModel
    {
        public IList<PhoneViewModel> Phones { get; set; }

        public IList<OrderViewModel> Orders { get; set; }
    }
}
