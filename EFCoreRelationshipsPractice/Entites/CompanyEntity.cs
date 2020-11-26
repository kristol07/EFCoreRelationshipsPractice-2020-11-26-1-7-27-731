﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Entites
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}
