using System.Collections.Generic;

namespace mvcMovie.Models
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<FilmUser> FilmUsers { get; set; }
    }
}
