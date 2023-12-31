﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string Sub { get; set; }
        public string? Picture { get; set; }

        public Person() { }

        public override string? ToString()
        {
            return $"{Id}";
        }
    }
}
