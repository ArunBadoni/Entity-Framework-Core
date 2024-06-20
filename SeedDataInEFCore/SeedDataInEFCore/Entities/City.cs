using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedDataInEFCore.Entities
{
    [Table("CityMaster")]
    internal class City
    {
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int StateId { get; set; }
    }
}
