using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? Created { get; set; }
        public int? IsDelete { get; set; }
    }
}
