using Hotel.src.ModelManagement.DTOs.Interfaces;

namespace Hotel.src.ModelManagement.DTOs
{
    internal class CustomerDTO : ICustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
