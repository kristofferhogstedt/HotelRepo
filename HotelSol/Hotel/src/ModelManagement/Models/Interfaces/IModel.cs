using Hotel.src.ModelManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IModel //: ICustomer
    {
        EModelType ModelType { get; set; }
        string Info { get; }
    }
}
