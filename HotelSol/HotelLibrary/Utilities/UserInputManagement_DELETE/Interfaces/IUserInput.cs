using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Utilities.UserInputManagement.Interfaces
{
    public interface IUserInput<T>
    {
        T Output { get; set; }
    }
}
