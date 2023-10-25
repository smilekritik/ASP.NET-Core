namespace ASP_4__.Objects
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; } = "none";
        public string Soname { get; set; } = "none";
        public string Patronimic { get; set; } = "none";
        public int PassportID { get; set; }
        public decimal Salary { get; set; }

        public List<Aviary> Aviaries { get; set; } = new();
    }
}
