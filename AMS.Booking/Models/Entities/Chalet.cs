using AMST4_Carousel.MVC.Models;

namespace AmsBooking.Models.Entities
{
    public class Chalet
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ImageUrl4 { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Guid CapacityId { get; set; }
        public virtual Capacity Capacity { get; set; }
        public string Benefícios { get; set; }
    }
}
