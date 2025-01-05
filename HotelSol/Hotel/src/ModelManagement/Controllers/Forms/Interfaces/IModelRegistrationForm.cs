using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers.Forms.Interfaces
{
    public interface IModelRegistrationForm
    {
        //ICustomer Customer { get; set; }
        IModel CreateForm();
        IModel EditForm(IModel modelToUpdate);
        void DisplaySummary();
        EModelType ModelType { get; set; }
        public IModelRegistrationForm? RelatedForm { get; set; }
        public void AssignRelatedForm(IModelRegistrationForm relatedForm);

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
    }
}
