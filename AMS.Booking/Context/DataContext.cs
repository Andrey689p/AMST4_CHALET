using AmsBooking.Models.Entities;
using AMST4_Carousel.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AmsBooking.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Chalet> Chalet { get; set; }
        public DbSet<Capacity> Capacity { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }
}