using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Selectors.Interfaces
{
    public interface IModelEntitySelector
    {
        public ICustomer Select(List<ICustomer> customers, int startIndex, IMenu previousMenu);
    }
}
