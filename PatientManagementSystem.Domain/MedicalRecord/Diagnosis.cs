﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Domain
{
    public class Diagnosis : BaseEntity
    {
        public string Name { get; set; }
        public string[] Inclusions { get; set; }
        public string[] ExcludesOne { get; set; }
        public string[] ExcludesTwo { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
