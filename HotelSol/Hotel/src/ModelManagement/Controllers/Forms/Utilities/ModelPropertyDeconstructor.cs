using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers.Forms.Utilities
{
    public class ModelPropertyDeconstructor
    {
        object Data01 { get; set; }
        object Data02 { get; set; }
        object Data03 { get; set; }
        object Data04 { get; set; }
        object Data05 { get; set; }
        object Data06 { get; set; }
        object Data07 { get; set; }
        object Data08 { get; set; }
        object Data09 { get; set; }
        object Data10 { get; set; }

        //public static string DeconstructData01(IModel model)
        //{
        //    var _model = model.GetType().GetProperties();
        //    switch (model.ModelType)
        //    {
        //        case EModelType.Customer:
        //            return _model.;
        //        case EModelType.Address:
        //            return "Gatuaddress";
        //        default:
        //            return "";
        //    }
        //}
    }
}
