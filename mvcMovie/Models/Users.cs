using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcMovie
{
    [Table("users")]
    public partial class Users
    {
        public Users()
        {
            UserLikeMovie = new HashSet<UserLikeMovie>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("firstname")]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [Column("lastname")]
        [StringLength(50)]
        public string Lastname { get; set; }
        [Column("isAdmin")]
        public byte? IsAdmin { get; set; }

        public string getFullName => $"{Firstname} {Lastname}, ";

        [InverseProperty("User")]
        public virtual ICollection<UserLikeMovie> UserLikeMovie { get; set; }
    }
}
