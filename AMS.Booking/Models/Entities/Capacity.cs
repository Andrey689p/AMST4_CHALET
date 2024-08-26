namespace AMST4_Carousel.MVC.Models
{
    public class Capacity
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreateData { get; set; } = DateTime.Now;

    }
}
