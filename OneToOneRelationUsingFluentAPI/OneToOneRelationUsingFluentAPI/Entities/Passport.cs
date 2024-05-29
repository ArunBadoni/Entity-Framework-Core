using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneRelationUsingFluentAPI.Entities
{
    internal class Passport
    {
        public int PassportId { get; set; }
        public string? PassportNumber { get; set; }
        public int PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
