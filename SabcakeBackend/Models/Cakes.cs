namespace SabcakeBackend.Models
{
    public class Cakes
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Category { get; set; }
        public int Rating { get; set; }

        // Навигационные свойства для связей
        public ICollection<CakeTypes> CakeTypes { get; set; } = new List<CakeTypes>();
        public ICollection<CakeFillings> CakeFillings { get; set; } = new List<CakeFillings>();
    }
}
