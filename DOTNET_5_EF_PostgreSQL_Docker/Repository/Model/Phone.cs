using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET_5_EF_PostgreSQL_Docker.Repository.Model
{
    public class Phone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MobileId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }
}
