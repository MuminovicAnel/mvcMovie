using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvcMovie.Models
{
    public class User : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Pseudo { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }

        public virtual ICollection<FilmUser> FilmUsers { get; set; }
    }
}
