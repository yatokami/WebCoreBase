using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreBase.ViewModel
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? Created { get; set; }
        public int? IsDelete { get; set; }
    }
}
