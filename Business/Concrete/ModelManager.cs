using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modeldal;
        public void Add(Model model)
        {
            _modeldal.Add(model);
        }

        public void Delete(Model model)
        {
            _modeldal.Delete(model);
        }

        public List<Model> GetAll()
        {
            return _modeldal.GetAll();
        }

        public void Update(Model model)
        {
            _modeldal.Update(model);
        }
    }
}
