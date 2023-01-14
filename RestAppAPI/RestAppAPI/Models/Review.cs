using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAppAPI.Models
{
    [Table("Reviews", Schema = "RestApp")]
    public class Review
    {
        [Key, Column("RevId")]
        public int id { get; set; }

        [Column("UserId")]
        public int userId { get; set; }

        [Column("RestId")]
        public int restId { get; set; }

        [Column("RevNum")]
        public int reviewNum { get; set; }

        [Column("RevDate")]
        public DateTime reviewDate { get; set; }

        public Review() { }
    }
}
