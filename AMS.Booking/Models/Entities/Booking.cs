namespace AmsBooking.Models.Entities;

/// <summary>
/// <author>Andrey Bertoletti</author>
/// </summary>
public class Booking
{
    public Guid Id { get; set; }
    public Guid ChaletId { get; set; }
    public  Chalet Chalet { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfDays => (EndDate - StartDate).Days;
    public double TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}