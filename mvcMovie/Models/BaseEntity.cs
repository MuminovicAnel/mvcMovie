using System.ComponentModel.DataAnnotations;

namespace mvcMovie.Models
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
