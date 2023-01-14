using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAppAPI.Models
{
    [Table("Restaurant", Schema = "RestApp")]
    public class Restaurant
    {
        [Key, Column("RestId")]
        public int id { get; set; }

        [Column("RestName")]
        public string name { get; set; }

        [Column("RestType")]
        public string type { get; set; }

        [Column("RestCulture")]
        public string culture { get; set; }

        public Restaurant() { }
        public Restaurant( string name, string type, string culture)
        {
            
            this.name = name;
            this.type = type;
            this.culture = culture;
        }

        public Restaurant (int id, string name, string type, string culture)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.culture = culture;
        }
    }
}
