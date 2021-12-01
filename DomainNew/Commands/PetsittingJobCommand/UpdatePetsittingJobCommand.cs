﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.PetsittingJobCommand
{
    public class UpdatePetsittingJobCommand
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
