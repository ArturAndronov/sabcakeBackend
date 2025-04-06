namespace SabcakeBackend.Models
{
    public class CakeFillings
    {
        public int CakeId { get; set; }
        public Cakes Cake { get; set; }
        public int FillingId { get; set; }
        public Fillings Filling { get; set; }
    }
}
