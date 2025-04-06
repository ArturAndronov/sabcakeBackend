namespace SabcakeBackend.Models
{
    public class Fillings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CakeFillings> CakeFillings { get; set; } = new List<CakeFillings>();
    }
}
