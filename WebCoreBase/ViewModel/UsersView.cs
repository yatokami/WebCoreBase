using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class UserViewPost
    {
        public string Username { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        [Required(ErrorMessage = "Password 是必填项")]
        public string Password { get; set; }
    }
}

