using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Models.Interfaces
{

    // NOT IN USE
    public interface IControllableModel
    {
        [NotMapped]
        public static Type ModelType { get; set; }
        [NotMapped]
        public static Type ControllerType { get; set; }
        [NotMapped]
        public static Type ServiceType { get; set; }
    }
}
