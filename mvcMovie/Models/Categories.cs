using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcMovie
{
    [Table("categories")]
    public partial class Categories
    {
        public Categories()
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

        [InverseProperty("Category")]
        public virtual ICollection<Movies> Movies { get; set; }
    }
}
