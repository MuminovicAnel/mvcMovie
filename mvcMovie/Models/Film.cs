using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcMovie.Models
{
    public class Film : BaseEntity
    {
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }
        public string Image { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int category_id { get; set; }

        [ForeignKey("category_id")]
        public virtual Category Category { get; set; }

        public virtual ICollection<FilmUser> FilmUsers { get; set; }
    }
}
