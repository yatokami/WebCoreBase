﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreBase.ViewModel
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? Created { get; set; }
        public int? Sex { get; set; }
        public int? Flag { get; set; }
    }
}
