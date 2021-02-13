using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        public IResult Add(Model model)
        {
            _modeldal.Add(model);
            return new SuccessResult(Messages.ModelDeleted);
        }

        public IResult Delete(Model model)
        {
            _modeldal.Delete(model);
            return new SuccessResult(Messages.ModelDeleted);
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modeldal.GetAll(),Messages.ModelListed);
        }

        public IResult Update(Model model)
        {
            _modeldal.Update(model);
            return new SuccessResult(Messages.ModelUpdated);
        }
    }
}
