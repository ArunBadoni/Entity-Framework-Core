using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedDataInEFCore.Entities
{
    [Table("CountryMaster")]
    internal class Country
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
    }
}
