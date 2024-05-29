﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneRelationUsingFluentAPI.Entities
{
    internal class Person
    {
        public int PersonId { get; set; }
        public string? Name { get; set; }
        public Passport? Passport { get; set; }
    }
}
