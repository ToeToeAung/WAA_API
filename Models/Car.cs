namespace WAA_API.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } // Car manufacturer (e.g., Toyota, Ford)
        public string Model { get; set; } // Car model (e.g., Corolla, Mustang)
        public int Year { get; set; } // Year of manufacture
        public decimal Price { get; set; } // Price of the car
    }
}
