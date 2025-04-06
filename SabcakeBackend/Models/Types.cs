namespace SabcakeBackend.Models
{
    public class Types
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CakeTypes> CakeTypes { get; set; } = new List<CakeTypes>();
    }
}
