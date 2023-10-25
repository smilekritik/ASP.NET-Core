﻿namespace ASP_4__.Objects
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "none";
        public string Soname { get; set; } = "none";
        public string Patronimic { get; set; } = "none";
        public int Telephone_numer { get; set; }

        public List<Ticket> Tickets { get; set; } = new();
    }
}
