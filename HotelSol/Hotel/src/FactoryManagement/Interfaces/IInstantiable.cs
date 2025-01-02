using Hotel.src.MenuManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.FactoryManagement.Interfaces
{
    public interface IInstantiable
    {
        IMenu PreviousMenu { get; set; }
    }
}
