using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcMovie
{
    [Table("user_like_movie")]
    public partial class UserLikeMovie
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("movie_id")]
        public int MovieId { get; set; }
        [Column("comment")]
        [StringLength(5000)]
        public string Comment { get; set; }
        [Column("stars")]
        public int? Stars { get; set; }
        [Column("hasSeen")]
        public byte HasSeen { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty(nameof(Movies.UserLikeMovie))]
        public virtual Movies Movie { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.UserLikeMovie))]
        public virtual Users User { get; set; }
    }
}
