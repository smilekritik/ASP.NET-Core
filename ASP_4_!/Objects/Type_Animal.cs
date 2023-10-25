namespace ASP_4__.Objects
{
    public class Type_Animal
    {
        public int Id { get; set; }
        public string Type { get; set; } = "none";
        public string Specifics { get; set; } = "none";

        public int Aviary_ID { get; set; }
        public Aviary? Aviary { get; set; }
    }
}
