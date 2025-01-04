using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
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

        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaidDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
        
        //-------------------------------------
        [NotMapped]
        public EModelType ModelTypeEnum { get; set; } = EModelType.Invoice;
        [NotMapped]
        public string Info => $"ID: {ID}, BokningsID: {BookingID}, Pris: {Amount}, Betald: {IsPaid}";

        //-------------------------------------

        public Invoice()
        {
            //CreatedDate = new DateTime();
            CreatedDate = DateTime.Now;

            //Due/*Date = new DateTime();*/
            DueDate = CreatedDate.AddDays(30);
        }
    }
}
