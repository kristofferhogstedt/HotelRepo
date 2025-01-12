using Hotel.src.ModelManagement.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IModel
    {
        [NotMapped]
        public EModelType ModelTypeEnum { get; set; }

        string Info { get; }
    }
}
