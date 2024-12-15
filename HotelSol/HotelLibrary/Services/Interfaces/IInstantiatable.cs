using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Services.Interfaces
{
    internal interface IInstantiatable<T>
    {
        T Instance { get; set; }
    }
}
