namespace SabcakeBackend.Models
{
    public class CakeTypes
    {
        public int CakeId { get; set; }
        public Cakes Cake { get; set; }
        public int TypeId { get; set; }
        public Types Type { get; set; }
    }
}
