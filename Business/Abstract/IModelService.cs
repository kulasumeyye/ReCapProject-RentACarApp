using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IModelService
    {

        IDataResult<List<Model>> GetAll();
       

        IResult Add(Model model);
        IResult Update(Model model);
        IResult Delete(Model model);
    }
}
