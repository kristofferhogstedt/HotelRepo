using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.UserInputManagement.Interfaces
{
    internal interface IUserInput<T>
    {
        T Output { get; set; }
    }
}
