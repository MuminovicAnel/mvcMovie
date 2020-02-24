using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcMovie
{
    [Table("ratings")]
    public partial class Ratings
    {
        public Ratings()
        {
            Movies = new HashSet<Movies>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("Rating")]
        public virtual ICollection<Movies> Movies { get; set; }
    }
}
