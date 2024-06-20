using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedDataInEFCore.Entities
{
    [Table("StateMaster")]
    internal class State
    {
        public int StateId { get; set; }
        public string? StateName { get; set; }
        public int CountryId { get; set; }
    }
}
