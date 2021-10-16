using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET_5_EF_PostgreSQL_Docker.Repository.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string ContactPhone { get; set; }

        public int PhoneId { get; set; }
        [ForeignKey(nameof(Model.Phone.PhoneId))]
        public Phone Phone { get; set; }
    }
}
