using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreBase.ViewModel
{
    public class UsersView
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? Created { get; set; }
    }
}

