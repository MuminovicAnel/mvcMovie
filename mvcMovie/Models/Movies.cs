using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcMovie
{
    [Table("movies")]
    public partial class Movies
    {
        public Movies()
        {
            UserLikeMovie = new HashSet<UserLikeMovie>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("release", TypeName = "date")]
        public DateTime? Release { get; set; }
        [Column("picture")]
        [StringLength(200)]
        public string Picture { get; set; }
        [Column("synopsis")]
        [StringLength(5000)]
        public string Synopsis { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("rating_id")]
        public int RatingId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(Categories.Movies))]
        public virtual Categories Category { get; set; }
        [ForeignKey(nameof(RatingId))]
        [InverseProperty(nameof(Ratings.Movies))]
        public virtual Ratings Rating { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<UserLikeMovie> UserLikeMovie { get; set; }
    }
}
