using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
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
        IMenu MainMenu { get; set; }
        EModelType ModelType { get; set; }
        public IModelRegistrationForm? RelatedForm { get; set; }
        public EModelType RelatedFormModelType { get; set; }
        public bool IsAnEdit { get; set; }
        public IModelController ModelController { get; set; }

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
        public void AssignRelatedForm(IModelRegistrationForm relatedForm);
        //IModel CreateForm();
        //IModel EditForm(IModel modelToUpdate);
        void CreateForm();
        void EditForm(IModel modelToUpdate);
        void InactivateForm(IModel modelToInactivate);
        IModel CreateAndReturnForm();
        IModel EditAndReturnForm(IModel modelToUpdate);
        void DisplaySummary();
    }
}
