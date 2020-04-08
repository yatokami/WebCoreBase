using System;
using System.Collections.Generic;

namespace EFCore.Models
{
    public partial class Article
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public DateTime? Created { get; set; }
    }
}
