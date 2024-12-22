using Hotel.src.Models.DTOs.Interfaces;

namespace Hotel.src.Models.DTOs
{
    internal class CustomerDTO : ICustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
