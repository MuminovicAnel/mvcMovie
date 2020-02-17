using System.ComponentModel.DataAnnotations.Schema;

namespace mvcMovie.Models
{
    public class FilmUser : BaseEntity
    {
        public int Rating { get; set; }

        public int User_id { get; set; }
        public int Film_id { get; set; }
        public int Status_id { get; set; }

        [ForeignKey("User_id")]
        public virtual User User { get; set; }
        [ForeignKey("Film_id")]
        public virtual Film Film { get; set; }
        [ForeignKey("Status_id")]
        public virtual Status Status { get; set; }
    }
}
