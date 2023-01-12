namespace RestAppAPI.Models
{
    public class Restaurant
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
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
