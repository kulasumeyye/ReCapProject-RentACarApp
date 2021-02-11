using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IModelService
    {

        List<Model> GetAll();
       

        void Add(Model model);
        void Update(Model model);
        void Delete(Model model);
    }
}
