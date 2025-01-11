using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Utilities.Calculators;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Hotel.src.ModelManagement.Models
{
    public class Invoice : IInvoice
    {
        public int ID { get; set; }

        //-------------------------------------
        public int BookingID { get; set; }
        public Booking Booking { get; set; }
        //-------------------------------------

        private double _amount;
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }

        //-------------------------------------
        [NotMapped]
        public EModelType ModelTypeEnum { get; set; } = EModelType.Invoice;
        [NotMapped]
        public string Info => $"{Booking.Customer.FullName}            {Amount}       {DueDate}       {IsPaid}";

        //-------------------------------------

        public Invoice()
        {
            CreatedDate = DateTime.Now;
            DueDate = CreatedDate.AddDays(30);
        }

        public Invoice(IRoomType roomType, double amount)
        {
            Amount = amount;
            CreatedDate = DateTime.Now;
            DueDate = CreatedDate.AddDays(30);
        }
        public Invoice(IBooking booking)
        {
            Booking = (Booking)booking;
            CreatedDate = DateTime.Now;
            DueDate = CreatedDate.AddDays(30);
        }


        public double GetAmount() 
        { 
            return PriceCalculator.CalculateStayPrice(Booking.StayLength, Booking.Room.Details.Price); 
        }
    }
}
