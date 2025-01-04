using Hotel.src.ModelManagement.Controllers;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IModel //: ICustomer
    {
        [NotMapped]
        public static EModelType ModelTypeEnum { get; set; }

        string Info { get; }
    }
}
