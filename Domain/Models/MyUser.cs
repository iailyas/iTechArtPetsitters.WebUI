﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MyUser
    {
        public Guid id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string picture { get; set; }
        
    }
}
