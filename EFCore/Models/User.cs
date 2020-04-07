using System;
using System.Collections.Generic;

namespace EFCore.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? Created { get; set; }
        public int? Sex { get; set; }
        public int? Flag { get; set; }
    }
}
