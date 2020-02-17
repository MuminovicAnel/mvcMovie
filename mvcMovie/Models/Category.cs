using System;
using System.Collections.Generic;

namespace mvcMovie.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Film> Films { get; set; }
    }
}